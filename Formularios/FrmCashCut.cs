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

        public FrmCashCut()
        {
            InitializeComponent();
            _cashCutRepository = new CashCutRepository();
        }

        private void btnTerminarDia_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMontoInicial.Text))
            {
                MessageBox.Show("Completa el campo de monto inicial.", "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var result = MessageBox.Show("¿Estás seguro de que deseas terminar el día?", "Confirmar Terminar Día", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        var fecha = DateTime.Now;

                        // Verificar si ya existe un corte de caja para la fecha actual
                        if (_cashCutRepository.ThereIsCashCutForDate(fecha))
                        {
                            MessageBox.Show("Ya se ha realizado un corte de caja para el día de hoy.", "Corte de Caja Existente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        var montoInicial = decimal.Parse(txtMontoInicial.Text);
                        var totalVentasDelDia = _cashCutRepository.GetTotalSalesOfTheDay(fecha);
                        var montoFinal = montoInicial + totalVentasDelDia;

                        var corte = new CashCut
                        {
                            Fecha = fecha,
                            MontoInicial = montoInicial,
                            MontoFinal = montoFinal
                        };

                        _cashCutRepository.AddCashCut(corte);

                        dgvCashCut.DataSource = _cashCutRepository.GetCashCut();

                        MessageBox.Show("Corte de caja guardado con éxito.", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al guardar el corte de caja: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
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
                                 $"Monto Final: {selectedCorte.MontoFinal:C}\n" +
                                 $"Total Ventas del Día: {(selectedCorte.MontoFinal - selectedCorte.MontoInicial):C}";

                // Mostrar el resumen en el RichTextBox
                rtxtResume.Text = resumen;
            }
        }
    }
}
