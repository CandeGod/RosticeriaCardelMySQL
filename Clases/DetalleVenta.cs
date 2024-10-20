using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosticeriaCardelV2.Clases
{
    public class DetalleVenta
    {
        public int IdDetalleVenta { get; set; }
        public int IdVenta { get; set; }
        public int IdProducto { get; set; }
        public int IdVariacionProducto { get; set; }
        public string NombreVariacion { get; set; } 
        public decimal Cantidad { get; set; }
        public decimal Subtotal { get; set; }

        // Constructor por defecto
        public DetalleVenta() { }

        // Constructor con parámetros
        public DetalleVenta(int idDetalleVenta, int idVenta, int idProducto, int idVariacionProducto, string nombreVariacion, decimal cantidad, decimal subtotal)
        {
            IdDetalleVenta = idDetalleVenta;
            IdVenta = idVenta;
            IdProducto = idProducto;
            IdVariacionProducto = idVariacionProducto;
            NombreVariacion = nombreVariacion;
            Cantidad = cantidad;
            Subtotal = subtotal;
        }

        // Constructor sin IdDetalleVenta (para cuando es un nuevo detalle de venta)
        public DetalleVenta(int idVenta, int idProducto, int idVariacionProducto, string nombreVariacion, decimal cantidad, decimal subtotal)
        {
            IdVenta = idVenta;
            IdProducto = idProducto;
            IdVariacionProducto = idVariacionProducto;
            NombreVariacion = nombreVariacion;
            Cantidad = cantidad;
            Subtotal = subtotal;
        }
    }

}
