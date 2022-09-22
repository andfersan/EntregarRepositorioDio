using Api_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Data.ORMMapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            // Configurar o nome da tabela
            builder.ToTable("User");

            builder.HasKey(u => u.Id);

            // não vai deixar gravar email repitido
            builder.HasIndex(u => u.Email)      
            .IsUnique();

            // obrigatoriedade em algum campo
            builder.Property(u => u.Name).IsRequired().HasMaxLength(60);

            builder.Property(u => u.Email).HasMaxLength(100);


        }
    }
}
