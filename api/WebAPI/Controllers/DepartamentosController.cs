using Microsoft.AspNetCore.Mvc;
using Services.Departamento;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        private readonly IDepartamentoService _departamentoService;
        public DepartamentosController(IDepartamentoService departamentoService)
        {
            _departamentoService = departamentoService;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var responsePackage = _departamentoService.GetAllDepartamentos();
            return Ok(responsePackage);
        }

    }
}