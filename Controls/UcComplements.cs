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
                        lblPrice.Text = "Precio: " + _producto.Precio.ToString("C2");
                        lblStock.Text = "Stock: " + _producto.Stock.ToString();
                        this.Visible = true; // Asegúrate de que el UserControl se muestre si está activo
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
        }

        private void btnDecreaseProduct_Click(object sender, EventArgs e)
        {
            if (Amount > 0)
            {
                Amount--;
                _producto.Stock++;
                UpdateAmount();
            }
        }

        public void UpdateAmount()
        {
            lblAmount.Text = "Cantidad: " + Amount.ToString();
            if (_producto != null)
            {
                lblStock.Text = "Stock: " + _producto.Stock.ToString();
            }
        }
    }

}

