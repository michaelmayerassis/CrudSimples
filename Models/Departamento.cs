using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Prova.Models
{
    [Table("DEPARTAMENTO")]
    public class Departamento
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(60)]
        public string Nome { get; set; }

        [Required]
        [StringLength(40)]
        public string Cidade { get; set; }

        public int Fg_Ativo { get; set; }
    }
}
