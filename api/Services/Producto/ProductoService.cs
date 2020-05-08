using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Core;
using Core.Models;
using Core.Payload;
using Persistence.DapperConexion.Paginacion;
using Persistence.DapperConexion.Producto;

namespace Services.Producto
{
    public class ProductoService : IProductoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IProducto _productosRepository;
        private readonly IPaginacion _paginacion;
        public ProductoService(IUnitOfWork unitOfWork,
            IMapper mapper,
            IProducto productosRepository,
            IPaginacion paginacion)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _productosRepository = productosRepository;
            _paginacion = paginacion;
        }

        public async Task<PaginacionModel> GetProductsByGroup(PaginacionPayload payload)
        {
            var storeProcedure = "usp_obtener_producto_grupo_paginacion";
            var ordenamiento = "ProductoNombre";
            var parametros = new Dictionary<string, object>();
            parametros.Add("GroupId", payload.GroupId);
            var productos = await _paginacion.DevolverPaginacion(storeProcedure, payload.NumeroPagina, payload.CantidadElementos,
                parametros, ordenamiento);

            return productos;
        }

        public async Task<PaginacionModel> GetPaginacion(PaginacionPayload payload)
        {
            var storeProcedure = "usp_obtener_producto_paginacion";
            var ordenamiento = "ProductoNombre";
            var parametros = new Dictionary<string, object>();
            parametros.Add("ProductoNombre", payload.NombreProducto);
            var productos = await _paginacion.DevolverPaginacion(storeProcedure, payload.NumeroPagina, payload.CantidadElementos,
                parametros, ordenamiento);

            return productos;

        }


    }
}
