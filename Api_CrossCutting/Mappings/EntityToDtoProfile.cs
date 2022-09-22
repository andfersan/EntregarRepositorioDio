using Api_Domain.Dtos.Cep;
using Api_Domain.Dtos.Municipio;
using Api_Domain.Dtos.Uf;
using Api_Domain.Dtos.User;
using Api_Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {

        public EntityToDtoProfile()
        {
            // Transforma Dto para Model e Vice-versa.
            CreateMap<UserDto, UserEntity>()
                .ReverseMap();

            CreateMap<UserDtoCreateResult, UserEntity>()
                .ReverseMap();

            CreateMap<UserDtoUpdateResult, UserEntity>()
                .ReverseMap();

            CreateMap<UfDto, UfEntity>()
               .ReverseMap();

            CreateMap<MunicipioDto, MunicipioEntity>()
               .ReverseMap();

            CreateMap<MunicipioDtoCompleto, MunicipioEntity>()
              .ReverseMap();

            CreateMap<MunicipioDtoCreateResult, MunicipioEntity>()
              .ReverseMap();

            CreateMap<MunicipioDtoUpdateResult, MunicipioEntity>()
              .ReverseMap();

            CreateMap<CepDto, CepEntity>()
              .ReverseMap();

            CreateMap<CepDtoCreateResult, CepEntity>()
              .ReverseMap();

            CreateMap<CepDtoUpdateResult, CepEntity>()
              .ReverseMap();
        }


    }
}
