using AutoMapper;
using Core.Domain;
using Core.Dtos;

namespace Core.AutoMapperConfiguration
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Departamentos, DepartamentoDto>();
            CreateMap<DepartamentoDto, Departamentos>();
            CreateMap<Usuarios, UsuarioDto>();
            CreateMap<UsuarioDto, Usuarios>();
            CreateMap<Usuarios, LoginDto>();
            CreateMap<LoginDto, Usuarios>();
        }
    }
}
