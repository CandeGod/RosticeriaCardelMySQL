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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCashCut));
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
            guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            panel1 = new Panel();
            btnBack = new Guna.UI2.WinForms.Guna2Button();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvCashCut).BeginInit();
            groupBoxGastos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGastos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvVentasHoy).BeginInit();
            ((System.ComponentModel.ISupportInitialize)guna2CirclePictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvCashCut
            // 
            dgvCashCut.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCashCut.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCashCut.Location = new Point(1128, 225);
            dgvCashCut.Name = "dgvCashCut";
            dgvCashCut.ReadOnly = true;
            dgvCashCut.RowHeadersWidth = 51;
            dgvCashCut.Size = new Size(743, 560);
            dgvCashCut.TabIndex = 0;
            dgvCashCut.CellClick += dgvCashCut_CellClick;
            // 
            // txtMontoInicial
            // 
            txtMontoInicial.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMontoInicial.Location = new Point(296, 584);
            txtMontoInicial.Name = "txtMontoInicial";
            txtMontoInicial.Size = new Size(197, 51);
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
            btnTerminarDia.FillColor = Color.Goldenrod;
            btnTerminarDia.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTerminarDia.ForeColor = Color.White;
            btnTerminarDia.Location = new Point(1181, 26);
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
            lblSaldoInicial.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSaldoInicial.Location = new Point(93, 584);
            lblSaldoInicial.Name = "lblSaldoInicial";
            lblSaldoInicial.Size = new Size(197, 47);
            lblSaldoInicial.TabIndex = 15;
            lblSaldoInicial.Text = "Saldo inicial:";
            lblSaldoInicial.Click += lblSaldoInicial_Click;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.Location = new Point(1277, 143);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(336, 39);
            guna2HtmlLabel1.TabIndex = 16;
            guna2HtmlLabel1.Text = "Historial de cortes de caja";
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel2.Location = new Point(183, 143);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(184, 39);
            guna2HtmlLabel2.TabIndex = 17;
            guna2HtmlLabel2.Text = "Ventas de hoy";
            // 
            // guna2HtmlLabel3
            // 
            guna2HtmlLabel3.BackColor = Color.Transparent;
            guna2HtmlLabel3.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel3.Location = new Point(716, 143);
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
            btnIniciarCorte.Location = new Point(547, 579);
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
            btnAgregarGasto.Location = new Point(6, 26);
            btnAgregarGasto.Name = "btnAgregarGasto";
            btnAgregarGasto.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnAgregarGasto.Size = new Size(267, 56);
            btnAgregarGasto.TabIndex = 21;
            btnAgregarGasto.Text = "Agregar Gasto";
            btnAgregarGasto.Click += btnAgregarGasto_Click;
            // 
            // groupBoxGastos
            // 
            groupBoxGastos.BackColor = Color.Transparent;
            groupBoxGastos.Controls.Add(btnAgregarGasto);
            groupBoxGastos.Controls.Add(btnTerminarDia);
            groupBoxGastos.FlatStyle = FlatStyle.Flat;
            groupBoxGastos.ForeColor = Color.Transparent;
            groupBoxGastos.Location = new Point(468, 863);
            groupBoxGastos.Name = "groupBoxGastos";
            groupBoxGastos.Size = new Size(1412, 96);
            groupBoxGastos.TabIndex = 22;
            groupBoxGastos.TabStop = false;
            // 
            // dgvGastos
            // 
            dgvGastos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGastos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGastos.Location = new Point(556, 225);
            dgvGastos.Name = "dgvGastos";
            dgvGastos.ReadOnly = true;
            dgvGastos.RowHeadersWidth = 51;
            dgvGastos.Size = new Size(548, 312);
            dgvGastos.TabIndex = 23;
            // 
            // lblTotalGastos
            // 
            lblTotalGastos.BackColor = Color.Transparent;
            lblTotalGastos.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalGastos.Location = new Point(183, 800);
            lblTotalGastos.Name = "lblTotalGastos";
            lblTotalGastos.Size = new Size(107, 47);
            lblTotalGastos.TabIndex = 24;
            lblTotalGastos.Text = "Gastos";
            // 
            // txtConceptoGasto
            // 
            txtConceptoGasto.Location = new Point(293, 869);
            txtConceptoGasto.Name = "txtConceptoGasto";
            txtConceptoGasto.Size = new Size(125, 27);
            txtConceptoGasto.TabIndex = 25;
            // 
            // txtMontoGasto
            // 
            txtMontoGasto.Location = new Point(293, 932);
            txtMontoGasto.Name = "txtMontoGasto";
            txtMontoGasto.Size = new Size(125, 27);
            txtMontoGasto.TabIndex = 26;
            // 
            // dgvVentasHoy
            // 
            dgvVentasHoy.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVentasHoy.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVentasHoy.Location = new Point(69, 225);
            dgvVentasHoy.Name = "dgvVentasHoy";
            dgvVentasHoy.ReadOnly = true;
            dgvVentasHoy.RowHeadersWidth = 51;
            dgvVentasHoy.Size = new Size(477, 312);
            dgvVentasHoy.TabIndex = 27;
            // 
            // guna2HtmlLabel4
            // 
            guna2HtmlLabel4.BackColor = Color.Transparent;
            guna2HtmlLabel4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel4.Location = new Point(96, 863);
            guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            guna2HtmlLabel4.Size = new Size(191, 33);
            guna2HtmlLabel4.TabIndex = 28;
            guna2HtmlLabel4.Text = "Motivo del gasto:";
            guna2HtmlLabel4.Click += guna2HtmlLabel4_Click;
            // 
            // guna2HtmlLabel5
            // 
            guna2HtmlLabel5.BackColor = Color.Transparent;
            guna2HtmlLabel5.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel5.Location = new Point(114, 926);
            guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            guna2HtmlLabel5.Size = new Size(173, 33);
            guna2HtmlLabel5.TabIndex = 29;
            guna2HtmlLabel5.Text = "Monto gastado:";
            // 
            // guna2CirclePictureBox1
            // 
            guna2CirclePictureBox1.Image = Properties.Resources.RosticeríaSabrosonPNG;
            guna2CirclePictureBox1.ImageRotate = 0F;
            guna2CirclePictureBox1.Location = new Point(1772, 5);
            guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            guna2CirclePictureBox1.ShadowDecoration.CustomizableEdges = customizableEdges7;
            guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            guna2CirclePictureBox1.Size = new Size(105, 105);
            guna2CirclePictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            guna2CirclePictureBox1.TabIndex = 67;
            guna2CirclePictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 233, 147);
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(guna2CirclePictureBox1);
            panel1.Controls.Add(btnBack);
            panel1.Controls.Add(label6);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(1893, 115);
            panel1.TabIndex = 38;
            // 
            // btnBack
            // 
            btnBack.BackgroundImageLayout = ImageLayout.Stretch;
            btnBack.BorderRadius = 20;
            btnBack.BorderStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
            btnBack.CustomizableEdges = customizableEdges8;
            btnBack.DisabledState.BorderColor = Color.DarkGray;
            btnBack.DisabledState.CustomBorderColor = Color.DarkGray;
            btnBack.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnBack.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnBack.FillColor = Color.FromArgb(255, 233, 147);
            btnBack.Font = new Font("Segoe UI", 9F);
            btnBack.ForeColor = Color.White;
            btnBack.Image = Properties.Resources.Regresar;
            btnBack.ImageSize = new Size(100, 55);
            btnBack.Location = new Point(3, 3);
            btnBack.Name = "btnBack";
            btnBack.ShadowDecoration.CustomizableEdges = customizableEdges9;
            btnBack.Size = new Size(119, 72);
            btnBack.TabIndex = 66;
            btnBack.Click += btnBack_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Black", 16.2F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(248, 88, 0);
            label6.ImeMode = ImeMode.NoControl;
            label6.Location = new Point(794, 33);
            label6.Name = "label6";
            label6.Size = new Size(212, 38);
            label6.TabIndex = 9;
            label6.Text = "Cortes de caja";
            // 
            // FrmCashCut
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1902, 1033);
            Controls.Add(panel1);
            Controls.Add(guna2HtmlLabel5);
            Controls.Add(guna2HtmlLabel4);
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
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmCashCut";
            Text = "FrmCashCut";
            WindowState = FormWindowState.Maximized;
            Load += FrmCashCut_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCashCut).EndInit();
            groupBoxGastos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvGastos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvVentasHoy).EndInit();
            ((System.ComponentModel.ISupportInitialize)guna2CirclePictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
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
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel5;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private Panel panel1;
        private Guna.UI2.WinForms.Guna2Button btnBack;
        private Label label6;
    }
}