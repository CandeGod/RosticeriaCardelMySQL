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
            cbProductos.Location = new Point(548, 114);
            cbProductos.Name = "cbProductos";
            cbProductos.Size = new Size(151, 28);
            cbProductos.TabIndex = 2;
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Location = new Point(243, 212);
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
            btnAddVariacion.Text = "button1";
            btnAddVariacion.UseVisualStyleBackColor = true;
            btnAddVariacion.Click += btnAddVariacion_Click;
            // 
            // FrmAgregarVariacion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}