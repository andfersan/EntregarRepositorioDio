using Api_Domain.Dtos.Uf;
using System;

namespace Api_Domain.Dtos.Municipio
{
    public class MunicipioDtoCompleto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int CodIBGE { get; set; }
        public Guid UfId { get; set; }
        public  UfDto Uf { get; set; }

    }
}
