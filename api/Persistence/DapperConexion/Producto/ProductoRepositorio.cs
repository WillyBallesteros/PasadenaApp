using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Core.Dtos;
using Dapper;

namespace Persistence.DapperConexion.Producto
{
    public class ProductoRepositorio : IProducto
    {
        public readonly IFactoryConection _factoryConection;
        public ProductoRepositorio(IFactoryConection factoryConection)
        {
            _factoryConection = factoryConection;
        }
        public async Task<IEnumerable<ProductoDto>> ObtenerLista()
        {
            IEnumerable<ProductoDto> productoList = null;
            var storeProcedure = "usp_Obtener_Productos";
            try
            {
                var connection = _factoryConection.GetConnection();
                productoList = await connection.QueryAsync<ProductoDto>(storeProcedure, null, commandType: CommandType.StoredProcedure);
            }
            catch (Exception e)
            {
                throw new Exception("Error en la consulta de datos", e);
            }
            finally
            {
                _factoryConection.CloseConnection();
            }

            return productoList;
        }

        public Task<ProductoDto> ObetenerPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Nuevo(ProductoDto parametros)
        {
            throw new NotImplementedException();
        }

        public Task<int> Actualizar(ProductoDto parametros)
        {
            throw new NotImplementedException();
        }

        public Task<int> Elimina(int id)
        {
            throw new NotImplementedException();
        }
    }
}
