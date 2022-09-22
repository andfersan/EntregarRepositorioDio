using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Domain.Dtos.User
{
    public class UserDtoCreate
    {
        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        [StringLength(60, ErrorMessage = "O campo nome deve ter no máximo {1} caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email é campo obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        [StringLength(100, ErrorMessage = "Email deve ter no máximo {1} caracteres.")]
        public string Email { get; set; }
        public Guid Id { get; set; }
    }
}
