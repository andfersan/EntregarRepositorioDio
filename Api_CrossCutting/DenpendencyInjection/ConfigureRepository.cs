using Api_Data.Context;
using Api_Data.Implementations;
using Api_Data.Repository_Data;
using Api_Domain.Interfaces;
using Api_Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_CrossCutting.DenpendencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            serviceCollection.AddScoped<IUserRepository, UserImplementation>();

            serviceCollection.AddScoped<IUfRepository, UfImplementation>();

            serviceCollection.AddScoped<IMunicipioRepository, MunicipioImplementation>();

            serviceCollection.AddScoped<ICepRepository, CepImplementation>();



            serviceCollection.AddDbContext<MyContext>(options =>
                     options.UseSqlServer("Data Source=LAPTOP-M4OSB1R9\\SQLEXPRESS;Database=dbAPI;User Id=SA; Password=anderson"));
        }

    }
}
