using System.Threading.Tasks;
using Core.Dtos;
using Core.Payload;
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
        ///     Retrieves a carrier based on carrier Id.
        /// </summary>
        /// <param name="LoginPayload"></param>
        [HttpPost]
        [Route("Login")]
        // POST: api/v1/Auth/Login/
        public async Task<ActionResult<UsuarioDto>> Login(LoginPayload payload)
        {
            var responsePackage = await _authService.Ingreso(payload);
            return Ok(responsePackage);
        }

    }
}