using Api_Domain.Dtos.Uf;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Domain.Dtos.Municipio
{
    // DataAnnotations usado apenas nos metodos Post  e Put 
    public class MunicipioDtoCreate
    {
        [Required(ErrorMessage = "Nome de município é campo obrigratório.")]
        [StringLength(60, ErrorMessage = "Nome de município deve ter no máximo {1} caracteres.")]
        public string Nome { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = " Código do IBGE inválido")]
        public int CodIBGE { get; set; }
        [Required(ErrorMessage = "Código de Uf é campo obrigatório")]
        public Guid UfId { get; set; }
      
    }
}
