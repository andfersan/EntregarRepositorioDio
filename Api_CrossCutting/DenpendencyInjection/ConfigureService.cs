using Api_Domain.Interfaces.Services.Cep;
using Api_Domain.Interfaces.Services.Municpio;
using Api_Domain.Interfaces.Services.Uf;
using Api_Domain.Interfaces.Services.User;
using Api_Service.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_CrossCutting.DenpendencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            // AddTransient, para cada operação que tiver uma injeção de dependecia, ele criará uma instância de UserService.
            // AddScoped, se ele usar dez metodos, usará a mesma instancia UserService, porém isso é para um ciclo de vida.
            // AddSingleton, se ele startar a aplicação no servidor, jamais mudará, uma vez só.
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<ILoginService, LoginService>();

            serviceCollection.AddTransient<IUfService, UfService>();
            serviceCollection.AddTransient<IMunicipioService, MunicipioService>();
            serviceCollection.AddTransient<ICepService, CepService>();

        }


    }
}
