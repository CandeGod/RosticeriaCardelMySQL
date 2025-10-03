using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosticeriaCardelV2.Clases
{
    public class Gasto
    {
        public int IdGasto { get; set; }
        public int IdCorte { get; set; }
        public string? Concepto { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
    }
}
