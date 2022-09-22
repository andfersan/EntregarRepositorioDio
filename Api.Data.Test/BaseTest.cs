using Api_Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace Api.Data.Test
{
    public abstract class BaseTest
    {
        public BaseTest ()
        {

        }
    }
    public class DbTeste : IDisposable
    {
        // Pegar o banco de dados                                              // onde estiver - ficará vazio.
        private string dataBaseName = $"dbApiTest_{Guid.NewGuid().ToString().Replace("-", string.Empty)}";
                                                      //private ninguem pode alterar esse set.
        public ServiceProvider ServiceProvider { get; private set; }
        public DbTeste()
        {
            // Garante que o banco de dados seja criado.
            //Que esta dentro da string de conexão
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<MyContext>(
                o => o.UseSqlServer($"Persist Security Info=True;Data Source=LAPTOP-M4OSB1R9\\SQLEXPRESS;Database={dataBaseName};User Id=SA; Password=anderson"),
                ServiceLifetime.Transient);
            // Buildado para esse ServiceProvider
            ServiceProvider = serviceCollection.BuildServiceProvider();
            // vai trabalhar aqui e depois ser retirado da memoria
            using (var context = ServiceProvider.GetService<MyContext>())
            {
                // Pegar o contexto do mycontext, criar o banco de dados e fazer as migrações.

                context.Database.EnsureCreated();
            }
        }
        // Garante que o banco de dados seja deletado.
        public void Dispose()
        {
            using (var context = ServiceProvider.GetService<MyContext>())
            {
                // Pegar o contexto do mycontext, garantir que o banco seja eliminado.
                context.Database.EnsureDeleted();
            }
            
        }
    }
}
