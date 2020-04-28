using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Core.Domain;
using Core.Dtos;
using Core.Payload;
using Microsoft.AspNetCore.Identity;
using Services.Handlers;

namespace Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<Usuarios> _userManager;
        private readonly SignInManager<Usuarios> _signInManager;
        private readonly IMapper _mapper;
        public AuthService(
            UserManager<Usuarios> userManager,
            SignInManager<Usuarios> signInManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
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
            responsePackage.Result = _mapper.Map<LoginDto>(usuario);
            return responsePackage;

        }
    }
}
