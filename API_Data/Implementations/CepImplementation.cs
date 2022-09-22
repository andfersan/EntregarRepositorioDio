using Api_Data.Context;
using Api_Data.Repository_Data;
using Api_Domain.Entities;
using Api_Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Data.Implementations
{
    public class CepImplementation : BaseRepository<CepEntity>, ICepRepository
    {
        private DbSet<CepEntity> _dataset;
        public CepImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<CepEntity>();

        }

        public async Task<CepEntity> SelectAsync(string cep)
        {
            return await _dataset.Include(c => c.Municipio)
                                 .ThenInclude(m => m.Uf)
                                 .FirstOrDefaultAsync(u => u.Cep.Equals(cep));
        }
    }
}
