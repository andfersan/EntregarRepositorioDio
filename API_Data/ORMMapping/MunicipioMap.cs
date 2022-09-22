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
    public class MunicipioMap : IEntityTypeConfiguration<MunicipioEntity>
    {
        public void Configure(EntityTypeBuilder<MunicipioEntity> builder)
        {
            builder.ToTable("Municipio");
            //Chave primaria
            builder.HasKey(u => u.Id);

            builder.HasIndex(u => u.CodIBGE);
            //Identificar que é uma ForenKey
            builder.HasOne(u => u.Uf).WithMany(m => m.Municipios);

            
        }
    }
}
