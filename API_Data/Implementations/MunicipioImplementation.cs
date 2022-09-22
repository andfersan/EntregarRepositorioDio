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
    public class MunicipioImplementation : BaseRepository<MunicipioEntity>, IMunicipioRepository
    {
        private DbSet<MunicipioEntity> _dataset;
        public MunicipioImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<MunicipioEntity>();

        }

        public async Task<MunicipioEntity> GetCompleteByIBGE(int codIBGE)
        {
            return await _dataset.Include(m => m.Uf).FirstOrDefaultAsync(m => m.CodIBGE.Equals(codIBGE));
        }

        public async  Task<MunicipioEntity> GetCompleteById(Guid id)
        {
            return await _dataset.Include(m => m.Uf).FirstOrDefaultAsync(m => m.Id.Equals(id));
        }
    }
}
