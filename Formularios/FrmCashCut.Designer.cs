namespace RosticeriaCardelV2.Formularios
{
    partial class FrmCashCut
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            dgvCashCut = new DataGridView();
            txtMontoInicial = new TextBox();
            btnTerminarDia = new Guna.UI2.WinForms.Guna2Button();
            lblSaldoInicial = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnIniciarCorte = new Guna.UI2.WinForms.Guna2Button();
            btnAgregarGasto = new Guna.UI2.WinForms.Guna2Button();
            groupBoxGastos = new GroupBox();
            dgvGastos = new DataGridView();
            lblTotalGastos = new Guna.UI2.WinForms.Guna2HtmlLabel();
            txtConceptoGasto = new TextBox();
            txtMontoGasto = new TextBox();
            dgvVentasHoy = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvCashCut).BeginInit();
            groupBoxGastos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGastos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvVentasHoy).BeginInit();
            SuspendLayout();
            // 
            // dgvCashCut
            // 
            dgvCashCut.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCashCut.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCashCut.Location = new Point(1128, 151);
            dgvCashCut.Name = "dgvCashCut";
            dgvCashCut.ReadOnly = true;
            dgvCashCut.RowHeadersWidth = 51;
            dgvCashCut.Size = new Size(743, 560);
            dgvCashCut.TabIndex = 0;
            dgvCashCut.CellClick += dgvCashCut_CellClick;
            // 
            // txtMontoInicial
            // 
            txtMontoInicial.Location = new Point(1238, 806);
            txtMontoInicial.Name = "txtMontoInicial";
            txtMontoInicial.Size = new Size(125, 27);
            txtMontoInicial.TabIndex = 1;
            // 
            // btnTerminarDia
            // 
            btnTerminarDia.BorderRadius = 10;
            btnTerminarDia.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            btnTerminarDia.CustomizableEdges = customizableEdges1;
            btnTerminarDia.DisabledState.BorderColor = Color.DarkGray;
            btnTerminarDia.DisabledState.CustomBorderColor = Color.DarkGray;
            btnTerminarDia.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnTerminarDia.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnTerminarDia.FillColor = Color.FromArgb(0, 192, 0);
            btnTerminarDia.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTerminarDia.ForeColor = Color.White;
            btnTerminarDia.Location = new Point(90, 23);
            btnTerminarDia.Name = "btnTerminarDia";
            btnTerminarDia.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnTerminarDia.Size = new Size(225, 56);
            btnTerminarDia.TabIndex = 2;
            btnTerminarDia.Text = "Terminar día";
            btnTerminarDia.Click += btnTerminarDia_Click;
            // 
            // lblSaldoInicial
            // 
            lblSaldoInicial.BackColor = Color.Transparent;
            lblSaldoInicial.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSaldoInicial.Location = new Point(1238, 753);
            lblSaldoInicial.Name = "lblSaldoInicial";
            lblSaldoInicial.Size = new Size(123, 30);
            lblSaldoInicial.TabIndex = 15;
            lblSaldoInicial.Text = "Saldo inicial:";
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.Location = new Point(1277, 69);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(336, 39);
            guna2HtmlLabel1.TabIndex = 16;
            guna2HtmlLabel1.Text = "Historial de cortes de caja";
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel2.Location = new Point(183, 69);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(184, 39);
            guna2HtmlLabel2.TabIndex = 17;
            guna2HtmlLabel2.Text = "Ventas de hoy";
            // 
            // guna2HtmlLabel3
            // 
            guna2HtmlLabel3.BackColor = Color.Transparent;
            guna2HtmlLabel3.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel3.Location = new Point(716, 69);
            guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            guna2HtmlLabel3.Size = new Size(183, 39);
            guna2HtmlLabel3.TabIndex = 19;
            guna2HtmlLabel3.Text = "Gastos de hoy";
            // 
            // btnIniciarCorte
            // 
            btnIniciarCorte.BorderRadius = 10;
            btnIniciarCorte.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            btnIniciarCorte.CustomizableEdges = customizableEdges3;
            btnIniciarCorte.DisabledState.BorderColor = Color.DarkGray;
            btnIniciarCorte.DisabledState.CustomBorderColor = Color.DarkGray;
            btnIniciarCorte.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnIniciarCorte.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnIniciarCorte.FillColor = Color.FromArgb(0, 192, 0);
            btnIniciarCorte.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIniciarCorte.ForeColor = Color.White;
            btnIniciarCorte.Location = new Point(855, 842);
            btnIniciarCorte.Name = "btnIniciarCorte";
            btnIniciarCorte.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnIniciarCorte.Size = new Size(225, 56);
            btnIniciarCorte.TabIndex = 20;
            btnIniciarCorte.Text = "Iniciar Corte";
            btnIniciarCorte.Click += btnIniciarCorte_Click;
            // 
            // btnAgregarGasto
            // 
            btnAgregarGasto.BorderRadius = 10;
            btnAgregarGasto.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            btnAgregarGasto.CustomizableEdges = customizableEdges5;
            btnAgregarGasto.DisabledState.BorderColor = Color.DarkGray;
            btnAgregarGasto.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAgregarGasto.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAgregarGasto.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAgregarGasto.FillColor = Color.FromArgb(0, 192, 0);
            btnAgregarGasto.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregarGasto.ForeColor = Color.White;
            btnAgregarGasto.Location = new Point(48, 85);
            btnAgregarGasto.Name = "btnAgregarGasto";
            btnAgregarGasto.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnAgregarGasto.Size = new Size(267, 56);
            btnAgregarGasto.TabIndex = 21;
            btnAgregarGasto.Text = "Agregar Gasto";
            btnAgregarGasto.Click += btnAgregarGasto_Click;
            // 
            // groupBoxGastos
            // 
            groupBoxGastos.Controls.Add(btnAgregarGasto);
            groupBoxGastos.Controls.Add(btnTerminarDia);
            groupBoxGastos.Location = new Point(397, 502);
            groupBoxGastos.Name = "groupBoxGastos";
            groupBoxGastos.Size = new Size(440, 141);
            groupBoxGastos.TabIndex = 22;
            groupBoxGastos.TabStop = false;
            groupBoxGastos.Text = "groupBox1";
            // 
            // dgvGastos
            // 
            dgvGastos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGastos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGastos.Location = new Point(556, 151);
            dgvGastos.Name = "dgvGastos";
            dgvGastos.ReadOnly = true;
            dgvGastos.RowHeadersWidth = 51;
            dgvGastos.Size = new Size(548, 312);
            dgvGastos.TabIndex = 23;
            // 
            // lblTotalGastos
            // 
            lblTotalGastos.BackColor = Color.Transparent;
            lblTotalGastos.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalGastos.Location = new Point(69, 485);
            lblTotalGastos.Name = "lblTotalGastos";
            lblTotalGastos.Size = new Size(125, 39);
            lblTotalGastos.TabIndex = 24;
            lblTotalGastos.Text = "Gasotssss";
            // 
            // txtConceptoGasto
            // 
            txtConceptoGasto.Location = new Point(216, 542);
            txtConceptoGasto.Name = "txtConceptoGasto";
            txtConceptoGasto.Size = new Size(125, 27);
            txtConceptoGasto.TabIndex = 25;
            // 
            // txtMontoGasto
            // 
            txtMontoGasto.Location = new Point(216, 575);
            txtMontoGasto.Name = "txtMontoGasto";
            txtMontoGasto.Size = new Size(125, 27);
            txtMontoGasto.TabIndex = 26;
            // 
            // dgvVentasHoy
            // 
            dgvVentasHoy.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVentasHoy.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVentasHoy.Location = new Point(69, 151);
            dgvVentasHoy.Name = "dgvVentasHoy";
            dgvVentasHoy.ReadOnly = true;
            dgvVentasHoy.RowHeadersWidth = 51;
            dgvVentasHoy.Size = new Size(477, 312);
            dgvVentasHoy.TabIndex = 27;
            // 
            // FrmCashCut
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1902, 1033);
            Controls.Add(dgvVentasHoy);
            Controls.Add(btnIniciarCorte);
            Controls.Add(txtMontoGasto);
            Controls.Add(txtConceptoGasto);
            Controls.Add(lblTotalGastos);
            Controls.Add(dgvGastos);
            Controls.Add(groupBoxGastos);
            Controls.Add(guna2HtmlLabel3);
            Controls.Add(guna2HtmlLabel2);
            Controls.Add(guna2HtmlLabel1);
            Controls.Add(lblSaldoInicial);
            Controls.Add(txtMontoInicial);
            Controls.Add(dgvCashCut);
            Name = "FrmCashCut";
            Text = "FrmCashCut";
            WindowState = FormWindowState.Maximized;
            Load += FrmCashCut_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCashCut).EndInit();
            groupBoxGastos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvGastos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvVentasHoy).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvCashCut;
        private TextBox txtMontoInicial;
        private Guna.UI2.WinForms.Guna2Button btnTerminarDia;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSaldoInicial;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private RichTextBox richTextBox1;
        private Guna.UI2.WinForms.Guna2Button btnIniciarCorte;
        private Guna.UI2.WinForms.Guna2Button btnAgregarGasto;
        private GroupBox groupBoxGastos;
        private DataGridView dgvGastos;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTotalGastos;
        private TextBox txtConceptoGasto;
        private TextBox txtMontoGasto;
        private DataGridView dgvVentasHoy;
    }
}