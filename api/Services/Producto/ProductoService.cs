using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Core;
using Core.Dtos;
using Core.Payload;
using Persistence.DapperConexion.Producto;
using Services.Handlers;

namespace Services.Producto
{
    public class ProductoService : IProductoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IProducto _productosRepository;
        public ProductoService(IUnitOfWork unitOfWork, IMapper mapper, IProducto productosRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _productosRepository = productosRepository;
        }
        //public ResponsePackage<IEnumerable<ProductoDto>> GetProductsByGroup(ProductsByGroupPayload payload)
        //{
        //    var productos = _unitOfWork.Productos.GetMany(x => x.GrupoId == payload.GroupId);
        //    var productosDto = _mapper.Map<IEnumerable<ProductoDto>>(productos);

        //    return new ResponsePackage<IEnumerable<ProductoDto>>
        //    {
        //        Message = "Listado de Productos por Grupo",
        //        Result = productosDto,
        //        Errors = "N/A"
        //    };
        //}

        public async Task<ResponsePackage<IEnumerable<ProductoDto>>> GetProductsByGroup(ProductsByGroupPayload payload)
        {
            var productos = await _productosRepository.ObtenerLista();

            var tales = productos;

            return new ResponsePackage<IEnumerable<ProductoDto>>
            {
                Message = "Listado de Productos por Grupo",
                Result = productos,
                Errors = "N/A"
            };
        }
    }
}
