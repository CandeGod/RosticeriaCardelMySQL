using RosticeriaCardelV2.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RosticeriaCardelV2.Controls
{
    public partial class UcComplements : UserControl
    {
        private Producto _producto;

        public Producto Producto
        {
            get { return _producto; }
            set
            {
                _producto = value;
                if (_producto != null)
                {
                    // Verificar si el producto está activo
                    if (!_producto.Activo) // Cambia a esta línea si Activo es bool
                    {
                        this.Visible = false; // Oculta el UserControl si el producto está inactivo
                    }
                    else
                    {
                        lblNameOfProduct.Text = _producto.Nombre;
                        lblPrice.Text = "" + _producto.Precio.ToString("C2");
                        lblStock.Text = "Stock: " + _producto.Stock.ToString();
                        this.Visible = true; // Asegúrate de que el UserControl se muestre si está activo
                    }

                    if (_producto.Imagen != null)
                    {
                        using (var ms = new MemoryStream(_producto.Imagen))
                        {
                            pbImage.Image = Image.FromStream(ms);
                        }
                    }
                }
            }
        }


        public int Amount { get; set; }

        public UcComplements()
        {
            InitializeComponent();
            Amount = 0;
            _producto = new Producto(); // Inicializa _producto para evitar NullReferenceException
            UpdateAmount();
        }

        private void btnIncreaseProduct_Click(object sender, EventArgs e)
        {
            Amount++;
            _producto.Stock--;
            UpdateAmount();
            UpdatePrice(); // Actualiza el precio al aumentar la cantidad
        }

        private void btnDecreaseProduct_Click(object sender, EventArgs e)
        {
            if (Amount > 0)
            {
                Amount--;
                _producto.Stock++;
                UpdateAmount();
                UpdatePrice(); // Actualiza el precio al disminuir la cantidad
            }
        }

        public void UpdateAmount()
        {
            lblAmount.Text = "" + Amount.ToString();
            if (_producto != null)
            {
                lblStock.Text = "Stock: " + _producto.Stock.ToString();
            }
        }

        private void UpdatePrice()
        {
            if (_producto != null && Amount > 0)
            {
                decimal totalPrice = _producto.Precio * Amount; // Calcula el precio total
                lblTotal.Text = totalPrice.ToString("C2"); // Actualiza el lblPrice con el nuevo precio total
            }
            else
            {
                lblTotal.Text = "0.00"; // Si no hay cantidad, muestra 0
            }
        }

    }

}

