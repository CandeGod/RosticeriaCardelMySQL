namespace RosticeriaCardelV2.Controls
{
    partial class UcComplements
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnIncreaseProduct = new Guna.UI2.WinForms.Guna2Button();
            btnDecreaseProduct = new Guna.UI2.WinForms.Guna2Button();
            lblNameOfProduct = new Label();
            lblAmount = new Label();
            lblPrice = new Label();
            lblStock = new Label();
            SuspendLayout();
            // 
            // btnIncreaseProduct
            // 
            btnIncreaseProduct.BorderRadius = 20;
            btnIncreaseProduct.CustomizableEdges = customizableEdges1;
            btnIncreaseProduct.DisabledState.BorderColor = Color.DarkGray;
            btnIncreaseProduct.DisabledState.CustomBorderColor = Color.DarkGray;
            btnIncreaseProduct.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnIncreaseProduct.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnIncreaseProduct.FillColor = Color.Green;
            btnIncreaseProduct.Font = new Font("Segoe UI", 9F);
            btnIncreaseProduct.ForeColor = Color.White;
            btnIncreaseProduct.Location = new Point(154, 208);
            btnIncreaseProduct.Name = "btnIncreaseProduct";
            btnIncreaseProduct.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnIncreaseProduct.Size = new Size(84, 99);
            btnIncreaseProduct.TabIndex = 20;
            btnIncreaseProduct.Text = "➕";
            btnIncreaseProduct.Click += btnIncreaseProduct_Click;
            // 
            // btnDecreaseProduct
            // 
            btnDecreaseProduct.BorderRadius = 20;
            btnDecreaseProduct.CustomizableEdges = customizableEdges3;
            btnDecreaseProduct.DisabledState.BorderColor = Color.DarkGray;
            btnDecreaseProduct.DisabledState.CustomBorderColor = Color.DarkGray;
            btnDecreaseProduct.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnDecreaseProduct.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnDecreaseProduct.FillColor = Color.FromArgb(192, 0, 0);
            btnDecreaseProduct.Font = new Font("Segoe UI", 9F);
            btnDecreaseProduct.ForeColor = Color.White;
            btnDecreaseProduct.Location = new Point(30, 208);
            btnDecreaseProduct.Name = "btnDecreaseProduct";
            btnDecreaseProduct.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnDecreaseProduct.Size = new Size(84, 99);
            btnDecreaseProduct.TabIndex = 21;
            btnDecreaseProduct.Text = "➖";
            btnDecreaseProduct.Click += btnDecreaseProduct_Click;
            // 
            // lblNameOfProduct
            // 
            lblNameOfProduct.AutoSize = true;
            lblNameOfProduct.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblNameOfProduct.Location = new Point(58, 38);
            lblNameOfProduct.Name = "lblNameOfProduct";
            lblNameOfProduct.Size = new Size(102, 31);
            lblNameOfProduct.TabIndex = 19;
            lblNameOfProduct.Text = "Nombre";
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblAmount.Location = new Point(58, 153);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(135, 31);
            lblAmount.TabIndex = 18;
            lblAmount.Text = "Cantidad: 0";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblPrice.Location = new Point(58, 100);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(87, 31);
            lblPrice.TabIndex = 22;
            lblPrice.Text = "Precio:";
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStock.Location = new Point(3, 15);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(52, 20);
            lblStock.TabIndex = 23;
            lblStock.Text = "Stock:";
            // 
            // UcComplements
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 203, 20);
            Controls.Add(lblStock);
            Controls.Add(lblPrice);
            Controls.Add(btnIncreaseProduct);
            Controls.Add(btnDecreaseProduct);
            Controls.Add(lblNameOfProduct);
            Controls.Add(lblAmount);
            Name = "UcComplements";
            Size = new Size(270, 330);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnIncreaseProduct;
        private Guna.UI2.WinForms.Guna2Button btnDecreaseProduct;
        private Label lblNameOfProduct;
        private Label lblAmount;
        private Label lblPrice;
        private Label lblStock;
    }
}
