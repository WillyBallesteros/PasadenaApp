using System.Collections.Generic;
using Core.Dtos;
using Services.Handlers;

namespace Services.Departamento
{
    public interface IDepartamentoService
    {
        ResponsePackage<IEnumerable<DepartamentoDto>> GetAllDepartamentos();
    }
}
