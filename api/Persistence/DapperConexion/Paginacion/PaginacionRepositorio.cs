using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;
using Dapper;

namespace Persistence.DapperConexion.Paginacion
{
    public class PaginacionRepositorio : IPaginacion
    {
        private readonly IFactoryConection _factoryConection;
        public PaginacionRepositorio(IFactoryConection factoryConection)
        {
            _factoryConection = factoryConection;
        }
        public async Task<PaginacionModel> DevolverPaginacion(
            string storeProcedure,
            int numeroPagina, int cantidadElementos,
            IDictionary<string, object> parametrosFiltro,
            string ordenamientoColumna)
        {
            PaginacionModel paginacionModel = new PaginacionModel();
            List<IDictionary<string, object>> listaReporte = null;
            int totalRecords = 0;
            int totalPaginas = 0;
            try
            {
                var connection = _factoryConection.GetConnection();
                DynamicParameters parametros = new DynamicParameters();

                foreach (var param in parametrosFiltro)
                {
                    parametros.Add("@" + param.Key, param.Value);
                }

                parametros.Add("@NumeroPagina", numeroPagina, DbType.Int32);
                parametros.Add("@CantidadElementos", cantidadElementos, DbType.Int32);
                parametros.Add("@Ordenamiento", ordenamientoColumna, DbType.String);

                parametros.Add("@TotalRecords", totalRecords, DbType.Int32, ParameterDirection.Output);
                parametros.Add("@TotalPaginas", totalPaginas, DbType.Int32, ParameterDirection.Output);

                var result = await connection.QueryAsync(storeProcedure, parametros, commandType: CommandType.StoredProcedure);
                listaReporte = result.Select(x => (IDictionary<string, object>)x).ToList();
                paginacionModel.ListaRecords = listaReporte;
                paginacionModel.NumeroPaginas = parametros.Get<int>("@TotalPaginas");
                paginacionModel.TotalRecords = parametros.Get<int>("@TotalRecords");
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo ejecutar el procedimiento almacenado", e);
            }
            finally
            {
                _factoryConection.CloseConnection();
            }

            return paginacionModel;
        }
    }
}
