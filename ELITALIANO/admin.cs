using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ELITALIANO
{
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }

        private void viewStocksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            view_stocks viewStocks = new view_stocks();
            viewStocks.Show();
        }

        private void purchasesFromSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            purchases_from_suppliers ps = new purchases_from_suppliers();
            ps.Show();
        }
    }
}
