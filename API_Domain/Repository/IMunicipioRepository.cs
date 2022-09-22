using Api_Domain.Entities;
using Api_Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Domain.Repository
{
    public interface IMunicipioRepository : IRepository<MunicipioEntity>
    {

        Task<MunicipioEntity> GetCompleteById(Guid id);
        Task<MunicipioEntity> GetCompleteByIBGE(int codIBGE);
    }
}
