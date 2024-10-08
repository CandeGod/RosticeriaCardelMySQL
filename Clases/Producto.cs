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
        public bool Activo { get; set; }

        public Producto()
        {
            Activo = true; 
        }

        
        public Producto(int idProducto, string nombre, decimal precio, decimal stock, bool activo)
        {
            IdProducto = idProducto;
            Nombre = nombre;
            Precio = precio;
            Stock = stock;
            Activo = activo; 
        }

        
        public Producto(string nombre, decimal precio, decimal stock)
        {
            Nombre = nombre;
            Precio = precio;
            Stock = stock;
            Activo = true; 
        }
    }
}
