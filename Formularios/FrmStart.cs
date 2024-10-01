using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RosticeriaCardelV2.Formularios
{
    public partial class FrmStart : Form
    {
        public FrmStart()
        {
            InitializeComponent();
        }

        private void btnPointOfSale_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmPointOfSale frm = new FrmPointOfSale();
            frm.ShowDialog();
            this.Show();
        }

        private void btnSalesHistory_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmSalesHistory frm = new FrmSalesHistory();
            frm.ShowDialog();
            this.Show();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmProductos frm = new FrmProductos();
            frm.ShowDialog();
            this.Show();
        }
    }
}
