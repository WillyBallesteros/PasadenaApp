using System.Threading.Tasks;
using Core.Dtos;
using Core.Payload;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.AuthService;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        /// <summary>
        ///     Login de Usuario
        /// </summary>
        /// <param name="LoginPayload"></param>
        [HttpPost]
        [AllowAnonymous]
        [Route("Login")]
        // POST: api/v1/Auth/Login/
        public async Task<ActionResult<LoginDto>> Login(LoginPayload payload)
        {
            var responsePackage = await _authService.Ingreso(payload);
            return Ok(responsePackage);
        }

        /// <summary>
        ///     Registro de Usuario
        /// </summary>
        /// <param name="RegisterPayload"></param>
        [HttpPost]
        [AllowAnonymous]
        [Route("Register")]
        // POST: api/v1/Auth/Register/
        public async Task<ActionResult<RegisterDto>> Register(RegisterPayload payload)
        {
            var responsePackage = await _authService.Registro(payload);
            return Ok(responsePackage);
        }

        /// <summary>
        ///     Obtener Usuario
        /// </summary>
        [HttpGet]
        [AllowAnonymous]
        [Route("GetCurrentUser")]
        // POST: api/v1/Auth/GetCurrentUser/
        public async Task<ActionResult<UsuarioDto>> GetCurrentUser()
        {
            var responsePackage = await _authService.GetUser();
            return Ok(responsePackage);
        }

        /// <summary>
        ///     Registro de Usuario
        /// </summary>
        /// <param name="UpdateUserPayload"></param>
        [HttpPut]
        [Route("UpdateUser")]
        // PUT: api/v1/Auth/UpdateUser/
        public async Task<ActionResult<LoginDto>> UpdateUser(UpdateUserPayload payload)
        {
            var responsePackage = await _authService.UpdateUser(payload);
            return Ok(responsePackage);
        }
    }
}