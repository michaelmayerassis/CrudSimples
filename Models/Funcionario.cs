using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Prova.Models
{
    [Table("FUNCIONARIO")]
    public class Funcionario
    {
        [Key]
        public Int32 Id { get; set; }

        [ForeignKey("DEPARTAMENTO")]
        [Column("Departamento_Id")]
        public Int32 DepartamentoId { get; set; }

        [Required]
        [StringLength(60)]
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        public DateTime Dt_Nascimento { get; set; }

        [DataType(DataType.Currency)]
        public decimal Salario { get; set; }

        [Required]
        [StringLength(60)]
        public string Cargo { get; set; }

        public int Fg_Ativo { get; set; }

        public virtual Departamento Departamento { get; set; }
    }
}
