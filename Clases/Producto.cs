using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosticeriaCardelV2.Clases
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public decimal Stock {  get; set; }

        // Constructor por defecto
        public Producto() { }

        // Constructor con parámetros
        public Producto(int idProducto, string nombre, decimal precio, decimal stock)
        {
            IdProducto = idProducto;
            Nombre = nombre;
            Precio = precio;
            Stock = stock;
        }


        // Constructor con valores predeterminados
        public Producto(string nombre, decimal precio, decimal stock)
        {
            Nombre = nombre;
            Precio = precio;
            Stock = stock;
        }
    }
}
