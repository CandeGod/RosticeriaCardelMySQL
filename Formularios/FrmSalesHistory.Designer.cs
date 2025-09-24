namespace RosticeriaCardelV2.Formularios
{
    partial class FrmSalesHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSalesHistory));
            guna2vSeparator1 = new Guna.UI2.WinForms.Guna2VSeparator();
            btnPrintSalesSummary = new Guna.UI2.WinForms.Guna2Button();
            label5 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            lblActividadReciente = new Label();
            panel1 = new Panel();
            btnBackup = new Guna.UI2.WinForms.Guna2Button();
            guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            btnBack = new Guna.UI2.WinForms.Guna2Button();
            label7 = new Label();
            label8 = new Label();
            label4 = new Label();
            dtpDate = new DateTimePicker();
            rtxtSalesResume = new RichTextBox();
            cbMonths = new ComboBox();
            cbDates = new ComboBox();
            rtxtSalesDetails = new RichTextBox();
            dgvSales = new DataGridView();
            lblSelectedDate = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)guna2CirclePictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSales).BeginInit();
            SuspendLayout();
            // 
            // guna2vSeparator1
            // 
            guna2vSeparator1.BackColor = SystemColors.ControlDark;
            guna2vSeparator1.FillColor = SystemColors.ControlDark;
            guna2vSeparator1.Location = new Point(976, 133);
            guna2vSeparator1.Name = "guna2vSeparator1";
            guna2vSeparator1.Size = new Size(2, 920);
            guna2vSeparator1.TabIndex = 62;
            // 
            // btnPrintSalesSummary
            // 
            btnPrintSalesSummary.BorderRadius = 40;
            btnPrintSalesSummary.BorderThickness = 2;
            btnPrintSalesSummary.CustomizableEdges = customizableEdges1;
            btnPrintSalesSummary.DisabledState.BorderColor = Color.DarkGray;
            btnPrintSalesSummary.DisabledState.CustomBorderColor = Color.DarkGray;
            btnPrintSalesSummary.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnPrintSalesSummary.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnPrintSalesSummary.FillColor = Color.FromArgb(126, 218, 81);
            btnPrintSalesSummary.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPrintSalesSummary.ForeColor = Color.Black;
            btnPrintSalesSummary.Image = Properties.Resources.icons8_imprimir_50;
            btnPrintSalesSummary.ImageAlign = HorizontalAlignment.Right;
            btnPrintSalesSummary.ImageOffset = new Point(20, 0);
            btnPrintSalesSummary.ImageSize = new Size(70, 70);
            btnPrintSalesSummary.Location = new Point(1133, 807);
            btnPrintSalesSummary.Name = "btnPrintSalesSummary";
            btnPrintSalesSummary.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnPrintSalesSummary.Size = new Size(629, 82);
            btnPrintSalesSummary.TabIndex = 64;
            btnPrintSalesSummary.Text = "Imprimir resumen de venta";
            btnPrintSalesSummary.TextOffset = new Point(-40, 0);
            btnPrintSalesSummary.Click += btnPrintSalesSummary_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(1567, 173);
            label5.Name = "label5";
            label5.Size = new Size(218, 31);
            label5.TabIndex = 63;
            label5.Text = "Resumen de ventas";
            label5.TextAlign = ContentAlignment.TopCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(1084, 173);
            label3.Name = "label3";
            label3.Size = new Size(212, 31);
            label3.TabIndex = 61;
            label3.Text = "Detalle de la venta";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(681, 173);
            label2.Name = "label2";
            label2.Size = new Size(163, 31);
            label2.TabIndex = 60;
            label2.Text = "Dia especifico";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(459, 173);
            label1.Name = "label1";
            label1.Size = new Size(58, 31);
            label1.TabIndex = 59;
            label1.Text = "Mes";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblActividadReciente
            // 
            lblActividadReciente.AutoSize = true;
            lblActividadReciente.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblActividadReciente.Location = new Point(126, 173);
            lblActividadReciente.Name = "lblActividadReciente";
            lblActividadReciente.Size = new Size(208, 31);
            lblActividadReciente.TabIndex = 58;
            lblActividadReciente.Text = "Actividad reciente";
            lblActividadReciente.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 233, 147);
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnBackup);
            panel1.Controls.Add(guna2CirclePictureBox1);
            panel1.Controls.Add(btnBack);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label8);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(1894, 115);
            panel1.TabIndex = 57;
            panel1.Paint += panel1_Paint;
            // 
            // btnBackup
            // 
            btnBackup.BorderRadius = 20;
            btnBackup.BorderThickness = 2;
            btnBackup.CustomizableEdges = customizableEdges3;
            btnBackup.DisabledState.BorderColor = Color.DarkGray;
            btnBackup.DisabledState.CustomBorderColor = Color.DarkGray;
            btnBackup.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnBackup.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnBackup.FillColor = Color.FromArgb(126, 218, 81);
            btnBackup.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBackup.ForeColor = Color.Black;
            btnBackup.Image = Properties.Resources.subir_flecha_arriba;
            btnBackup.ImageAlign = HorizontalAlignment.Right;
            btnBackup.ImageSize = new Size(30, 30);
            btnBackup.Location = new Point(1577, 3);
            btnBackup.Name = "btnBackup";
            btnBackup.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnBackup.Size = new Size(185, 44);
            btnBackup.TabIndex = 66;
            btnBackup.Text = "Subir respaldo";
            btnBackup.TextOffset = new Point(-15, 0);
            btnBackup.Visible = false;
            // 
            // guna2CirclePictureBox1
            // 
            guna2CirclePictureBox1.Image = Properties.Resources.RosticeríaSabrosonPNG;
            guna2CirclePictureBox1.ImageRotate = 0F;
            guna2CirclePictureBox1.Location = new Point(1768, 5);
            guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            guna2CirclePictureBox1.ShadowDecoration.CustomizableEdges = customizableEdges5;
            guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            guna2CirclePictureBox1.Size = new Size(105, 105);
            guna2CirclePictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            guna2CirclePictureBox1.TabIndex = 48;
            guna2CirclePictureBox1.TabStop = false;
            // 
            // btnBack
            // 
            btnBack.BackgroundImageLayout = ImageLayout.Stretch;
            btnBack.BorderRadius = 20;
            btnBack.BorderStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
            btnBack.CustomizableEdges = customizableEdges6;
            btnBack.DisabledState.BorderColor = Color.DarkGray;
            btnBack.DisabledState.CustomBorderColor = Color.DarkGray;
            btnBack.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnBack.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnBack.FillColor = Color.FromArgb(255, 233, 147);
            btnBack.Font = new Font("Segoe UI", 9F);
            btnBack.ForeColor = Color.White;
            btnBack.Image = Properties.Resources.Regresar;
            btnBack.ImageSize = new Size(100, 55);
            btnBack.Location = new Point(-1, -1);
            btnBack.Name = "btnBack";
            btnBack.ShadowDecoration.CustomizableEdges = customizableEdges7;
            btnBack.Size = new Size(119, 72);
            btnBack.TabIndex = 47;
            btnBack.Click += btnBack_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(248, 88, 0);
            label7.Location = new Point(1341, 65);
            label7.Name = "label7";
            label7.Size = new Size(130, 38);
            label7.TabIndex = 10;
            label7.Text = "Detalles";
            label7.TextAlign = ContentAlignment.TopCenter;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(248, 88, 0);
            label8.Location = new Point(426, 65);
            label8.Name = "label8";
            label8.Size = new Size(175, 38);
            label8.TabIndex = 9;
            label8.Text = "Buscar por:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(513, 44);
            label4.Name = "label4";
            label4.Size = new Size(82, 20);
            label4.TabIndex = 56;
            label4.Text = "Buscar por:";
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(635, 219);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(250, 27);
            dtpDate.TabIndex = 55;
            dtpDate.TabStop = false;
            dtpDate.ValueChanged += dtpDate_ValueChanged;
            // 
            // rtxtSalesResume
            // 
            rtxtSalesResume.Location = new Point(1481, 268);
            rtxtSalesResume.Margin = new Padding(3, 4, 3, 4);
            rtxtSalesResume.Name = "rtxtSalesResume";
            rtxtSalesResume.ReadOnly = true;
            rtxtSalesResume.Size = new Size(356, 436);
            rtxtSalesResume.TabIndex = 54;
            rtxtSalesResume.Text = "";
            // 
            // cbMonths
            // 
            cbMonths.FormattingEnabled = true;
            cbMonths.Items.AddRange(new object[] { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" });
            cbMonths.Location = new Point(409, 219);
            cbMonths.Name = "cbMonths";
            cbMonths.Size = new Size(151, 28);
            cbMonths.TabIndex = 53;
            cbMonths.SelectedIndexChanged += cbMonths_SelectedIndexChanged;
            // 
            // cbDates
            // 
            cbDates.FormattingEnabled = true;
            cbDates.Items.AddRange(new object[] { "Hoy", "Ayer", "Esta semana", "Este mes", "Todo el tiempo" });
            cbDates.Location = new Point(145, 219);
            cbDates.Name = "cbDates";
            cbDates.Size = new Size(151, 28);
            cbDates.TabIndex = 52;
            cbDates.SelectedIndexChanged += cbDates_SelectedIndexChanged;
            // 
            // rtxtSalesDetails
            // 
            rtxtSalesDetails.Location = new Point(1012, 268);
            rtxtSalesDetails.Margin = new Padding(3, 4, 3, 4);
            rtxtSalesDetails.Name = "rtxtSalesDetails";
            rtxtSalesDetails.ReadOnly = true;
            rtxtSalesDetails.Size = new Size(356, 436);
            rtxtSalesDetails.TabIndex = 51;
            rtxtSalesDetails.Text = "";
            // 
            // dgvSales
            // 
            dgvSales.AllowUserToAddRows = false;
            dgvSales.AllowUserToDeleteRows = false;
            dgvSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSales.Location = new Point(12, 330);
            dgvSales.Margin = new Padding(3, 4, 3, 4);
            dgvSales.Name = "dgvSales";
            dgvSales.ReadOnly = true;
            dgvSales.RowHeadersWidth = 51;
            dgvSales.Size = new Size(927, 690);
            dgvSales.TabIndex = 50;
            dgvSales.CellClick += dgvSales_CellClick;
            // 
            // lblSelectedDate
            // 
            lblSelectedDate.AutoSize = true;
            lblSelectedDate.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSelectedDate.Location = new Point(331, 281);
            lblSelectedDate.Name = "lblSelectedDate";
            lblSelectedDate.Size = new Size(229, 31);
            lblSelectedDate.TabIndex = 65;
            lblSelectedDate.Text = "Fecha seleccionada: ";
            lblSelectedDate.TextAlign = ContentAlignment.TopCenter;
            // 
            // FrmSalesHistory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1902, 1033);
            Controls.Add(lblSelectedDate);
            Controls.Add(guna2vSeparator1);
            Controls.Add(btnPrintSalesSummary);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblActividadReciente);
            Controls.Add(panel1);
            Controls.Add(label4);
            Controls.Add(dtpDate);
            Controls.Add(rtxtSalesResume);
            Controls.Add(cbMonths);
            Controls.Add(cbDates);
            Controls.Add(rtxtSalesDetails);
            Controls.Add(dgvSales);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmSalesHistory";
            Text = "Historial de ventas";
            WindowState = FormWindowState.Maximized;
            Load += FrmSalesHistory_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)guna2CirclePictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSales).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2VSeparator guna2vSeparator1;
        private Guna.UI2.WinForms.Guna2Button btnPrintSalesSummary;
        private Label label5;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label lblActividadReciente;
        private Panel panel1;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private Guna.UI2.WinForms.Guna2Button btnBack;
        private Label label7;
        private Label label8;
        private Label label4;
        private DateTimePicker dtpDate;
        private RichTextBox rtxtSalesResume;
        private ComboBox cbMonths;
        private ComboBox cbDates;
        private RichTextBox rtxtSalesDetails;
        private DataGridView dgvSales;
        private Label lblSelectedDate;
        private Guna.UI2.WinForms.Guna2Button btnBackup;
    }
}