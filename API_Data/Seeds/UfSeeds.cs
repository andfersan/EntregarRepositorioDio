using Api_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Data.Seeds
{
    public static class UfSeeds
    {
        public static void Ufs(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UfEntity>().HasData(
                new UfEntity()
                {
                    Id = new Guid("a7abf6d4-b2fC-4897-aa12-d0d6589c6256"),
                    Sigla = "AC",
                    Nome = "Acre",
                    CreateAt = DateTime.UtcNow
                },
                 new UfEntity()
                 {
                     Id = new Guid("b32ee1cd-82d1-4d05-9b71-b674e947db00"),
                     Sigla = "AL",
                     Nome = "Alagoas",
                     CreateAt = DateTime.UtcNow
                 },
                 new UfEntity()
                 {
                     Id = new Guid("25818e67-8dc7-49ac-ba76-3ae7abfdbcbe"),
                     Sigla = "BA",
                     Nome = "Bahia",
                     CreateAt = DateTime.UtcNow
                 },
                  new UfEntity()
                  {
                      Id = new Guid("5AFAEAED-E40D-4907-B1FB-18BF86C65264"),
                      Sigla = "SP",
                      Nome = "São Paulo",
                      CreateAt = DateTime.UtcNow
                  });
        }

    }
}
