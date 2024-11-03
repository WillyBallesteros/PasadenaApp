using System;
using System.Net;
using System.Threading.Tasks;
using Core;
using Core.Domain;
using Core.Dtos;
using Core.Payload;
using Services.Handlers;

namespace Services.DocumentService
{
    public class DocumentService : IDocumentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DocumentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponsePackage<DefaultDto>> UploadFile(ImagenPayload payload)
        {
            var responsePackage = new ResponsePackage<DefaultDto>()
            {
                Errors = HttpStatusCode.BadRequest,
                Message = "No se pudo crear el archivo",
                Result = null
            };
            var documento =
                await _unitOfWork.Documents.GetSingleOrDefaultAsync(x =>
                    x.ObjetoReferencia == payload.ObjetoReferencia);

            if (documento == null)
            {
                var file = new Documents
                {
                    Contenido = Convert.FromBase64String(payload.Data),
                    Nombre = payload.Nombre,
                    Extension = payload.Extension,
                    DocumentId = Guid.NewGuid(),
                    FechaCreacion = DateTime.UtcNow
                };
                _unitOfWork.Documents.Insert(file);
            }
            else
            {
                documento.Contenido = Convert.FromBase64String(payload.Data);
                documento.Nombre = payload.Nombre;
                documento.Extension = payload.Extension;
                documento.FechaCreacion = DateTime.UtcNow;
            }

            var result = await _unitOfWork.SaveChangesAsync();

            if (result <= 0) return responsePackage;
            responsePackage.Errors = HttpStatusCode.Accepted;
            responsePackage.Message = "Se guardo el archivo";
            return responsePackage;

        }

        public async Task<ResponsePackage<DocumentoDto>> DownloadFile(DocumentoPayload payload)
        {
            var responsePackage = new ResponsePackage<DocumentoDto>()
            {
                Errors = HttpStatusCode.BadRequest,
                Message = "No se encontro el archivo",
                Result = null
            };
            var file = await _unitOfWork.Documents.GetSingleOrDefaultAsync(x => x.ObjetoReferencia == payload.Id);
            if (file == null) return responsePackage;

            var document = new DocumentoDto
            {
                Data = Convert.ToBase64String(file.Contenido),
                Nombre = file.Nombre,
                Extension = file.Extension
            };

            responsePackage.Result = document;
            responsePackage.Errors = null;
            responsePackage.Message = "Archivo encontrado";
            return responsePackage;
        }
    }
}
