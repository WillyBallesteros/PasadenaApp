using Core.Payload;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Producto;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductoService _productoService;
        public ProductController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("GetProductsByGroup")]
        public IActionResult GetProductsByGroup([FromQuery] ProductsByGroupPayload payload)
        {
            var responsePackage = _productoService.GetProductsByGroup(payload);
            return Ok(responsePackage);
        }
    }
}