using AutoMapper;
using Core.Domain;
using Core.Dtos;
using Core.Payload;

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
            CreateMap<RegisterPayload, Usuarios>();
            CreateMap<Usuarios, RegisterPayload>();
            CreateMap<Usuarios, RegisterDto>();
            CreateMap<RegisterDto, Usuarios>();
            CreateMap<Productos, ProductoDto>();
            CreateMap<ProductoDto, Productos>();

        }
    }
}
