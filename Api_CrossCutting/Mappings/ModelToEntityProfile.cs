using Api_Domain.Entities;
using Api_Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_CrossCutting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<UserModel, UserEntity>()
                .ReverseMap();

            CreateMap<UfModel, UfEntity>()
               .ReverseMap();

            CreateMap<MunicipioModel, MunicipioEntity>()
               .ReverseMap();

            CreateMap<CepModel, CepEntity>()
               .ReverseMap();
        }


    }
}
