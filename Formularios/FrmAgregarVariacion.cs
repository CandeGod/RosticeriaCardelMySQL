using RosticeriaCardel;
using RosticeriaCardelV2.Clases;
using RosticeriaCardelV2.Contenedores;
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
        public partial class FrmAgregarVariacion : Form
        {
        
                private ProductoRepository _productoRepository;
                private VariacionProductoRepository _variacionProductoRepository;

                public FrmAgregarVariacion()
                {
                    InitializeComponent();
                    DatabaseConnection databaseConnection = new DatabaseConnection();
                    _productoRepository = new ProductoRepository(databaseConnection);
                    _variacionProductoRepository = new VariacionProductoRepository(databaseConnection);
                    LlenarComboBoxProductos();
                }

            private void LlenarComboBoxProductos()
            {
                List<Producto> productos = _productoRepository.GetAllProductos();
                foreach (var producto in productos)
                {
                    cbProductos.Items.Add(new ComboBoxItem { Id = producto.IdProducto, Text = producto.Nombre });
                }
            }

            private void btnAddVariacion_Click(object sender, EventArgs e)
            {
                if (string.IsNullOrEmpty(txtNombreVariacion.Text) || cbProductos.SelectedItem == null)
                {
                    MessageBox.Show("Completa todos los campos.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedProducto = (ComboBoxItem)cbProductos.SelectedItem;
                var result = MessageBox.Show($"¿Estás seguro de que deseas agregar esta variación al producto {selectedProducto.Text}?", "Confirmar Agregar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        VariacionProducto variacion = new VariacionProducto(
                            0, // Asigna un ID nuevo en la base de datos
                            selectedProducto.Id,
                            txtNombreVariacion.Text,
                            decimal.Parse(txtPrecioVariacion.Text),
                            chkActivo.Checked
                        );

                        _variacionProductoRepository.AddVariacion(variacion);
                        // Aquí disminuye el stock del producto padre
                        //_variacionProductoRepository.DisminuirStockProducto(selectedProducto.Id);

                        MessageBox.Show("Variación agregada con éxito.", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al agregar la variación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public class ComboBoxItem
        {
            public int Id { get; set; }
            public string Text { get; set; }

            public override string ToString() => Text;
        }
    }
