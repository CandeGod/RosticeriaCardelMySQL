using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using RosticeriaCardel;
using RosticeriaCardelV2.Clases;
using RosticeriaCardelV2.Contenedores;
using RosticeriaCardelV2.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RosticeriaCardelV2.Formularios
{
    public partial class FrmPointOfSale : Form
    {

        private DatabaseConnection _databaseConnection;
        private VentaRepository _ventaRepository;
        private ProductoRepository _productoRepository;
        private DetalleVentaRepository _detalleVentaRepository;


        public FrmPointOfSale()
        {
            InitializeComponent();

            _databaseConnection = new DatabaseConnection();
            _ventaRepository = new VentaRepository(_databaseConnection);
            _productoRepository = new ProductoRepository(_databaseConnection);
            _detalleVentaRepository = new DetalleVentaRepository(_databaseConnection);
        }

        private void FrmPointOfSale_Load(object sender, EventArgs e)
        {
            dgvCart.Columns.Add("idProducto", "ID Producto");
            dgvCart.Columns.Add("Producto", "Producto");
            dgvCart.Columns.Add("Precio", "Precio");
            dgvCart.Columns.Add("Cantidad", "Cantidad");
            dgvCart.Columns.Add("SubTotal", "SubTotal");

            Complements();
        }

        //Metodo para el boton seleccionado
        private void ToggleButtonState(Guna2Button btn)
        {
            if (btn.BackColor == SystemColors.Control)
            {
                btn.BackColor = Color.LightBlue;
            }
            else
            {
                btn.BackColor = SystemColors.Control;
            }
        }

        public void DesmarcarNatural()
        {
            // Desmarcar todos los botones excepto btnHalf
            btnOneNatural.BackColor = SystemColors.Control;
            btnTwoNatural.BackColor = SystemColors.Control;
            btnHalfNatural.BackColor = SystemColors.Control;
        }

        public void DesmarcarAdobado()
        {
            // Desmarcar todos los botones excepto btnHalf
            btnOneAdobado.BackColor = SystemColors.Control;
            btnTwoAdobado.BackColor = SystemColors.Control;
            btnHalfAdobado.BackColor = SystemColors.Control;
        }

        public void DesmarcarChiltepin()
        {
            // Desmarcar todos los botones excepto btnHalf
            btnOneChiltepin.BackColor = SystemColors.Control;
            btnTwoChiltepin.BackColor = SystemColors.Control;
            btnHalfChiltepin.BackColor = SystemColors.Control;
        }

        private void btnHalfNatural_Click(object sender, EventArgs e)
        {
            ToggleButtonState(btnHalfNatural);
        }

        private void btnOneNatural_Click(object sender, EventArgs e)
        {
            ToggleButtonState(btnOneNatural);
            if (btnOneNatural.BackColor == Color.LightBlue)
            {
                // Desmarcar otros botones y el ComboBox
                btnTwoNatural.BackColor = SystemColors.Control;
                cbAmountNatural.SelectedIndex = -1;
            }
        }

        private void btnTwoNatural_Click(object sender, EventArgs e)
        {
            ToggleButtonState(btnTwoNatural);
            if (btnTwoNatural.BackColor == Color.LightBlue)
            {
                btnOneNatural.BackColor = SystemColors.Control;
                cbAmountNatural.SelectedIndex = -1;
            }
        }

        private void cbAmountNatural_SelectedIndexChanged(object sender, EventArgs e)
        {
            DesmarcarNatural();
        }

        private void btnHalfAdobado_Click(object sender, EventArgs e)
        {
            ToggleButtonState(btnHalfAdobado);
        }

        private void btnOneAdobado_Click(object sender, EventArgs e)
        {
            ToggleButtonState(btnOneAdobado);
            if (btnOneAdobado.BackColor == Color.LightBlue)
            {
                // Desmarcar otros botones y el ComboBox
                btnTwoAdobado.BackColor = SystemColors.Control;
                cbAmountAdobado.SelectedIndex = -1;
            }
        }

        private void btnTwoAdobado_Click(object sender, EventArgs e)
        {
            ToggleButtonState(btnTwoAdobado);
            if (btnTwoAdobado.BackColor == Color.LightBlue)
            {
                btnOneAdobado.BackColor = SystemColors.Control;
                cbAmountAdobado.SelectedIndex = -1;
            }
        }

        private void cbAmountAdobado_SelectedIndexChanged(object sender, EventArgs e)
        {
            DesmarcarAdobado();
        }

        private void btnHalfChiltepin_Click(object sender, EventArgs e)
        {
            ToggleButtonState(btnHalfChiltepin);
        }

        private void btnOneChiltepin_Click(object sender, EventArgs e)
        {
            ToggleButtonState(btnOneChiltepin);
            if (btnOneChiltepin.BackColor == Color.LightBlue)
            {
                // Desmarcar otros botones y el ComboBox
                btnTwoChiltepin.BackColor = SystemColors.Control;
                cbAmountChiltepin.SelectedIndex = -1;
            }
        }

        private void btnTwoChiltepin_Click(object sender, EventArgs e)
        {
            ToggleButtonState(btnTwoChiltepin);
            if (btnTwoChiltepin.BackColor == Color.LightBlue)
            {
                btnOneChiltepin.BackColor = SystemColors.Control;
                cbAmountChiltepin.SelectedIndex = -1;
            }
        }

        private void cbAmountChiltepin_SelectedIndexChanged(object sender, EventArgs e)
        {
            DesmarcarChiltepin();
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            bool itemAdded = false;

            // Verificar y agregar Pollo Natural al carrito
            if (btnOneNatural.BackColor == Color.LightBlue || btnTwoNatural.BackColor == Color.LightBlue || cbAmountNatural.SelectedIndex != -1 || btnHalfNatural.BackColor == Color.LightBlue)
            {
                AgregarProductoAlCarrito(1); // Pollo Natural con IdProducto = 1
                itemAdded = true;
            }

            // Verificar y agregar Pollo Adobado al carrito
            if (btnOneAdobado.BackColor == Color.LightBlue || btnTwoAdobado.BackColor == Color.LightBlue || cbAmountAdobado.SelectedIndex != -1 || btnHalfAdobado.BackColor == Color.LightBlue)
            {
                AgregarProductoAlCarrito(2); // Pollo Adobado con IdProducto = 2
                itemAdded = true;
            }

            // Verificar y agregar Pollo Chiltepin al carrito
            if (btnOneChiltepin.BackColor == Color.LightBlue || btnTwoChiltepin.BackColor == Color.LightBlue || cbAmountChiltepin.SelectedIndex != -1 || btnHalfChiltepin.BackColor == Color.LightBlue)
            {
                AgregarProductoAlCarrito(3); // Pollo Chiltepin con IdProducto = 3
                itemAdded = true;
            }

            foreach (UcComplements control in flpComplements.Controls.OfType<UcComplements>())
            {
                if (control.Amount > 0)
                {
                    int idProducto = control.Producto.IdProducto;

                    AgregarProductoAlCarrito(idProducto); 
                    itemAdded = true;
                }

                
                control.Amount = 0;
                control.UpdateAmount();
            }

           
            if (!itemAdded)
            {
                MessageBox.Show("Debe seleccionar al menos un producto antes de continuar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                
                ResetSelections();
            }
        }



        private void ResetSelections()
        {
            btnOneNatural.BackColor = SystemColors.Control;
            btnTwoNatural.BackColor = SystemColors.Control;
            btnHalfNatural.BackColor = SystemColors.Control;
            cbAmountNatural.SelectedIndex = -1;

            btnOneAdobado.BackColor = SystemColors.Control;
            btnTwoAdobado.BackColor = SystemColors.Control;
            btnHalfAdobado.BackColor = SystemColors.Control;
            cbAmountAdobado.SelectedIndex = -1;

            btnOneChiltepin.BackColor = SystemColors.Control;
            btnTwoChiltepin.BackColor = SystemColors.Control;
            btnHalfChiltepin.BackColor = SystemColors.Control;
            cbAmountChiltepin.SelectedIndex = -1;
        }

        private void AgregarProductoAlCarrito(int idProducto)
        {
            // Obtener el producto desde el repositorio
            ProductoRepository productoRepository = new ProductoRepository(new DatabaseConnection());
            Producto producto = productoRepository.GetProductoById(idProducto);

            if (producto != null)
            {
                // Determinar la cantidad seleccionada
                decimal cantidad = 0;
                decimal precio = producto.Precio;
                string nombre = producto.Nombre;

                // Obtener la cantidad del ComboBox, si está seleccionado
                decimal comboBoxCantidad = 0;
                if (idProducto == 1 && cbAmountNatural.SelectedIndex != -1)
                {
                    comboBoxCantidad = Convert.ToDecimal(cbAmountNatural.SelectedItem);
                }
                else if (idProducto == 2 && cbAmountAdobado.SelectedIndex != -1)
                {
                    comboBoxCantidad = Convert.ToDecimal(cbAmountAdobado.SelectedItem);
                }
                else if (idProducto == 3 && cbAmountChiltepin.SelectedIndex != -1)
                {
                    comboBoxCantidad = Convert.ToDecimal(cbAmountChiltepin.SelectedItem);
                }

                // Combinar cantidad del ComboBox con las selecciones de botones
                if (idProducto == 1) // Pollo Natural
                {
                    if (btnHalfNatural.BackColor == Color.LightBlue) cantidad += 0.5m;
                    if (btnOneNatural.BackColor == Color.LightBlue) cantidad += 1;
                    if (btnTwoNatural.BackColor == Color.LightBlue) cantidad += 2;
                    cantidad += comboBoxCantidad; // Sumar la cantidad del ComboBox
                }
                else if (idProducto == 2) // Pollo Adobado
                {
                    if (btnHalfAdobado.BackColor == Color.LightBlue) cantidad += 0.5m;
                    if (btnOneAdobado.BackColor == Color.LightBlue) cantidad += 1;
                    if (btnTwoAdobado.BackColor == Color.LightBlue) cantidad += 2;
                    cantidad += comboBoxCantidad; // Sumar la cantidad del ComboBox
                }
                else if (idProducto == 3) // Pollo Chiltepin
                {
                    if (btnHalfChiltepin.BackColor == Color.LightBlue) cantidad += 0.5m;
                    if (btnOneChiltepin.BackColor == Color.LightBlue) cantidad += 1;
                    if (btnTwoChiltepin.BackColor == Color.LightBlue) cantidad += 2;
                    cantidad += comboBoxCantidad; // Sumar la cantidad del ComboBox
                }

                // --- AÑADIR CANTIDAD DEL USERCONTROL ---
                // Recorre los controles en el FlowLayoutPanel y añade la cantidad del UserControl
                foreach (UcComplements control in flpComplements.Controls.OfType<UcComplements>())
                {
                    if (control.Producto.IdProducto == idProducto && control.Amount > 0)
                    {
                        cantidad += control.Amount; // Sumar la cantidad del UserControl
                        break; // Salir del bucle una vez encontrado
                    }
                }

                // Verificar si el producto ya está en el carrito
                foreach (DataGridViewRow row in dgvCart.Rows)
                {
                    if (Convert.ToInt32(row.Cells["idProducto"].Value) == idProducto)
                    {
                        // Actualizar cantidad y subtotal si el producto ya existe
                        decimal existingQuantity = Convert.ToDecimal(row.Cells["Cantidad"].Value);
                        decimal existingSubtotal = Convert.ToDecimal(row.Cells["SubTotal"].Value);

                        row.Cells["Cantidad"].Value = existingQuantity + cantidad;
                        row.Cells["SubTotal"].Value = existingSubtotal + (cantidad * precio);
                        UpdateTotalSale();
                        return;
                    }
                }

                // Si el producto no está en el carrito, añadirlo
                decimal subtotal = cantidad * precio;
                dgvCart.Rows.Add(idProducto, nombre, precio, cantidad, subtotal);
                UpdateTotalSale();
            }
            else
            {
                MessageBox.Show("El producto seleccionado no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateTotalSale()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                total += Convert.ToDecimal(row.Cells["Subtotal"].Value);
            }
            lblTotal.Text = $" {total:C}";
        }

        private void btnDeleteArticle_Click(object sender, EventArgs e)
        {
            if (dgvCart.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar el artículo seleccionado?",
                                                      "Confirmación de eliminación",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dgvCart.SelectedRows)
                    {
                        dgvCart.Rows.RemoveAt(row.Index);
                    }
                    UpdateTotalSale();
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un articulo para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnCancelSale_Click(object sender, EventArgs e)
        {
            if (dgvCart.Rows.Count == 0)
            {
                MessageBox.Show("No hay ventas por eliminar");
            }
            else
            {
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar esta venta?",
                                                          "Confirmación de eliminación",
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    dgvCart.Rows.Clear();
                    UpdateTotalSale();
                }
            }
        }


        private void btnPay_Click(object sender, EventArgs e)
        {
            if (dgvCart.Rows.Count <= 0)
            {
                MessageBox.Show("El carrito está vacío. Por favor, agregue productos antes de proceder con el pago.", "Carrito vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                decimal totalCarrito = CalcularTotalCarrito();

                string input = Microsoft.VisualBasic.Interaction.InputBox(
                    $"El total es {totalCarrito:C}. Ingrese la cantidad de dinero que el cliente proporciono:",
                    "Pago",
                    "0");

                if (string.IsNullOrEmpty(input))
                {
                    MessageBox.Show("El pago fue cancelado.", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (!decimal.TryParse(input, out decimal montoPagado))
                {
                    MessageBox.Show("Monto pagado inválido. Por favor, ingrese un valor numérico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                decimal cambio = CalcularCambio(montoPagado, totalCarrito);

                if (cambio < 0)
                {
                    MessageBox.Show("El monto pagado es insuficiente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Venta venta = new Venta
                {
                    Fecha = DateTime.Now,
                    Total = totalCarrito,
                    MontoPagado = montoPagado,
                    Cambio = cambio
                };

                try
                {
                    using (MySqlConnection connection = _databaseConnection.GetConnection())
                    {
                        using (MySqlTransaction transaction = connection.BeginTransaction())
                        {
                            try
                            {
                                // Añadir venta
                                int idVenta = _ventaRepository.AddVenta(venta, connection, transaction);

                                // Obtener detalles de la venta
                                var detalles = ObtenerDetallesVenta(idVenta);

                                // Listas para almacenar los productos, cantidades, precios, y subtotales
                                List<string> nombresProductos = new List<string>();
                                List<decimal> cantidades = new List<decimal>();
                                List<decimal> precios = new List<decimal>();
                                List<decimal> subtotales = new List<decimal>();

                                // Lista para acumular IDs de productos sin suficiente stock
                                List<int> productosSinStock = new List<int>();

                                // Añadir detalles de venta
                                foreach (DetalleVenta detalle in detalles)
                                {
                                    try
                                    {
                                        // Verificar que haya suficiente stock antes de proceder con la venta
                                        if (!_productoRepository.HayStockSuficiente(detalle.IdProducto, detalle.Cantidad, connection, transaction))
                                        {
                                            productosSinStock.Add(detalle.IdProducto);
                                        }

                                        // Obtener información del producto a partir del IdProducto
                                        Producto producto = _productoRepository.GetProductoById(detalle.IdProducto);

                                        if (producto != null)
                                        {
                                            nombresProductos.Add(producto.Nombre);
                                            cantidades.Add(detalle.Cantidad);
                                            precios.Add(producto.Precio);
                                            subtotales.Add(detalle.Subtotal);

                                            // Guardar el detalle de venta en la base de datos
                                            _detalleVentaRepository.AddDetalleVenta(detalle, idVenta, connection, transaction);

                                            // Disminuir el stock del producto
                                            _productoRepository.DecreaseStock(detalle.IdProducto, detalle.Cantidad, connection, transaction);
                                        }
                                        else
                                        {
                                            MessageBox.Show($"Producto con ID {detalle.IdProducto} no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show($"Error al procesar el producto con ID {detalle.IdProducto}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }

                                // Si hay productos sin stock suficiente, mostrar mensaje y hacer rollback
                                if (productosSinStock.Any())
                                {
                                    string idsProductos = string.Join(", ", productosSinStock);
                                    MessageBox.Show($"No hay suficiente stock para los productos con ID: {idsProductos}.", "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    transaction.Rollback();
                                    return;
                                }

                                // Confirmar transacción
                                transaction.Commit();

                                // Imprimir el ticket
                                PrintTicket(idVenta, totalCarrito, nombresProductos, cantidades, precios, subtotales, montoPagado, cambio);

                                MessageBox.Show($"Venta registrada con éxito. Cambio: {cambio:C}", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LimpiarFormulario();
                            }
                            catch (Exception ex)
                            {
                                // Rollback en caso de error
                                transaction.Rollback();
                                MessageBox.Show($"Error al registrar la venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error en el proceso de pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en el proceso de pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private decimal CalcularTotalCarrito()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                if (row.Cells["Subtotal"].Value != null)
                {
                    total += Convert.ToDecimal(row.Cells["Subtotal"].Value);
                }
            }
            return total;
        }

        private decimal CalcularCambio(decimal montoPagado, decimal totalCarrito)
        {
            return montoPagado - totalCarrito;
        }

        private List<DetalleVenta> ObtenerDetallesVenta(int idVenta)
        {
            List<DetalleVenta> detalles = new List<DetalleVenta>();
            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                if (row.Cells["IdProducto"].Value != null)
                {
                    detalles.Add(new DetalleVenta
                    {
                        IdProducto = Convert.ToInt32(row.Cells["IdProducto"].Value),
                        Cantidad = Convert.ToDecimal(row.Cells["Cantidad"].Value),
                        Subtotal = Convert.ToDecimal(row.Cells["Subtotal"].Value)
                    });
                }
            }
            return detalles;
        }

        private void LimpiarFormulario()
        {
            dgvCart.Rows.Clear();
            lblTotal.Text = "$00.00";
        }


        private void PrintTicket(int idVenta, decimal total, List<string> productos, List<decimal> cantidades, List<decimal> precios, List<decimal> subtotales, decimal montoPago, decimal cambio)
        {
            StringBuilder ticket = new StringBuilder();

            // Ancho máximo de la línea del ticket
            int descripcionWidth = 20;
            int cantidadWidth = 8;
            int subtotalWidth = 10;

            int descripcionWidthT = 14;
            int cantidadWidthT = 11;
            int subtotalWidthT = 10;

            // Encabezado del ticket
            ticket.AppendLine("==========================================");
            ticket.AppendLine("         Rosticería Cardel");
            ticket.AppendLine("    Fecha: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            ticket.AppendLine("    Orden #" + idVenta);
            ticket.AppendLine("==========================================");
            ticket.AppendLine($"{"Descripción".PadRight(descripcionWidthT)}{"Cantidad".PadRight(cantidadWidthT)}{"Subtotal".PadRight(subtotalWidthT)}");

            // Detalles de la venta
            for (int i = 0; i < productos.Count; i++)
            {
                string producto = productos[i];
                string cantidad = cantidades[i].ToString().PadLeft(3);
                string subtotal = subtotales[i].ToString("C2").PadLeft(subtotalWidth);

                ticket.AppendLine($"{producto.PadRight(descripcionWidthT)}{cantidad.PadRight(cantidadWidthT)}{subtotal}");
                ticket.AppendLine(new string('-', 42));
            }

            // Total de la venta
            ticket.AppendLine($"TOTAL: {total.ToString("C2").PadLeft(30)}");
            ticket.AppendLine($"PAGO:  {montoPago.ToString("C2").PadLeft(30)} CAMBIO: {cambio.ToString("C2").PadLeft(30)}");

            ticket.AppendLine("==========================================");
            ticket.AppendLine("   Gracias por su compra!");
            ticket.AppendLine("==========================================");

            // Impresión del ticket
            try
            {
                System.Drawing.Printing.PrintDocument printDoc = new System.Drawing.Printing.PrintDocument();
                printDoc.PrintPage += (s, ev) =>
                {
                    // Cargar la imagen (asegúrate de que la ruta es correcta)
                    Image logo = Image.FromFile(@"C:\Users\cande\Downloads\RosticeríaSabrosonPNG (3).png"); // Reemplaza con la ruta de tu imagen

                    // Calcular la posición para centrar la imagen
                    float imageWidth = logo.Width;
                    float pageWidth = ev.PageBounds.Width;
                    float xPos = (pageWidth - imageWidth) / 2; // Centrar horizontalmente

                    // Dibujar la imagen
                    ev.Graphics.DrawImage(logo, (xPos + 20), 0); // Ajusta el margen superior aquí si es necesario

                    // Definir la fuente y el formato para el texto
                    Font regularFont = new Font("Consolas", 8);
                    Font boldFont = new Font("Consolas", 10, FontStyle.Bold);
                    float yPos = logo.Height + 0; // Espacio después de la imagen
                    float leftMargin = 10;

                    // Dibuja el contenido del ticket
                    /*ev.Graphics.DrawString(new string('=', 42), regularFont, Brushes.Black, new PointF(leftMargin, yPos));
                    yPos += regularFont.GetHeight(ev.Graphics);*/
                    ev.Graphics.DrawString("      Rosticería el sabrosón", boldFont, Brushes.Black, new PointF(leftMargin, yPos));
                    yPos += boldFont.GetHeight(ev.Graphics);
                    ev.Graphics.DrawString("        Fecha: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), regularFont, Brushes.Black, new PointF(leftMargin, yPos));
                    yPos += regularFont.GetHeight(ev.Graphics);
                    ev.Graphics.DrawString("            Orden #" + idVenta, boldFont, Brushes.Black, new PointF(leftMargin, yPos));
                    yPos += boldFont.GetHeight(ev.Graphics);
                    ev.Graphics.DrawString(new string('=', 42), regularFont, Brushes.Black, new PointF(leftMargin, yPos));
                    yPos += regularFont.GetHeight(ev.Graphics);
                    ev.Graphics.DrawString($"{"Descripción".PadRight(descripcionWidthT)}{"Cantidad".PadRight(cantidadWidthT)}{"Subtotal".PadRight(subtotalWidthT)}", boldFont, Brushes.Black, new PointF(leftMargin, yPos));
                    yPos += boldFont.GetHeight(ev.Graphics);

                    for (int i = 0; i < productos.Count; i++)
                    {
                        string producto = productos[i];
                        string cantidad = cantidades[i].ToString().PadLeft(3);
                        string subtotal = subtotales[i].ToString("C2").PadLeft(subtotalWidth);

                        ev.Graphics.DrawString($"{producto.PadRight(descripcionWidth)}{cantidad.PadRight(cantidadWidth)}{subtotal}", regularFont, Brushes.Black, new PointF(leftMargin, yPos));
                        yPos += regularFont.GetHeight(ev.Graphics);
                        ev.Graphics.DrawString(new string('-', 42), regularFont, Brushes.Black, new PointF(leftMargin, yPos));
                        yPos += regularFont.GetHeight(ev.Graphics);
                    }

                    float ticketWidth = ev.PageBounds.Width - (2 * leftMargin);

                    float totalXPos = ticketWidth - (ev.Graphics.MeasureString($"TOTAL: {total.ToString("C2")}", boldFont).Width + leftMargin);
                    ev.Graphics.DrawString($"TOTAL: {total.ToString("C2")}", boldFont, Brushes.Black, new PointF(totalXPos, yPos));
                    yPos += boldFont.GetHeight(ev.Graphics);

                    // Calcular la posición para alinear el pago y cambio a la derecha
                    float pagoXPos = ticketWidth - (ev.Graphics.MeasureString($"PAGO:  {montoPago.ToString("C2")}", boldFont).Width + leftMargin);
                    float cambioXPos = ticketWidth - (ev.Graphics.MeasureString($"CAMBIO: {cambio.ToString("C2")}", boldFont).Width + leftMargin);
                    ev.Graphics.DrawString($"PAGO:  {montoPago.ToString("C2")}", boldFont, Brushes.Black, new PointF(pagoXPos, yPos));
                    yPos += boldFont.GetHeight(ev.Graphics);
                    ev.Graphics.DrawString($"CAMBIO: {cambio.ToString("C2")}", boldFont, Brushes.Black, new PointF(cambioXPos, yPos));
                    yPos += boldFont.GetHeight(ev.Graphics);

                    ev.Graphics.DrawString(new string('=', 42), regularFont, Brushes.Black, new PointF(leftMargin, yPos));
                    yPos += regularFont.GetHeight(ev.Graphics);
                    ev.Graphics.DrawString("   Gracias por su compra!", regularFont, Brushes.Black, new PointF(leftMargin, yPos));
                };

                // Establecer la impresora de tickets como impresora predeterminada
                printDoc.PrinterSettings.PrinterName = "POS-80"; // Nombre de la impresora térmica

                printDoc.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al imprimir el ticket: " + ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOpenComplements_Click(object sender, EventArgs e)
        {
            var frmComplements = new FrmComplements();
            frmComplements.AgregarProductoAlCarrito += AgregarProductoAlCarritoFromComplements;
            frmComplements.ShowDialog();
        }

        // Este método manejará los productos agregados desde el formulario de complementos
        private void AgregarProductoAlCarritoFromComplements(int idProducto, decimal cantidad)
        {
            // Obtener el producto desde el repositorio
            ProductoRepository productoRepository = new ProductoRepository(new DatabaseConnection());
            Producto producto = productoRepository.GetProductoById(idProducto);

            if (producto != null)
            {
                // Verificar si el producto ya está en el carrito
                foreach (DataGridViewRow row in dgvCart.Rows)
                {
                    if (Convert.ToInt32(row.Cells["idProducto"].Value) == idProducto)
                    {
                        // Actualizar cantidad y subtotal si el producto ya existe
                        decimal existingQuantity = Convert.ToDecimal(row.Cells["Cantidad"].Value);
                        decimal existingSubtotal = Convert.ToDecimal(row.Cells["SubTotal"].Value);

                        row.Cells["Cantidad"].Value = existingQuantity + cantidad;
                        row.Cells["SubTotal"].Value = existingSubtotal + (cantidad * producto.Precio);
                        UpdateTotalSale();
                        return;
                    }
                }

                // Si el producto no está en el carrito, añadirlo
                decimal subtotal = cantidad * producto.Precio;
                dgvCart.Rows.Add(idProducto, producto.Nombre, producto.Precio, cantidad, subtotal);
                UpdateTotalSale();
            }
            else
            {
                MessageBox.Show("El producto seleccionado no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOneNatural_DoubleClick(object sender, EventArgs e)
        {
            btnAddToCart_Click(sender, e);
            btnPay_Click(sender, e);
        }

        private void btnHalfNatural_DoubleClick(object sender, EventArgs e)
        {
            btnAddToCart_Click(sender, e);
            btnPay_Click(sender, e);
        }

        private void btnTwoNatural_DoubleClick(object sender, EventArgs e)
        {
            btnAddToCart_Click(sender, e);
            btnPay_Click(sender, e);
        }

        private void btnHalfAdobado_DoubleClick(object sender, EventArgs e)
        {
            btnAddToCart_Click(sender, e);
            btnPay_Click(sender, e);
        }

        private void btnOneAdobado_DoubleClick(object sender, EventArgs e)
        {
            btnAddToCart_Click(sender, e);
            btnPay_Click(sender, e);
        }

        private void btnTwoAdobado_DoubleClick(object sender, EventArgs e)
        {
            btnAddToCart_Click(sender, e);
            btnPay_Click(sender, e);
        }

        private void btnHalfChiltepin_DoubleClick(object sender, EventArgs e)
        {
            btnAddToCart_Click(sender, e);
            btnPay_Click(sender, e);
        }

        private void btnOneChiltepin_DoubleClick(object sender, EventArgs e)
        {
            btnAddToCart_Click(sender, e);
            btnPay_Click(sender, e);
        }

        private void btnTwoChiltepin_DoubleClick(object sender, EventArgs e)
        {
            btnAddToCart_Click(sender, e);
            btnPay_Click(sender, e);
        }


        private void Complements()
        {
            var products = _productoRepository.GetAllProductos();

            foreach (var product in products)
            {
                if (product.IdProducto == 1 || product.IdProducto == 2 || product.IdProducto == 3)
                {
                    continue;
                }
                var control = new UcComplements
                {
                    Producto = product
                };

                flpComplements.Controls.Add(control);
            }
        }

        private void btnAcceptComplements_Click(object sender, EventArgs e)
        {
            // Recorre los controles en el FlowLayoutPanel
            foreach (UcComplements control in flpComplements.Controls.OfType<UcComplements>())
            {
                if (control.Amount > 0)
                {
                    
                    int idProducto = control.Producto.IdProducto;

                    
                    AgregarProductoAlCarrito(idProducto);
                }
            }
        }
    }
}
