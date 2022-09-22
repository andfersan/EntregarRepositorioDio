using Api_Domain.Dtos.Uf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Domain.Interfaces.Services.Uf
{
    public interface IUfService
    {
        // Buscar Guid id e retorna UfDto
        Task<UfDto> Get(Guid id);
        Task<IEnumerable<UfDto>> GetAll();

    }
}
