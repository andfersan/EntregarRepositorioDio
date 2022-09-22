using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Domain.Entities
{
    // Torna uma classe abstrata por ser herdada em outra classe
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        
        private DateTime? _createAt;

        public DateTime? CreateAt
        {
            get { return  _createAt; }
            // Se valor nulo, vai receber o datetime utcnow, caso nao venha nulo, passa o valor do parâmetro.
            set { _createAt = (value == null ? DateTime.UtcNow : value); }
        }
        // Quando Atualizar gera uma data atual
        public DateTime? UpdateAt { get; set; }
    }
}
