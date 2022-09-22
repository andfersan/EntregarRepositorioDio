using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Data.Context
{
    // Fabrica de contexto
    // Classe para criação de banco de dados e tabelas de desing
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        // Cria uma DbConetxt com string como argumento
        public MyContext CreateDbContext(string[] args)
        {
            //Usado para criar migrações
            var connectionString = "Data Source=LAPTOP-M4OSB1R9\\SQLEXPRESS;Database=dbAPI;User Id=SA; Password=anderson";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new MyContext (optionsBuilder.Options);
        }
    }
}
