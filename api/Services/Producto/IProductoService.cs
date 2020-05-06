using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Dtos;
using Core.Payload;
using Services.Handlers;

namespace Services.Producto
{
    public interface IProductoService
    {
        Task<ResponsePackage<IEnumerable<ProductoDto>>> GetProductsByGroup(ProductsByGroupPayload payload);
    }
}
