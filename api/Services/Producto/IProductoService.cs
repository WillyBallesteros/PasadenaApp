using System.Collections.Generic;
using Core.Dtos;
using Core.Payload;
using Services.Handlers;

namespace Services.Producto
{
    public interface IProductoService
    {
        ResponsePackage<IEnumerable<ProductoDto>> GetProductsByGroup(ProductsByGroupPayload payload);
    }
}
