
using RosticeriaCardel;
using RosticeriaCardelV2.Clases;
using RosticeriaCardelV2.Contenedores;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RosticeriaCardelV2.Formularios
{
    public partial class FrmProductos : Form
    {
        private ProductoRepository _productoRepository;

        public FrmProductos()
        {
            InitializeComponent();

            // Instanciamos DatabaseConnection y lo pasamos a ProductoRepository
            DatabaseConnection databaseConnection = new DatabaseConnection();
            _productoRepository = new ProductoRepository(databaseConnection);

            txtPrecio.KeyPress += txtPrecio_KeyPress;
            btnEdit.Enabled = false;
            btnDeleteImage.Enabled = false;
            Task.Run(() => _productoRepository.SyncProductosToCloudAsync());
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            dgvProductos.DataSource = LlenarDGV();
            txtNombreProducto.Focus();

        }

        public DataTable LlenarDGV()
        {
            List<Producto> productos = _productoRepository.GetAllProductos();

            // Convertir la lista de productos en un DataTable
            DataTable dt = new DataTable();
            dt.Columns.Add("IdProducto", typeof(int));
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("Precio", typeof(decimal));
            dt.Columns.Add("Stock", typeof(decimal));
            dt.Columns.Add("Activo", typeof(bool));


            foreach (var producto in productos)
            {
                dt.Rows.Add(producto.IdProducto, producto.Nombre, producto.Precio, producto.Stock, producto.Activo);
            }

            return dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombreProducto.Text) || string.IsNullOrEmpty(txtPrecio.Text) || string.IsNullOrEmpty(txtStock.Text))
            {
                MessageBox.Show("Completa todos los campos.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var result = MessageBox.Show("¿Estás seguro de que deseas agregar este producto?", "Confirmar Agregar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        Producto p = new Producto()
                        {
                            Nombre = txtNombreProducto.Text,
                            Precio = decimal.Parse(txtPrecio.Text),
                            Stock = decimal.Parse(txtStock.Text),
                            Activo = chkActivo.Checked,
                            Imagen = pbImageProducto.Image != null ? ConvertImageToByteArray(pbImageProducto.Image) : null
                        };

                        _productoRepository.AddProducto(p);

                        dgvProductos.DataSource = LlenarDGV();
                        limpiar();

                        MessageBox.Show("Producto agregado con éxito.", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al agregar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombreProducto.Text) || string.IsNullOrEmpty(txtPrecio.Text))
            {
                MessageBox.Show("Completa todos los campos.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var result = MessageBox.Show("¿Estás seguro de que deseas editar este producto?", "Confirmar Edición", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        Producto p = new Producto()
                        {
                            IdProducto = int.Parse(txtIdProducto.Text),
                            Nombre = txtNombreProducto.Text,
                            Precio = decimal.Parse(txtPrecio.Text),
                            Stock = decimal.Parse(txtStock.Text),
                            Activo = chkActivo.Checked,
                            Imagen = pbImageProducto.Image != null ? ConvertImageToByteArray(pbImageProducto.Image) : null
                        };

                        _productoRepository.UpdateProducto(p);

                        dgvProductos.DataSource = LlenarDGV();
                        limpiar();
                        MessageBox.Show("Producto actualizado con éxito.", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnAdd.Enabled = true;
                        btnEdit.Enabled = false;
                        btnDeleteImage.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al actualizar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdProducto.Text))
            {
                MessageBox.Show("Primero seleccione un producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var result = MessageBox.Show("¿Estás seguro de que deseas eliminar este producto?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int idProducto = int.Parse(txtIdProducto.Text);

                        _productoRepository.DeleteProducto(idProducto);

                        MessageBox.Show("Producto eliminado con éxito.", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        dgvProductos.DataSource = LlenarDGV();
                        limpiar();
                        btnAdd.Enabled = true;
                        btnEdit.Enabled = false;
                        btnDeleteImage.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            limpiar();
            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnDeleteImage.Enabled = false;
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvProductos.Rows[e.RowIndex];
                    txtIdProducto.Text = row.Cells["IdProducto"].Value?.ToString();
                    txtNombreProducto.Text = row.Cells["Nombre"].Value?.ToString();
                    txtPrecio.Text = row.Cells["Precio"].Value?.ToString();
                    txtStock.Text = row.Cells["Stock"].Value?.ToString();
                    chkActivo.Checked = (bool)row.Cells["Activo"].Value;

                    // Obtener el ID del producto seleccionado
                    int idProducto = Convert.ToInt32(row.Cells["IdProducto"].Value);

                    // Cargar la imagen desde el repositorio
                    byte[] imagenBytes = _productoRepository.GetImagenById(idProducto);
                    if (imagenBytes != null)
                    {
                        using (MemoryStream ms = new MemoryStream(imagenBytes))
                        {
                            pbImageProducto.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        pbImageProducto.Image = null; // Limpiar el PictureBox si no hay imagen
                    }

                    btnDeleteImage.Enabled = true;
                    btnAdd.Enabled = false;
                    btnEdit.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la información del producto: " + ex.Message);
            }
        }


        private void limpiar()
        {
            txtIdProducto.Clear();
            txtNombreProducto.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            chkActivo.Checked = false; // Reiniciar el CheckBox
            txtNombreProducto.Focus();
            pbImageProducto.Image = null;
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Obtener el texto actual en el TextBox
            string currentText = txtPrecio.Text;

            // Permitir solo números, un punto y controlar la tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Ignorar la tecla
                return;
            }

            // Permitir solo un punto decimal
            if (e.KeyChar == '.' && currentText.Contains("."))
            {
                e.Handled = true;
                return;
            }

            // Restringir a 4 dígitos antes del punto decimal
            if (char.IsDigit(e.KeyChar))
            {
                if (currentText.Contains("."))
                {
                    string[] parts = currentText.Split('.');
                    // Restringir a dos dígitos después del punto decimal
                    if (txtPrecio.SelectionStart > currentText.IndexOf('.') && parts[1].Length >= 2)
                    {
                        e.Handled = true;
                        return;
                    }
                }
                else if (currentText.Length >= 4)
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números, un punto y controlar la tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Ignorar la tecla
                return;
            }

            // Obtener el texto actual en el TextBox
            string currentText = txtStock.Text;

            // Permitir solo un punto decimal
            if (e.KeyChar == '.' && currentText.Contains("."))
            {
                e.Handled = true;
                return;
            }

            // Permitir solo dos dígitos después del punto decimal
            if (currentText.Contains("."))
            {
                string[] parts = currentText.Split('.');
                if (parts.Length == 2)
                {
                    // Restringir a dos dígitos después del punto decimal
                    if (parts[1].Length >= 2 && e.KeyChar != '\b')
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }

            // Restringir la longitud a 4 dígitos antes del punto decimal
            if (char.IsDigit(e.KeyChar))
            {
                if (!currentText.Contains(".") && currentText.Length >= 4)
                {
                    e.Handled = true;
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVariacion_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmAgregarVariacion frm = new FrmAgregarVariacion();
            frm.ShowDialog();
            this.Show();
        }

        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                Producto p = new Producto();
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.Title = "Seleccionar imagen del producto";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Intenta cargar la imagen
                        string imagePath = openFileDialog.FileName;

                        // Verifica que el archivo exista y que la ruta sea válida
                        if (File.Exists(imagePath))
                        {
                            // Cargar la imagen en un PictureBox o en la propiedad del producto
                            p.Imagen = ImageToByteArray(new Bitmap(imagePath));
                            pbImageProducto.Image = new Bitmap(imagePath); // muestra la imagen en un PictureBox
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el archivo especificado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar la imagen: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }


        private byte[] ConvertImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        private void btnDeleteImage_Click(object sender, EventArgs e)
        {
            pbImageProducto.Image = null;
        }
    }
}
