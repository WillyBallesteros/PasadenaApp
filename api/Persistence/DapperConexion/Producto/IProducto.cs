using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Dtos;

namespace Persistence.DapperConexion.Producto
{
    public interface IProducto
    {
        public Task<IEnumerable<ProductoDto>> ObtenerLista();
        public Task<ProductoDto> ObetenerPorId(int id);
        public Task<int> Nuevo(ProductoDto parametros);
        public Task<int> Actualizar(ProductoDto parametros);
        public Task<int> Elimina(int id);
    }
}
