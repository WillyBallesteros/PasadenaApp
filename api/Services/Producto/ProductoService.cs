using System.Collections.Generic;
using AutoMapper;
using Core;
using Core.Dtos;
using Core.Payload;
using Services.Handlers;

namespace Services.Producto
{
    public class ProductoService : IProductoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public ResponsePackage<IEnumerable<ProductoDto>> GetProductsByGroup(ProductsByGroupPayload payload)
        {
            var productos = _unitOfWork.Productos.GetMany(x => x.GrupoId == payload.GroupId);
            var productosDto = _mapper.Map<IEnumerable<ProductoDto>>(productos);

            return new ResponsePackage<IEnumerable<ProductoDto>>
            {
                Message = "Listado de Productos por Grupo",
                Result = productosDto,
                Errors = "N/A"
            };
        }
    }
}
