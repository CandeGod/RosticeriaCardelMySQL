namespace RosticeriaCardelV2.Formularios
{
    partial class FrmAgregarVariacion
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
            txtNombreVariacion = new TextBox();
            txtPrecioVariacion = new TextBox();
            cbProductos = new ComboBox();
            chkActivo = new CheckBox();
            btnAddVariacion = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // txtNombreVariacion
            // 
            txtNombreVariacion.Location = new Point(125, 92);
            txtNombreVariacion.Name = "txtNombreVariacion";
            txtNombreVariacion.Size = new Size(125, 27);
            txtNombreVariacion.TabIndex = 0;
            // 
            // txtPrecioVariacion
            // 
            txtPrecioVariacion.Location = new Point(304, 94);
            txtPrecioVariacion.Name = "txtPrecioVariacion";
            txtPrecioVariacion.Size = new Size(125, 27);
            txtPrecioVariacion.TabIndex = 1;
            // 
            // cbProductos
            // 
            cbProductos.FormattingEnabled = true;
            cbProductos.Location = new Point(545, 94);
            cbProductos.Name = "cbProductos";
            cbProductos.Size = new Size(151, 28);
            cbProductos.TabIndex = 2;
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Location = new Point(624, 215);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(101, 24);
            chkActivo.TabIndex = 3;
            chkActivo.Text = "checkBox1";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // btnAddVariacion
            // 
            btnAddVariacion.Location = new Point(314, 307);
            btnAddVariacion.Name = "btnAddVariacion";
            btnAddVariacion.Size = new Size(94, 29);
            btnAddVariacion.TabIndex = 4;
            btnAddVariacion.Text = "Agregar";
            btnAddVariacion.UseVisualStyleBackColor = true;
            btnAddVariacion.Click += btnAddVariacion_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(125, 57);
            label1.Name = "label1";
            label1.Size = new Size(125, 20);
            label1.TabIndex = 5;
            label1.Text = "NombreVariacion";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(314, 57);
            label2.Name = "label2";
            label2.Size = new Size(111, 20);
            label2.TabIndex = 6;
            label2.Text = "PrecioVariacion";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(559, 57);
            label3.Name = "label3";
            label3.Size = new Size(130, 20);
            label3.TabIndex = 7;
            label3.Text = "VariacionProducto";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(606, 181);
            label4.Name = "label4";
            label4.Size = new Size(58, 20);
            label4.TabIndex = 8;
            label4.Text = "Activo?";
            // 
            // FrmAgregarVariacion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnAddVariacion);
            Controls.Add(chkActivo);
            Controls.Add(cbProductos);
            Controls.Add(txtPrecioVariacion);
            Controls.Add(txtNombreVariacion);
            Name = "FrmAgregarVariacion";
            Text = "FrmAgregarVariacion";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombreVariacion;
        private TextBox txtPrecioVariacion;
        private ComboBox cbProductos;
        private CheckBox chkActivo;
        private Button btnAddVariacion;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}