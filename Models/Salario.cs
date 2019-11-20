using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prova.Models
{
    public class Salario
    {
        public int id { get; set; }
        public decimal min_salario { get; set; }
        public decimal max_salario { get; set; }
        public int fg_ativo { get; set; }
    }
}
