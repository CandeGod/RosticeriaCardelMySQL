using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosticeriaCardelV2.Clases
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public decimal? MontoPagado { get; set; }
        public decimal? Cambio { get; set; }

        // Constructor por defecto
        public Venta() { }

        // Constructor con parámetros
        public Venta(int idVenta, DateTime fecha, decimal total, decimal? montoPagado = null, decimal? cambio = null)
        {
            IdVenta = idVenta;
            Fecha = fecha;
            Total = total;
            MontoPagado = montoPagado;
            Cambio = cambio;
        }

        // Constructor sin IdVenta (para cuando es una nueva venta)
        public Venta(DateTime fecha, decimal total, decimal? montoPagado = null, decimal? cambio = null)
        {
            Fecha = fecha;
            Total = total;
            MontoPagado = montoPagado;
            Cambio = cambio;
        }
    }

}
