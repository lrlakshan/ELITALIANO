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
    public partial class invoice_history : Form
    {
        DataTable dbDataSet;
        
        public invoice_history()
        {
            InitializeComponent();
            LoadTable_after_proceed();
            

        }

        public void LoadTable_after_proceed()
        {
            try
            {
                label1.Text = purchases_history.parsingString;
                MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                MySqlCommand SelectCom = new MySqlCommand("select pr.productName as 'Product Name',pr.purchasePrice as 'Unit Price',pu.amountPurchases as 'Qty',pu.amountPurchases*pr.purchasePrice as 'Value' from purchase pu inner join product pr ON pu.productID = pr.productID where pu.invoiceNum = '"+label1.Text+"' order by transactionNum ASC", myConn);

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

        private void invoice_history_Load(object sender, EventArgs e)
        {
            label1.Text = purchases_history.parsingString;
        }

        
    }
}
