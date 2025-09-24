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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcComplements));
            btnIncreaseProduct = new Guna.UI2.WinForms.Guna2Button();
            btnDecreaseProduct = new Guna.UI2.WinForms.Guna2Button();
            lblNameOfProduct = new Label();
            lblPrice = new Label();
            pbImage = new PictureBox();
            lblStock = new Label();
            lblTotal = new Label();
            txtAmount = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pbImage).BeginInit();
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
            btnIncreaseProduct.Location = new Point(95, 169);
            btnIncreaseProduct.Name = "btnIncreaseProduct";
            btnIncreaseProduct.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnIncreaseProduct.Size = new Size(49, 49);
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
            btnDecreaseProduct.Location = new Point(2, 169);
            btnDecreaseProduct.Name = "btnDecreaseProduct";
            btnDecreaseProduct.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnDecreaseProduct.Size = new Size(49, 49);
            btnDecreaseProduct.TabIndex = 21;
            btnDecreaseProduct.Text = "➖";
            btnDecreaseProduct.Click += btnDecreaseProduct_Click;
            // 
            // lblNameOfProduct
            // 
            lblNameOfProduct.AutoSize = true;
            lblNameOfProduct.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblNameOfProduct.Location = new Point(4, 112);
            lblNameOfProduct.Name = "lblNameOfProduct";
            lblNameOfProduct.Size = new Size(102, 31);
            lblNameOfProduct.TabIndex = 19;
            lblNameOfProduct.Text = "Nombre";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPrice.Location = new Point(126, 146);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(56, 20);
            lblPrice.TabIndex = 22;
            lblPrice.Text = "Precio:";
            // 
            // pbImage
            // 
            pbImage.BackgroundImage = (Image)resources.GetObject("pbImage.BackgroundImage");
            pbImage.BackgroundImageLayout = ImageLayout.Stretch;
            pbImage.Location = new Point(-1, 0);
            pbImage.Name = "pbImage";
            pbImage.Size = new Size(199, 109);
            pbImage.SizeMode = PictureBoxSizeMode.StretchImage;
            pbImage.TabIndex = 24;
            pbImage.TabStop = false;
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStock.Location = new Point(0, 0);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(52, 20);
            lblStock.TabIndex = 23;
            lblStock.Text = "Stock:";
            lblStock.Visible = false;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(146, 187);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(49, 20);
            lblTotal.TabIndex = 25;
            lblTotal.Text = "$0.00";
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(53, 180);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(40, 27);
            txtAmount.TabIndex = 26;
            txtAmount.TextChanged += txtAmount_TextChanged;
            // 
            // UcComplements
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 203, 20);
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(txtAmount);
            Controls.Add(lblTotal);
            Controls.Add(pbImage);
            Controls.Add(lblStock);
            Controls.Add(lblPrice);
            Controls.Add(btnIncreaseProduct);
            Controls.Add(btnDecreaseProduct);
            Controls.Add(lblNameOfProduct);
            Name = "UcComplements";
            Size = new Size(198, 231);
            ((System.ComponentModel.ISupportInitialize)pbImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnIncreaseProduct;
        private Guna.UI2.WinForms.Guna2Button btnDecreaseProduct;
        private Label lblNameOfProduct;
        private Label lblAmount;
        private Label lblPrice;
        private PictureBox pbImage;
        private Label lblStock;
        private Label lblTotal;
        private TextBox txtAmount;
    }
}
