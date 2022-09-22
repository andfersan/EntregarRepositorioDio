using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Domain.Entities
{
    public class UfEntity : BaseEntity
    {
        [Required]
        [MaxLength(2)]
        public string Sigla { get; set; }
        [Required]
        [MaxLength(45)]
        public string Nome { get; set; }
        // Identifica que posso ter uma lista de municipios
        public IEnumerable<MunicipioEntity> Municipios { get; set; }
    }
}
