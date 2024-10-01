namespace RosticeriaCardelV2.Formularios
{
    partial class FrmProductos
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProductos));
            dgvProductos = new DataGridView();
            panel1 = new Panel();
            guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            btnBack = new Guna.UI2.WinForms.Guna2Button();
            label6 = new Label();
            btnNew = new Guna.UI2.WinForms.Guna2Button();
            btnDelete = new Guna.UI2.WinForms.Guna2Button();
            btnEdit = new Guna.UI2.WinForms.Guna2Button();
            btnAdd = new Guna.UI2.WinForms.Guna2Button();
            txtIdProducto = new TextBox();
            label5 = new Label();
            txtStock = new TextBox();
            label4 = new Label();
            txtPrecio = new TextBox();
            label3 = new Label();
            txtNombreProducto = new TextBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)guna2CirclePictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(420, 558);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersWidth = 51;
            dgvProductos.Size = new Size(1131, 442);
            dgvProductos.TabIndex = 0;
            dgvProductos.CellClick += dgvProductos_CellClick;
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
            panel1.TabIndex = 37;
            // 
            // guna2CirclePictureBox1
            // 
            guna2CirclePictureBox1.Image = Properties.Resources.RosticeríaSabrosonPNG;
            guna2CirclePictureBox1.ImageRotate = 0F;
            guna2CirclePictureBox1.Location = new Point(1772, 5);
            guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            guna2CirclePictureBox1.ShadowDecoration.CustomizableEdges = customizableEdges1;
            guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            guna2CirclePictureBox1.Size = new Size(105, 105);
            guna2CirclePictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            guna2CirclePictureBox1.TabIndex = 67;
            guna2CirclePictureBox1.TabStop = false;
            // 
            // btnBack
            // 
            btnBack.BackgroundImageLayout = ImageLayout.Stretch;
            btnBack.BorderRadius = 20;
            btnBack.BorderStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
            btnBack.CustomizableEdges = customizableEdges2;
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
            btnBack.ShadowDecoration.CustomizableEdges = customizableEdges3;
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
            label6.Size = new Size(145, 38);
            label6.TabIndex = 9;
            label6.Text = "Producto";
            // 
            // btnNew
            // 
            btnNew.BorderRadius = 30;
            btnNew.BorderThickness = 2;
            btnNew.CustomizableEdges = customizableEdges4;
            btnNew.DisabledState.BorderColor = Color.DarkGray;
            btnNew.DisabledState.CustomBorderColor = Color.DarkGray;
            btnNew.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnNew.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnNew.FillColor = Color.FromArgb(56, 182, 255);
            btnNew.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold);
            btnNew.ForeColor = Color.Black;
            btnNew.Image = Properties.Resources.advertencia;
            btnNew.ImageAlign = HorizontalAlignment.Right;
            btnNew.ImageOffset = new Point(40, 0);
            btnNew.ImageSize = new Size(40, 40);
            btnNew.Location = new Point(1384, 392);
            btnNew.Name = "btnNew";
            btnNew.ShadowDecoration.CustomizableEdges = customizableEdges5;
            btnNew.Size = new Size(280, 62);
            btnNew.TabIndex = 65;
            btnNew.Text = "Nuevo";
            btnNew.TextOffset = new Point(-20, 0);
            btnNew.Click += btnNew_Click;
            // 
            // btnDelete
            // 
            btnDelete.BorderRadius = 30;
            btnDelete.BorderThickness = 2;
            btnDelete.CustomizableEdges = customizableEdges6;
            btnDelete.DisabledState.BorderColor = Color.DarkGray;
            btnDelete.DisabledState.CustomBorderColor = Color.DarkGray;
            btnDelete.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnDelete.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnDelete.FillColor = Color.FromArgb(230, 52, 52);
            btnDelete.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold);
            btnDelete.ForeColor = Color.Black;
            btnDelete.Image = Properties.Resources.error;
            btnDelete.ImageAlign = HorizontalAlignment.Right;
            btnDelete.ImageOffset = new Point(10, 0);
            btnDelete.ImageSize = new Size(50, 50);
            btnDelete.Location = new Point(1027, 133);
            btnDelete.Name = "btnDelete";
            btnDelete.ShadowDecoration.CustomizableEdges = customizableEdges7;
            btnDelete.Size = new Size(280, 62);
            btnDelete.TabIndex = 64;
            btnDelete.Text = "Eliminar";
            btnDelete.TextOffset = new Point(-20, 0);
            btnDelete.Visible = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.BorderRadius = 30;
            btnEdit.BorderThickness = 2;
            btnEdit.CustomizableEdges = customizableEdges8;
            btnEdit.DisabledState.BorderColor = Color.DarkGray;
            btnEdit.DisabledState.CustomBorderColor = Color.DarkGray;
            btnEdit.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnEdit.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnEdit.FillColor = Color.FromArgb(246, 202, 19);
            btnEdit.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold);
            btnEdit.ForeColor = Color.Black;
            btnEdit.Image = Properties.Resources.icons8_crear_nuevo_50;
            btnEdit.ImageAlign = HorizontalAlignment.Right;
            btnEdit.ImageOffset = new Point(20, 0);
            btnEdit.ImageSize = new Size(50, 50);
            btnEdit.Location = new Point(857, 392);
            btnEdit.Name = "btnEdit";
            btnEdit.ShadowDecoration.CustomizableEdges = customizableEdges9;
            btnEdit.Size = new Size(280, 62);
            btnEdit.TabIndex = 63;
            btnEdit.Text = "Editar";
            btnEdit.TextOffset = new Point(-30, 0);
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.BorderRadius = 30;
            btnAdd.BorderThickness = 2;
            btnAdd.CustomizableEdges = customizableEdges10;
            btnAdd.DisabledState.BorderColor = Color.DarkGray;
            btnAdd.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAdd.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAdd.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAdd.FillColor = Color.FromArgb(126, 218, 81);
            btnAdd.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold);
            btnAdd.ForeColor = Color.Black;
            btnAdd.Image = Properties.Resources.anadir;
            btnAdd.ImageAlign = HorizontalAlignment.Right;
            btnAdd.ImageOffset = new Point(10, 0);
            btnAdd.ImageSize = new Size(50, 50);
            btnAdd.Location = new Point(295, 392);
            btnAdd.Name = "btnAdd";
            btnAdd.ShadowDecoration.CustomizableEdges = customizableEdges11;
            btnAdd.Size = new Size(280, 62);
            btnAdd.TabIndex = 62;
            btnAdd.Text = "Agregar";
            btnAdd.TextOffset = new Point(-20, 0);
            btnAdd.Click += btnAdd_Click;
            // 
            // txtIdProducto
            // 
            txtIdProducto.Enabled = false;
            txtIdProducto.Location = new Point(346, 288);
            txtIdProducto.Margin = new Padding(3, 4, 3, 4);
            txtIdProducto.Name = "txtIdProducto";
            txtIdProducto.Size = new Size(179, 27);
            txtIdProducto.TabIndex = 61;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label5.ImeMode = ImeMode.NoControl;
            label5.Location = new Point(346, 221);
            label5.Name = "label5";
            label5.Size = new Size(179, 31);
            label5.TabIndex = 60;
            label5.Text = "Id del producto";
            // 
            // txtStock
            // 
            txtStock.Location = new Point(1451, 288);
            txtStock.Margin = new Padding(3, 4, 3, 4);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(139, 27);
            txtStock.TabIndex = 59;
            txtStock.KeyPress += txtStock_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label4.ImeMode = ImeMode.NoControl;
            label4.Location = new Point(1478, 221);
            label4.Name = "label4";
            label4.Size = new Size(73, 31);
            label4.TabIndex = 58;
            label4.Text = "Stock";
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(1091, 288);
            txtPrecio.Margin = new Padding(3, 4, 3, 4);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(171, 27);
            txtPrecio.TabIndex = 57;
            txtPrecio.KeyPress += txtPrecio_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label3.ImeMode = ImeMode.NoControl;
            label3.Location = new Point(1135, 221);
            label3.Name = "label3";
            label3.Size = new Size(81, 31);
            label3.TabIndex = 56;
            label3.Text = "Precio";
            // 
            // txtNombreProducto
            // 
            txtNombreProducto.Location = new Point(686, 288);
            txtNombreProducto.Margin = new Padding(3, 4, 3, 4);
            txtNombreProducto.Name = "txtNombreProducto";
            txtNombreProducto.Size = new Size(246, 27);
            txtNombreProducto.TabIndex = 55;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label2.ImeMode = ImeMode.NoControl;
            label2.Location = new Point(686, 221);
            label2.Name = "label2";
            label2.Size = new Size(246, 31);
            label2.TabIndex = 54;
            label2.Text = "Nombre del producto";
            // 
            // FrmProductos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1902, 1033);
            Controls.Add(btnNew);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(txtIdProducto);
            Controls.Add(label5);
            Controls.Add(txtStock);
            Controls.Add(label4);
            Controls.Add(txtPrecio);
            Controls.Add(label3);
            Controls.Add(txtNombreProducto);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(dgvProductos);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmProductos";
            Text = "Productos";
            WindowState = FormWindowState.Maximized;
            Load += FrmProductos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)guna2CirclePictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvProductos;
        private Panel panel1;
        private Label label6;
        private Guna.UI2.WinForms.Guna2Button btnNew;
        private Guna.UI2.WinForms.Guna2Button btnDelete;
        private Guna.UI2.WinForms.Guna2Button btnEdit;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private TextBox txtIdProducto;
        private Label label5;
        private TextBox txtStock;
        private Label label4;
        private TextBox txtPrecio;
        private Label label3;
        private TextBox txtNombreProducto;
        private Label label2;
        private Guna.UI2.WinForms.Guna2Button btnBack;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
    }
}