using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Core;
using Core.Domain;
using Core.Dtos;
using Core.Payload;
using Microsoft.AspNetCore.Identity;
using Services.ContractService;
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
        public AuthService(
            UserManager<Usuarios> userManager,
            SignInManager<Usuarios> signInManager,
            IMapper mapper,
            IJwtGenerator jwtGenerator,
            IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _jwtGenerator = jwtGenerator;
            _unitOfWork = unitOfWork;
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

            responsePackage.Errors = null;
            responsePackage.Message = "Usuario autorizado";
            var loginDto = _mapper.Map<LoginDto>(usuario);
            loginDto.Token = _jwtGenerator.CrearToken(usuario);
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


    }
}
