using System;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Core;
using Core.Domain;
using Core.Dtos;
using Core.Payload;
using Core.Repositories;
using Microsoft.AspNetCore.Identity;
using Services.Handlers;

namespace Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<Usuarios> _userManager;
        private readonly SignInManager<Usuarios> _signInManager;
        private readonly IMapper _mapper;
        private readonly IJwtGenerator _jwtGenerator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserSession _userSession;
        private readonly IPasswordHasher<Usuarios> _passwordHasher;

        public AuthService(
            UserManager<Usuarios> userManager,
            SignInManager<Usuarios> signInManager,
            IPasswordHasher<Usuarios> passwordHasher,
            IMapper mapper,
            IJwtGenerator jwtGenerator,
            IUnitOfWork unitOfWork,
            IUserSession userSession)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _jwtGenerator = jwtGenerator;
            _unitOfWork = unitOfWork;
            _userSession = userSession;
            _passwordHasher = passwordHasher;
        }

        public async Task<ResponsePackage<LoginDto>> Ingreso(LoginPayload payload)
        {
            var responsePackage = new ResponsePackage<LoginDto>()
            {
                Errors = HttpStatusCode.Unauthorized,
                Message = "Usuario no autorizado",
                Result = null
            };

            var usuario = await _userManager.FindByEmailAsync(payload.Email);
            if (usuario == null)
            {
                return responsePackage;
            }

            var resultado = await _signInManager.CheckPasswordSignInAsync(usuario, payload.Password, false);
            if (!resultado.Succeeded) return responsePackage;

            var imagenCliente = await GetImagenPerfil(new Guid(usuario.Id));

            responsePackage.Errors = null;
            responsePackage.Message = "Usuario autorizado";
            var loginDto = _mapper.Map<LoginDto>(usuario);
            loginDto.Token = _jwtGenerator.CrearToken(usuario);
            loginDto.ImagenPerfil = imagenCliente;
            responsePackage.Result = loginDto;
            return responsePackage;
        }

        public async Task<ResponsePackage<RegisterDto>> Registro(RegisterPayload payload)
        {
            var responsePackage = new ResponsePackage<RegisterDto>()
            {
                Errors = HttpStatusCode.BadRequest,
                Message = "Ya existe un usuario con el Email ingresado",
                Result = null
            };

            var exists = await _unitOfWork.Usuarios.GetSingleOrDefaultAsync(x => x.Email == payload.Email);
            if (exists != null)
            {
                return responsePackage;
            }
            var usuario = _mapper.Map<Usuarios>(payload);
            usuario.UserName = payload.Email;

            var result = await _userManager.CreateAsync(usuario, payload.Password);
            if (result.Succeeded)
            {
                responsePackage.Errors = null;
                responsePackage.Message = "Usuario registrado correctamente";
                var registerDto = _mapper.Map<RegisterDto>(usuario);
                registerDto.Token = _jwtGenerator.CrearToken(usuario);
                responsePackage.Result = registerDto;
                return responsePackage;
            }

            responsePackage.Message = "No se logro registrar al usuario";
            responsePackage.Errors = result.Errors;
            return responsePackage;

        }

        public async Task<ResponsePackage<UsuarioDto>> GetUser()
        {
            var responsePackage = new ResponsePackage<UsuarioDto>()
            {
                Errors = HttpStatusCode.Unauthorized,
                Message = "Usuario no autorizado",
                Result = null
            };
            var userName = _userSession.GetUserSession();
            if (userName == null) return responsePackage;

            var usuario = await _userManager.FindByNameAsync(userName);

            var imagenCliente = await GetImagenPerfil(new Guid(usuario.Id));

            responsePackage.Errors = null;
            responsePackage.Message = "Usuario Actual";
            var usuarioDto = _mapper.Map<UsuarioDto>(usuario);
            usuarioDto.Token = _jwtGenerator.CrearToken(usuario);
            usuarioDto.ImagenPerfil = imagenCliente;
            responsePackage.Result = usuarioDto;
            return responsePackage;

        }

        public async Task<ImagenDto> GetImagenPerfil(Guid usuarioId)
        {
            var imagenCliente = new ImagenDto();
            var imagenPerfil = await _unitOfWork.Documents
                .GetFirstOrDefaultAsync(x => x.ObjetoReferencia == usuarioId);

            if (imagenPerfil == null) return null;
            imagenCliente = new ImagenDto
            {
                Data = Convert.ToBase64String(imagenPerfil.Contenido),
                Extension = imagenPerfil.Extension,
                Nombre = imagenPerfil.Nombre
            };
            return imagenCliente;
        }

        public async Task<ResponsePackage<RegisterDto>> UpdateUser(UpdateUserPayload payload)
        {
            var responsePackage = new ResponsePackage<RegisterDto>()
            {
                Errors = HttpStatusCode.BadRequest,
                Message = "No existe un usuario con el Email ingresado",
                Result = null
            };
            var usuarioIden = await _userManager.FindByEmailAsync(payload.Email);
            if (usuarioIden == null)
            {
                return responsePackage;
            }


            if (payload.ImagenPerfil != null)
            {
                var resultadoImagen =
                    await _unitOfWork.Documents.GetFirstOrDefaultAsync(x =>
                        x.ObjetoReferencia == new Guid(usuarioIden.Id));

                if (resultadoImagen == null)
                {
                    var imagen = new Documents
                    {
                        Contenido = Convert.FromBase64String(payload.ImagenPerfil.Data),
                        Nombre = payload.ImagenPerfil.Nombre,
                        Extension = payload.ImagenPerfil.Extension,
                        ObjetoReferencia = new Guid(usuarioIden.Id),
                        DocumentId = Guid.NewGuid(),
                        FechaCreacion = DateTime.UtcNow
                    };
                    _unitOfWork.Documents.Insert(imagen);
                }
                else
                {
                    resultadoImagen.Contenido = Convert.FromBase64String(payload.ImagenPerfil.Data);
                    resultadoImagen.Nombre = payload.ImagenPerfil.Nombre;
                    resultadoImagen.Extension = payload.ImagenPerfil.Extension;
                }
            }

            usuarioIden.Nombres = payload.Nombres;
            usuarioIden.Apellidos = payload.Apellidos;
            usuarioIden.Telefono = payload.Telefono;
            usuarioIden.TipoDocumentoId = payload.TipoDocumentoId;
            usuarioIden.NumeroCedula = payload.NumeroCedula;
            usuarioIden.CiudadId = payload.CiudadId;
            usuarioIden.PuntoVentaId = payload.PuntoVentaId;
            usuarioIden.PasswordHash = _passwordHasher.HashPassword(usuarioIden, payload.Password);

            var result = await _userManager.UpdateAsync(usuarioIden);
            if (result.Succeeded)
            {
                var imagenCliente = await GetImagenPerfil(new Guid(usuarioIden.Id));
                responsePackage.Errors = null;
                responsePackage.Message = "Usuario actualizado correctamente";
                var registerDto = _mapper.Map<RegisterDto>(usuarioIden);
                registerDto.Token = _jwtGenerator.CrearToken(usuarioIden);
                registerDto.ImagenPerfil = imagenCliente;
                responsePackage.Result = registerDto;
                return responsePackage;
            }

            responsePackage.Message = "No se logro actualizar al usuario";
            responsePackage.Errors = result.Errors;
            return responsePackage;

        }


    }
}
