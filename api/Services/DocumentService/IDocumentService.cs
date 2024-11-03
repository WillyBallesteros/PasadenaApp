using System.Threading.Tasks;
using Core.Dtos;
using Core.Payload;
using Services.Handlers;

namespace Services.DocumentService
{
    public interface IDocumentService
    {
        Task<ResponsePackage<DefaultDto>> UploadFile(ImagenPayload payload);
        Task<ResponsePackage<DocumentoDto>> DownloadFile(DocumentoPayload payload);
    }
}
