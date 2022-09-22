using Api_Domain.Entities;
using Api_Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Domain.Repository
{
    // Usa IRepository como base, usa todos os metodos de IRepository 
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<UserEntity> FindByLogin(string email);

    }
}
