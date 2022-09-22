using Api_Data.ORMMapping;
using Api_Data.Seeds;
using Api_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Api_Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set;}

        public MyContext (DbContextOptions<MyContext> options) : base(options) { }
        
        // Serve para fazer  o mapeamento e gerar a tabela
        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Cria um novo User Map e Configura na modelbuilder
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);

            modelBuilder.Entity<UfEntity>(new UfMap().Configure);
            modelBuilder.Entity<MunicipioEntity>(new MunicipioMap().Configure);
            modelBuilder.Entity<CepEntity>(new CepMap().Configure);

            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Administrador",
                    Email = "and@teste.com",
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now
                });
            // pegar a lista de Uf e  colocar dentro da tabela Ufs, dentro do banco de dados
            UfSeeds.Ufs(modelBuilder);
        }
        
    }
}
