using System.Threading.Tasks;
using Core.Models;
using Core.Payload;

namespace Services.Producto
{
    public interface IProductoService
    {
        Task<PaginacionModel> GetProductsByGroup(PaginacionPayload payload);
        Task<PaginacionModel> GetPaginacion(PaginacionPayload payload);
    }
}
