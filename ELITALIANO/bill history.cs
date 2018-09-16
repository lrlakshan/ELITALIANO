using MySql.Data.MySqlClient;
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
    public partial class bill_history : Form
    {
        DataTable dbDataSet;
        public bill_history()
        {
            InitializeComponent();
            LoadTable_after_proceed();

        }

        public void LoadTable_after_proceed()
        {
            try
            {
                label1.Text = sales_history.parsingString;
                MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                MySqlCommand SelectCom = new MySqlCommand("select pr.productName as 'Product Name',pr.purchasePrice as 'Unit Price',s.amount as 'Qty',s.amount*pr.sellingPrice as 'Value' from sales s inner join product pr ON s.productID = pr.productID where s.invoiceNum = '" + label1.Text + "' order by transactionNum ASC", myConn);

                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = SelectCom;
                dbDataSet = new DataTable();
                sda.Fill(dbDataSet);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbDataSet;
                dataGridView1.DataSource = bSource;
                sda.Update(dbDataSet);

                myConn.Open();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       

        private void bill_history_Load_1(object sender, EventArgs e)
        {
            label1.Text = sales_history.parsingString;
        }
    }
}
