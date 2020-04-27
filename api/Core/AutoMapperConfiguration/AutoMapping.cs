using System;
using System.Collections.Generic;
using System.Text;
using Core.Domain;
using AutoMapper;
using Core.Dtos;

namespace Core.AutoMapperConfiguration
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Departamentos, DepartamentoDto>();
            CreateMap<DepartamentoDto, Departamentos>();
        }
    }
}
