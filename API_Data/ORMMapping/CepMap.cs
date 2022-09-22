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
    public class CepMap : IEntityTypeConfiguration<CepEntity>
    {
        public void Configure(EntityTypeBuilder<CepEntity> builder)
        {
            builder.ToTable("Cep");
            //Chave primaria
            builder.HasKey(u => u.Id);

            builder.HasIndex(u => u.Cep);
            //Identificar que é uma ForenKey - um cep possui um municipio e um municipio possue varios ceps.
            builder.HasOne(c => c.Municipio).WithMany(m => m.Ceps);
        }
    }
}
