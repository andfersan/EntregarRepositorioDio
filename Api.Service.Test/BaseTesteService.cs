using Api_CrossCutting.Mappings;
using AutoMapper;
using System;

namespace Api.Service.Test
{
    public abstract class BaseTesteService
    {
       
        public IMapper Mapper { get; set; }

        public BaseTesteService()
        {
            Mapper = new autoMapperFixture().GetMapper();
        }

        public class autoMapperFixture : IDisposable
        {
            public IMapper GetMapper()
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new ModelToEntityProfile());
                    cfg.AddProfile(new DtoModelProfile());
                    cfg.AddProfile(new EntityToDtoProfile());
                });

                return config.CreateMapper();
            }
            public void Dispose()
            {

            }
        }
        
    }
}
