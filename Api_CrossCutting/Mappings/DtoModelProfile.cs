using Api_Domain.Dtos.Cep;
using Api_Domain.Dtos.Municipio;
using Api_Domain.Dtos.Uf;
using Api_Domain.Dtos.User;
using Api_Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_CrossCutting.Mappings
{
    public class DtoModelProfile : Profile
    {
        public DtoModelProfile()
        {
            #region User
            // Uma Model que pode se tranformar em uma Dto e vice-versa.
            CreateMap<UserModel, UserDto>()
            .ReverseMap();
            CreateMap<UserModel, UserDtoCreate>()
           .ReverseMap();
            CreateMap<UserModel, UserDtoUpdate>()
           .ReverseMap();
            #endregion

            #region Uf
            CreateMap<UfModel, UfDto>()
              .ReverseMap();
            #endregion

            #region Municipio
            CreateMap<MunicipioModel, MunicipioDto>()
              .ReverseMap();
            CreateMap<MunicipioModel, MunicipioDtoCreate>()
              .ReverseMap();
            CreateMap<MunicipioModel, MunicipioDtoUpdate>()
              .ReverseMap();
            #endregion

            #region Cep
            CreateMap<CepModel, CepDto>()
              .ReverseMap();
            CreateMap<CepModel, CepDtoCreate>()
              .ReverseMap();
            CreateMap<CepModel, CepDtoUpdate>()
              .ReverseMap();
            #endregion
        }


    }
}
