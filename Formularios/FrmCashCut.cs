using RosticeriaCardel;
using RosticeriaCardelV2.Clases;
using RosticeriaCardelV2.Contenedores;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace RosticeriaCardelV2.Formularios
{
    public partial class FrmCashCut : Form
    {
        private readonly CashCutRepository _cashCutRepository;
        private readonly GastoRepository _gastoRepository;
        private int _idCorteActual;
        private bool _corteIniciado = false;

        public FrmCashCut()
        {
            InitializeComponent();
            DatabaseConnection databaseConnection = new DatabaseConnection();
            _cashCutRepository = new CashCutRepository(databaseConnection);
            _gastoRepository = new GastoRepository(databaseConnection);

            VerificarCorteDelDia();
        }

        private void VerificarCorteDelDia()
        {
            try
            {
                var fecha = DateTime.Now;
                var corteDelDia = _cashCutRepository.GetActiveCashCutByDate(fecha);

                if (corteDelDia != null && corteDelDia.Estado == "ACTIVO")
                {
                    // Hay un corte ACTIVO iniciado hoy
                    _idCorteActual = corteDelDia.IdCorte;
                    _corteIniciado = true;
                    CargarEstadoCorteExistente(corteDelDia);
                }
                else
                {
                    // No hay corte activo hoy
                    groupBoxGastos.Visible = false;
                    btnTerminarDia.Enabled = false;
                    btnIniciarCorte.Enabled = true;
                    txtMontoInicial.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al verificar corte del día: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarEstadoCorteExistente(CashCut corte)
        {
            txtMontoInicial.Text = corte.MontoInicial.ToString();
            txtMontoInicial.Enabled = false;
            btnIniciarCorte.Enabled = false;
            groupBoxGastos.Visible = true;
            btnTerminarDia.Enabled = true;

            // Cargar gastos existentes desde la BD
            CargarGastosDesdeBD();
        }

        private void CargarGastosDesdeBD()
        {
            try
            {
                var gastos = _gastoRepository.GetGastosByCorteId(_idCorteActual);
                dgvGastos.DataSource = gastos;

                decimal totalGastos = gastos.Sum(g => g.Monto);
                lblTotalGastos.Text = $"Total Gastos: {totalGastos:C}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar gastos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIniciarCorte_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMontoInicial.Text))
            {
                MessageBox.Show("Completa el campo de monto inicial.", "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var fecha = DateTime.Now;

                // Verificar si ya existe un corte de caja para la fecha actual
                //if (_cashCutRepository.ThereIsCashCutForDate(fecha))
                //{
                //    MessageBox.Show("Ya se ha realizado un corte de caja para el día de hoy.", "Corte de Caja Existente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}

                var montoInicial = decimal.Parse(txtMontoInicial.Text);

                // Crear el corte de caja inicial
                var corte = new CashCut
                {
                    Fecha = fecha,
                    MontoInicial = montoInicial,
                    TotalVentas = 0,
                    TotalGastos = 0,
                    MontoFinal = montoInicial
                };

                // Guardar el corte para obtener el ID
                _cashCutRepository.AddCashCut(corte);

                // Obtener el ID del corte recién creado
                _idCorteActual = _cashCutRepository.GetLastCashCutId();
                _corteIniciado = true;

                // Configurar interfaz
                groupBoxGastos.Visible = true;
                btnIniciarCorte.Enabled = false;
                txtMontoInicial.Enabled = false;
                btnTerminarDia.Enabled = true;

                MessageBox.Show("Corte iniciado. Ahora puedes registrar gastos.", "Corte Iniciado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvCashCut.DataSource = _cashCutRepository.GetCashCut();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al iniciar el corte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarGasto_Click(object sender, EventArgs e)
        {
            if (!_corteIniciado)
            {
                MessageBox.Show("Primero debes iniciar el corte de caja.", "Corte no iniciado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtConceptoGasto.Text) || string.IsNullOrEmpty(txtMontoGasto.Text))
            {
                MessageBox.Show("Completa todos los campos del gasto.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var gasto = new Gasto
                {
                    IdCorte = _idCorteActual,
                    Concepto = txtConceptoGasto.Text,
                    Monto = decimal.Parse(txtMontoGasto.Text),
                    Fecha = DateTime.Now
                };

                // Agregar a la base de datos
                _gastoRepository.AddExpense(gasto);

                // Limpiar campos
                txtConceptoGasto.Clear();
                txtMontoGasto.Clear();

                // Recargar gastos desde BD
                CargarGastosDesdeBD();

                MessageBox.Show("Gasto agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar gasto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTerminarDia_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Estás seguro de que deseas terminar el día?\n\nEsta acción no se puede deshacer.",
                                       "Confirmar Terminar Día", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var fecha = DateTime.Now;

                    // Obtener total de ventas del día
                    var totalVentasDelDia = _cashCutRepository.GetTotalSalesOfTheDay(fecha);

                    // Obtener total de gastos desde la BD
                    var gastos = _gastoRepository.GetGastosByCorteId(_idCorteActual);
                    var totalGastosDelDia = gastos.Sum(g => g.Monto);

                    // Obtener monto inicial
                    var montoInicial = decimal.Parse(txtMontoInicial.Text);

                    // Calcular monto final
                    var montoFinal = montoInicial + totalVentasDelDia - totalGastosDelDia;

                    // Actualizar el corte de caja con los totales reales
                    _cashCutRepository.UpdateCashCut(_idCorteActual, totalVentasDelDia, totalGastosDelDia, montoFinal);

                    // Recargar la lista de cortes
                    dgvCashCut.DataSource = _cashCutRepository.GetCashCut();

                    // Reiniciar estado del formulario
                    ReiniciarFormulario();

                    MessageBox.Show("Corte de caja finalizado con éxito.", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al finalizar el corte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ReiniciarFormulario()
        {
            _idCorteActual = 0;
            _corteIniciado = false;
            txtMontoInicial.Clear();
            txtConceptoGasto.Clear();
            txtMontoGasto.Clear();
            groupBoxGastos.Visible = false;
            btnIniciarCorte.Enabled = true;
            txtMontoInicial.Enabled = true;
            btnTerminarDia.Enabled = false;
            dgvGastos.DataSource = null;
            lblTotalGastos.Text = "Total Gastos: $0.00";
        }


        private void FrmCashCut_Load(object sender, EventArgs e)
        {
            try
            {
                var cortes = _cashCutRepository.GetCashCut();
                dgvCashCut.DataSource = cortes;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los cortes de caja: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCashCut_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCashCut.Rows[e.RowIndex];
                CashCut selectedCorte = (CashCut)row.DataBoundItem;


                string resumen = $"Fecha: {selectedCorte.Fecha}\n" +
                         $"Monto Inicial: {selectedCorte.MontoInicial:C}\n" +
                         $"Total Ventas: {selectedCorte.TotalVentas:C}\n" +
                         $"Total Gastos: {selectedCorte.TotalGastos:C}\n" +
                         $"Monto Final: {selectedCorte.MontoFinal:C}\n" +
                         $"Diferencia: {(selectedCorte.TotalVentas - selectedCorte.TotalGastos):C}\n" +
                         $"Estado: {selectedCorte.Estado:C}";


                // Mostrar el resumen en el RichTextBox
                rtxtResume.Text = resumen;
            }
        }

        
    }
}
