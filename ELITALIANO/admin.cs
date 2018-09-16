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

        private void purchasesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;


            foreach (Form s in Application.OpenForms)
            {
                if (s.Text == "Purchases History")
                {
                    IsOpen = true;
                    s.BringToFront();
                    break;
                }
            }

            if (IsOpen == false)
            {
                purchases_history purchasesHistory = new purchases_history();
                purchasesHistory.Show();
            }
        }

        private void managePayablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;


            foreach (Form s in Application.OpenForms)
            {
                if (s.Text == "Manage Payables")
                {
                    IsOpen = true;
                    s.BringToFront();
                    break;
                }
            }

            if (IsOpen == false)
            {
                manage_payables managePayables = new manage_payables();
                managePayables.Show();
            }
        }

        private void cashPaidToSuppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;


            foreach (Form s in Application.OpenForms)
            {
                if (s.Text == "Cash Paid to Suppliers")
                {
                    IsOpen = true;
                    s.BringToFront();
                    break;
                }
            }

            if (IsOpen == false)
            {
                cash_paid_to_suppliers cashPaidToSuppliers = new cash_paid_to_suppliers();
                cashPaidToSuppliers.Show();
            }
        }

        private void addExpensesToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;


            foreach (Form s in Application.OpenForms)
            {
                if (s.Text == "Sales History")
                {
                    IsOpen = true;
                    s.BringToFront();
                    break;
                }
            }

            if (IsOpen == false)
            {
                sales_history salesHistory = new sales_history();
                salesHistory.Show();
            }
        }

        private void cashReceivedFromSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;


            foreach (Form s in Application.OpenForms)
            {
                if (s.Text == "Cash Received from Sales")
                {
                    IsOpen = true;
                    s.BringToFront();
                    break;
                }
            }

            if (IsOpen == false)
            {
                cash_received_from_sales cashReceivedFromSales = new cash_received_from_sales();
                cashReceivedFromSales.Show();
            }
        }

        private void manageReceivablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;


            foreach (Form s in Application.OpenForms)
            {
                if (s.Text == "Manage Receivables")
                {
                    IsOpen = true;
                    s.BringToFront();
                    break;
                }
            }

            if (IsOpen == false)
            {
                manage_receivables manageReceivables = new manage_receivables();
                manageReceivables.Show();
            }
        }

        private void summaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;


            foreach (Form s in Application.OpenForms)
            {
                if (s.Text == "Summary")
                {
                    IsOpen = true;
                    s.BringToFront();
                    break;
                }
            }

            if (IsOpen == false)
            {
                summary Summary = new summary();
                Summary.Show();
            }
        }

        

        private void logoutFromAdminToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();

            Admin_Login AL = new Admin_Login();
            AL.Show();
        }

        private void cashierLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            bool IsOpen = false;


            foreach (Form s in Application.OpenForms)
            {
                if (s.Text == "Admin Cashier")
                {
                    IsOpen = true;
                    s.BringToFront();
                    break;
                }
            }

            if (IsOpen == false)
            {
                cashier_from_admin c = new cashier_from_admin();
                c.Show();
            }
        }
    }
}
