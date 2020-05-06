using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Dtos;

namespace Persistence.DapperConexion.Producto
{
    public interface IProducto
    {
        Task<IEnumerable<ProductoDto>> ObtenerLista();
        Task<ProductoDto> ObetenerPorId(int id);
        Task<int> Nuevo(ProductoDto parametros);
        Task<int> Actualizar(ProductoDto parametros);
        Task<int> Elimina(int id);
    }
}
