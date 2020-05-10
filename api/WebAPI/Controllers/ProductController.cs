using System.Threading.Tasks;
using Core.Dtos;
using Core.Models;
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

        [HttpPost]
        [AllowAnonymous]
        [Route("GetProductsByGroup")]
        public async Task<ActionResult<ProductoDto>> GetProductsByGroup(PaginacionPayload payload)
        {
            var responsePackage = await _productoService.GetProductsByGroup(payload);
            return Ok(responsePackage);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Report")]
        public async Task<ActionResult<PaginacionModel>> Report(PaginacionPayload payload)
        {
            var responsePackage = await _productoService.GetPaginacion(payload);
            return Ok(responsePackage);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("GetPromoProducts")]
        public async Task<ActionResult<PaginacionModel>> GetPromoProducts(PaginacionPayload payload)
        {
            var responsePackage = await _productoService.GetPromoProducts(payload);
            return Ok(responsePackage);
        }

        
    }
}