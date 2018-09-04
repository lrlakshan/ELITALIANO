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

            bool IsOpen = false;


            foreach (Form s in Application.OpenForms)
            {
                if (s.Text == "View Stocks")
                {
                    IsOpen = true;
                    s.BringToFront();
                    break;
                }
            }

            if (IsOpen == false)
            {
                view_stocks viewStocks = new view_stocks();
                viewStocks.Show();
            }

        }

        private void purchasesFromSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;


            foreach (Form s in Application.OpenForms)
            {
                if (s.Text == "Purchases From Suppliers")
                {
                    IsOpen = true;
                    s.BringToFront();
                    break;
                }
            }

            if (IsOpen == false)
            {
                purchases_from_suppliers ps = new purchases_from_suppliers();
                ps.Show();
            }
           
        }

        private void admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to close ELITALIANO program?", "Close", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {

                Application.Exit();
            }
            else if (dialog == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void addNewItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;


            foreach (Form s in Application.OpenForms)
            {
                if (s.Text == "Add/Remove/Change Items")
                {
                    IsOpen = true;
                    s.BringToFront();
                    break;
                }
            }

            if (IsOpen == false)
            {
                add_new_items addNewItems = new add_new_items();
                addNewItems.Show();
            }
        }

        private void expenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;


            foreach (Form s in Application.OpenForms)
            {
                if (s.Text == "Expenses")
                {
                    IsOpen = true;
                    s.BringToFront();
                    break;
                }
            }

            if (IsOpen == false)
            {
                expenses expenses = new expenses();
                expenses.Show();
            }
        }

        private void expensesHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;


            foreach (Form s in Application.OpenForms)
            {
                if (s.Text == "Expenses History")
                {
                    IsOpen = true;
                    s.BringToFront();
                    break;
                }
            }

            if (IsOpen == false)
            {
                expenses_history expensesHistory = new expenses_history();
                expensesHistory.Show();
            }
        }
    }
}
