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
            dgvCashCut = new DataGridView();
            txtMontoInicial = new TextBox();
            btnTerminarDia = new Guna.UI2.WinForms.Guna2Button();
            rtxtResume = new RichTextBox();
            lblSaldoInicial = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            rtxtGastos = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)dgvCashCut).BeginInit();
            SuspendLayout();
            // 
            // dgvCashCut
            // 
            dgvCashCut.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCashCut.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCashCut.Location = new Point(1128, 151);
            dgvCashCut.Name = "dgvCashCut";
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
            btnTerminarDia.Location = new Point(1191, 891);
            btnTerminarDia.Name = "btnTerminarDia";
            btnTerminarDia.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnTerminarDia.Size = new Size(225, 56);
            btnTerminarDia.TabIndex = 2;
            btnTerminarDia.Text = "Terminar día";
            btnTerminarDia.Click += btnTerminarDia_Click;
            // 
            // rtxtResume
            // 
            rtxtResume.Location = new Point(32, 151);
            rtxtResume.Name = "rtxtResume";
            rtxtResume.Size = new Size(527, 312);
            rtxtResume.TabIndex = 3;
            rtxtResume.Text = "";
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
            guna2HtmlLabel2.Size = new Size(249, 39);
            guna2HtmlLabel2.TabIndex = 17;
            guna2HtmlLabel2.Text = "Desglose de ventas ";
            // 
            // guna2HtmlLabel3
            // 
            guna2HtmlLabel3.BackColor = Color.Transparent;
            guna2HtmlLabel3.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel3.Location = new Point(716, 69);
            guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            guna2HtmlLabel3.Size = new Size(249, 39);
            guna2HtmlLabel3.TabIndex = 19;
            guna2HtmlLabel3.Text = "Desglose de gastos";
            // 
            // rtxtGastos
            // 
            rtxtGastos.Location = new Point(565, 151);
            rtxtGastos.Name = "rtxtGastos";
            rtxtGastos.Size = new Size(527, 312);
            rtxtGastos.TabIndex = 18;
            rtxtGastos.Text = "";
            // 
            // FrmCashCut
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1902, 1033);
            Controls.Add(guna2HtmlLabel3);
            Controls.Add(rtxtGastos);
            Controls.Add(guna2HtmlLabel2);
            Controls.Add(guna2HtmlLabel1);
            Controls.Add(lblSaldoInicial);
            Controls.Add(rtxtResume);
            Controls.Add(btnTerminarDia);
            Controls.Add(txtMontoInicial);
            Controls.Add(dgvCashCut);
            Name = "FrmCashCut";
            Text = "FrmCashCut";
            WindowState = FormWindowState.Maximized;
            Load += FrmCashCut_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCashCut).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvCashCut;
        private TextBox txtMontoInicial;
        private Guna.UI2.WinForms.Guna2Button btnTerminarDia;
        private RichTextBox rtxtResume;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSaldoInicial;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private RichTextBox richTextBox1;
        private RichTextBox rtxtGastos;
    }
}