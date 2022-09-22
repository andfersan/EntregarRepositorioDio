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
    public class UfImplementation : BaseRepository<UfEntity>, IUfRepository
    {
        private DbSet<UfEntity> _dataset;
        public UfImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<UfEntity>();

        }
        
    }
}
