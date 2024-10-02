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
            ((System.ComponentModel.ISupportInitialize)dgvCashCut).BeginInit();
            SuspendLayout();
            // 
            // dgvCashCut
            // 
            dgvCashCut.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCashCut.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCashCut.Location = new Point(408, 39);
            dgvCashCut.Name = "dgvCashCut";
            dgvCashCut.RowHeadersWidth = 51;
            dgvCashCut.Size = new Size(865, 226);
            dgvCashCut.TabIndex = 0;
            dgvCashCut.CellClick += dgvCashCut_CellClick;
            // 
            // txtMontoInicial
            // 
            txtMontoInicial.Location = new Point(139, 171);
            txtMontoInicial.Name = "txtMontoInicial";
            txtMontoInicial.Size = new Size(125, 27);
            txtMontoInicial.TabIndex = 1;
            // 
            // btnTerminarDia
            // 
            btnTerminarDia.CustomizableEdges = customizableEdges1;
            btnTerminarDia.DisabledState.BorderColor = Color.DarkGray;
            btnTerminarDia.DisabledState.CustomBorderColor = Color.DarkGray;
            btnTerminarDia.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnTerminarDia.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnTerminarDia.Font = new Font("Segoe UI", 9F);
            btnTerminarDia.ForeColor = Color.White;
            btnTerminarDia.Location = new Point(156, 322);
            btnTerminarDia.Name = "btnTerminarDia";
            btnTerminarDia.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnTerminarDia.Size = new Size(225, 56);
            btnTerminarDia.TabIndex = 2;
            btnTerminarDia.Text = "guna2Button1";
            btnTerminarDia.Click += btnTerminarDia_Click;
            // 
            // rtxtResume
            // 
            rtxtResume.Location = new Point(479, 294);
            rtxtResume.Name = "rtxtResume";
            rtxtResume.Size = new Size(490, 267);
            rtxtResume.TabIndex = 3;
            rtxtResume.Text = "";
            // 
            // FrmCashCut
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1409, 594);
            Controls.Add(rtxtResume);
            Controls.Add(btnTerminarDia);
            Controls.Add(txtMontoInicial);
            Controls.Add(dgvCashCut);
            Name = "FrmCashCut";
            Text = "FrmCashCut";
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
    }
}