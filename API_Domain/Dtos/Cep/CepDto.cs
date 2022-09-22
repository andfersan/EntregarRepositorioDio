using Api_Domain.Dtos.Municipio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Domain.Dtos.Cep
{
    public class CepDto
    {
        public Guid Id { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public Guid MunicipioId { get; set; }
        public MunicipioDtoCompleto Municipio { get; set; }

    }
}
