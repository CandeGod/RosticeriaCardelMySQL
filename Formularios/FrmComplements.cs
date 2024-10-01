using RosticeriaCardel;
using RosticeriaCardelV2.Contenedores;
using RosticeriaCardelV2.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RosticeriaCardelV2.Formularios
{
    public partial class FrmComplements : Form
    {

        // Delegado para pasar productos al carrito
        public delegate void AgregarProductoAlCarritoHandler(int idProducto, decimal cantidad);
        public event AgregarProductoAlCarritoHandler AgregarProductoAlCarrito;

        public FrmComplements()
        {
            InitializeComponent();
        }

        private void FrmComplements_Load(object sender, EventArgs e)
        {
            var productoRepository = new ProductoRepository(new DatabaseConnection());
            var productos = productoRepository.GetAllProductos();

            foreach (var producto in productos)
            {
                // Verificar si el IdProducto es 1, 2 o 3, y omitir estos productos
                if (producto.IdProducto == 1 || producto.IdProducto == 2 || producto.IdProducto == 3)
                {
                    continue; // Saltar la iteración si el producto tiene un IdProducto de 1, 2, o 3
                }

                var control = new UcComplements
                {
                    Producto = producto
                };

                FlpComplements.Controls.Add(control);
            }
        }


        private void btnAccept_Click(object sender, EventArgs e)
        {
            foreach (UcComplements control in FlpComplements.Controls.OfType<UcComplements>())
            {
                if (control.Amount > 0)
                {
                    // Pasar el id del producto y la cantidad seleccionada al método AgregarProductoAlCarrito
                    AgregarProductoAlCarrito?.Invoke(control.Producto.IdProducto, control.Amount);
                }
            }
            // Cerrar el formulario después de aceptar
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
