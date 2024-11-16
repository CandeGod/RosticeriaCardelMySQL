
using RosticeriaCardel;
using RosticeriaCardelV2.Contenedores;
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
    public partial class FrmSalesHistory : Form
    {
        private DatabaseConnection _databaseConnection;
        private DetalleVentaRepository _detalleVentaRepository;
        private VentaRepository _ventaRepository;
        public FrmSalesHistory()
        {
            InitializeComponent();
            _databaseConnection = new DatabaseConnection();
            _detalleVentaRepository = new DetalleVentaRepository(_databaseConnection);
            _ventaRepository = new VentaRepository(_databaseConnection);

        }

        private void FrmSalesHistory_Load(object sender, EventArgs e)
        {
            DataTable salesData = _ventaRepository.GetAllSales();
            dgvSales.DataSource = salesData;

            cbDates.SelectedItem = "Hoy";

            // Llama al manejador del evento SelectedIndexChanged para cargar las ventas del día
            //cbDates_SelectedIndexChanged(sender, e);
        }

        private void DetailSale(int idVenta)
        {
            DataTable dt = _detalleVentaRepository.GetSaleDetails(idVenta);

            if (dt.Rows.Count > 0)
            {
                DataRow firstRow = dt.Rows[0];
                StringBuilder ticket = new StringBuilder();
                ticket.AppendLine("================================");
                ticket.AppendLine("                             Rosticería Cardel");
                ticket.AppendLine("                    Fecha: " + Convert.ToDateTime(firstRow["Fecha"]).ToString("dd/MM/yyyy HH:mm:ss"));
                ticket.AppendLine("                                   Orden #" + idVenta);
                ticket.AppendLine("================================");
                ticket.AppendLine($"{"Descripción".PadRight(20)}{"Cantidad".PadRight(10)}{"Subtotal".PadRight(10)}");

                foreach (DataRow row in dt.Rows)
                {
                    string producto = row["Nombre"].ToString();
                    string nombreVariacion = row["NombreVariacion"].ToString();
                    string descripcionCompleta = $"{producto} - {nombreVariacion}";
                    string cantidad = row["Cantidad"].ToString().PadLeft(3);
                    string subtotal = Convert.ToDecimal(row["Subtotal"]).ToString("C2").PadLeft(10);

                    ticket.AppendLine($"{descripcionCompleta.PadRight(30)}{cantidad.PadRight(10)}{subtotal}");
                    ticket.AppendLine(new string('-', 53));
                }

                decimal total = dt.AsEnumerable().Sum(r => r.Field<decimal>("Subtotal"));
                decimal montoPago = Convert.ToDecimal(firstRow["MontoPagado"]);
                decimal cambio = Convert.ToDecimal(firstRow["Cambio"]);

                ticket.AppendLine($"TOTAL: {total.ToString("C2").PadLeft(30)}");
                ticket.AppendLine($"PAGO:  {montoPago.ToString("C2").PadLeft(30)}");
                ticket.AppendLine($"CAMBIO: {cambio.ToString("C2").PadLeft(30)}");

                ticket.AppendLine("================================");
                ticket.AppendLine("   Gracias por su compra!");
                ticket.AppendLine("================================");

                rtxtSalesDetails.Text = ticket.ToString();
            }
            else
            {
                MessageBox.Show("No se encontraron detalles para esta venta.");
            }
        }



        private void dgvSales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int idVenta = Convert.ToInt32(dgvSales.Rows[e.RowIndex].Cells["IdVenta"].Value);
                DetailSale(idVenta);
            }
        }

        private void cbMonths_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbDates.SelectedIndex = -1;
            if (cbMonths.SelectedItem != null)
            {
                int mesSeleccionado = cbMonths.SelectedIndex + 1; // Suponiendo que los meses están indexados del 1 al 12
                DataTable dt = _detalleVentaRepository.GetSalesSummaryByMonth(mesSeleccionado);

                if (dt.Rows.Count > 0)
                {
                    StringBuilder resumen = new StringBuilder();
                    resumen.AppendLine("===== RESUMEN DE VENTAS =====");
                    resumen.AppendLine($"Resumen de ventas ({cbMonths.SelectedItem.ToString()})");
                    resumen.AppendLine("Producto     Cantidad  Subtotal");
                    resumen.AppendLine("-------------------------------");

                    decimal totalRecaudado = 0;

                    foreach (DataRow row in dt.Rows)
                    {
                        string producto = row["Producto"].ToString();
                        string variacion = row["NombreVariacion"].ToString(); 
                        decimal cantidadVendida = Convert.ToDecimal(row["CantidadVendida"]);
                        decimal subtotal = Convert.ToDecimal(row["Subtotal"]);

                        string descripcionCompleta = $"{producto} - {variacion}";

                        resumen.AppendLine($"{descripcionCompleta.PadRight(12)} {cantidadVendida.ToString("0.0").PadLeft(8)}  {subtotal.ToString("C2").PadLeft(8)}");

                        totalRecaudado += subtotal;
                    }

                    resumen.AppendLine("-------------------------------");
                    resumen.AppendLine($"Total Recaudado: {totalRecaudado.ToString("C2")}");

                    rtxtSalesResume.Text = resumen.ToString();
                    dgvSales.DataSource = _ventaRepository.GetSalesByMonth(mesSeleccionado);
                }
                else
                {
                    rtxtSalesResume.Text = "No se encontraron ventas para el mes seleccionado.";
                    rtxtSalesDetails.Text = string.Empty;
                    dgvSales.DataSource = null;
                }

                UpdateSelectedDate(cbMonths.SelectedItem.ToString());

            }
        }

        private void cbDates_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbMonths.SelectedIndex = -1;
            if (cbDates.SelectedItem != null)
            {
                string filtroSeleccionado = cbDates.SelectedItem.ToString();
                DataTable dt = _detalleVentaRepository.GetSalesSummaryByFilter(filtroSeleccionado);


                if (dt.Rows.Count > 0)
                {
                    StringBuilder resumen = new StringBuilder();
                    resumen.AppendLine("===== RESUMEN DE VENTAS =====");
                    resumen.AppendLine($"Resumen de ventas ({filtroSeleccionado})");
                    resumen.AppendLine("Producto     Cantidad  Subtotal");
                    resumen.AppendLine("-------------------------------");

                    decimal totalRecaudado = 0;

                    foreach (DataRow row in dt.Rows)
                    {
                        string producto = row["Producto"].ToString();
                        string nombreVariacion = row["NombreVariacion"].ToString();
                        string descripcionCompleta = $"{producto} - {nombreVariacion}";
                        decimal cantidadVendida = Convert.ToDecimal(row["CantidadVendida"]);
                        decimal subtotal = Convert.ToDecimal(row["Subtotal"]);

                        resumen.AppendLine($"{descripcionCompleta.PadRight(12)} {cantidadVendida.ToString("0.0").PadLeft(8)}  {subtotal.ToString("C2").PadLeft(8)}");

                        totalRecaudado += subtotal;
                    }

                    resumen.AppendLine("-------------------------------");
                    resumen.AppendLine($"Total Recaudado: {totalRecaudado.ToString("C2")}");

                    rtxtSalesResume.Text = resumen.ToString();
                    dgvSales.DataSource = _detalleVentaRepository.GetSalesSummaryByFilterdgv(filtroSeleccionado);
                }
                else
                {
                    rtxtSalesResume.Text = "No se encontraron ventas para el filtro seleccionado.";
                    rtxtSalesDetails.Text = "";
                    dgvSales.DataSource = null;
                }
                UpdateSelectedDate(filtroSeleccionado);
            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            cbDates.SelectedIndex = -1;
            cbMonths.SelectedIndex = -1;

            DateTime fechaSeleccionada = dtpDate.Value.Date;

            DataTable dt = _detalleVentaRepository.GetSalesBySpecificDate(fechaSeleccionada);

            if (dt.Rows.Count > 0)
            {
                StringBuilder resumen = new StringBuilder();
                decimal totalRecaudado = 0;

                // Incluye el periodo en el resumen
                resumen.AppendLine("===== RESUMEN DE VENTAS =====");
                resumen.AppendLine($"Resumen de ventas ({fechaSeleccionada.ToString("dd/MM/yyyy")})");
                resumen.AppendLine("Producto     Cantidad  Subtotal");
                resumen.AppendLine("-------------------------------");

                foreach (DataRow row in dt.Rows)
                {
                    string producto = row["Producto"].ToString();
                    string nombreVariacion = row["NombreVariacion"].ToString();
                    string descripcionCompleta = $"{producto} - {nombreVariacion}";
                    decimal cantidadVendida = Convert.ToDecimal(row["CantidadVendida"]);
                    decimal subtotal = Convert.ToDecimal(row["Subtotal"]);

                    resumen.AppendLine($"{descripcionCompleta.PadRight(12)} {cantidadVendida.ToString("0.0").PadLeft(8)}  {subtotal.ToString("C2").PadLeft(8)}");

                    totalRecaudado += subtotal;
                }

                resumen.AppendLine("-------------------------------");
                resumen.AppendLine($"Total Recaudado: {totalRecaudado.ToString("C2")}");

                rtxtSalesResume.Text = resumen.ToString();
                dgvSales.DataSource = _ventaRepository.GetSalesBySpecificDate(fechaSeleccionada);
            }
            else
            {
                rtxtSalesResume.Text = "No se encontraron ventas para la fecha seleccionada.";
                dgvSales.DataSource = null;
                rtxtSalesDetails.Text = string.Empty;
            }

            UpdateSelectedDate(fechaSeleccionada.ToString("dd/MM/yyyy"));
        }

        private void btnPrintSalesSummary_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();

            // Especifica la impresora
            printDocument.PrinterSettings.PrinterName = "POS-80";

            // Define el evento que se encargará de realizar la impresión
            printDocument.PrintPage += new PrintPageEventHandler(PrintSalesSummary);

            try
            {
                // Inicia la impresión
                printDocument.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al imprimir: {ex.Message}");
            }
        }

        private void PrintSalesSummary(object sender, PrintPageEventArgs e)
        {
            // Obtén el texto del RichTextBox
            string textToPrint = rtxtSalesResume.Text;

            // Define la fuente y la ubicación inicial para imprimir
            Font printFont = new Font("Consolas", 10); // Fuente de estilo monoespaciado
            float x = 10;  // Margen izquierdo
            float y = 10;  // Margen superior

            // Imprime el texto
            e.Graphics.DrawString(textToPrint, printFont, Brushes.Black, x, y);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateSelectedDate(string texto)
        {
            lblSelectedDate.Text = $"Fecha seleccionada: {texto}";
        }

        /*private void btnBackup_Click(object sender, EventArgs e)
        {
            bool result = _databaseConnection.ExecRespaldoBD();

            if (result)
            {
                MessageBox.Show("Copia de seguridad completada correctamente.");
            }
            else
            {
                MessageBox.Show("Error al realizar la copia de seguridad.");
            }
        }*/

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
