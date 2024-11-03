using System.Threading.Tasks;
using Core.Dtos;
using Core.Payload;
using Microsoft.AspNetCore.Mvc;
using Services.DocumentService;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;
        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpPost]
        [Route("UploadFile")]
        public async Task<ActionResult<DocumentoDto>> UploadFile(ImagenPayload payload)
        {
            var responsePackage = await _documentService.UploadFile(payload);
            return Ok(responsePackage);
        }

        [HttpGet]
        [Route("DownloadFile")]
        public async Task<ActionResult<DocumentoDto>> DownloadFile([FromQuery] DocumentoPayload payload)
        {
            var responsePackage = await _documentService.DownloadFile(payload);
            return Ok(responsePackage);
        }
    }
}