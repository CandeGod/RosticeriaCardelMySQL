using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosticeriaCardelV2.Clases
{
    public class VariacionProducto
    {
        public int IdVariacion { get; set; }
        public int IdProducto { get; set; }
        public string? NombreVariacion {  set; get; }
        public decimal Precio { set; get; }
        public bool Activo { set; get; }

        public VariacionProducto(int idVariacion, int idProducto, string nombreVariacion, decimal precio, bool activo)
        {
            IdVariacion = idVariacion;
            IdProducto = idProducto;
            NombreVariacion = nombreVariacion;
            Precio = precio;
            Activo = activo;
        }
    }
}
