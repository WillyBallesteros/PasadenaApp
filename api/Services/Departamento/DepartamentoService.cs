using System.Collections.Generic;
using AutoMapper;
using Core;
using Core.Dtos;
using Services.Handlers;

namespace Services.Departamento
{
    public class DepartamentoService : IDepartamentoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DepartamentoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public ResponsePackage<IEnumerable<DepartamentoDto>> GetAllDepartamentos()
        {
            var departamentos = _unitOfWork.Departamentos.Get();
            var departamentosDto = _mapper.Map<IEnumerable<DepartamentoDto>>(departamentos);

            return new ResponsePackage<IEnumerable<DepartamentoDto>>
            {
                Message = "Listado de Departamentos",
                Result = departamentosDto,
                Errors = "N/A"
            };
        }
    }
}
