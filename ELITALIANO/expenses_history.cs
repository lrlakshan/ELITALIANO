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
    public partial class expenses_history : Form
    {
        DataTable dbDataSet;
        public expenses_history()
        {
            InitializeComponent();
            LoadTable();
            FillCombo();
        }

        //load table 
        public void LoadTable()
        {
            try
            {
                MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                MySqlCommand SelectCom = new MySqlCommand("select transactionNUm as 'Transaction', date as 'Date(mm-dd-yyyy)',time as 'Time',details as 'Details',cost as 'Cost' from expenses ", myConn);

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

        void LoadTable_between_dates()
        {
            try
            {
                MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                MySqlCommand SelectCom = new MySqlCommand("select transactionNUm as 'Transaction', date as 'Date(mm-dd-yyyy)',time as 'Time',details as 'Details',cost as 'Cost' from expenses where date between '"+dateTimePicker1.Text+ "' and '" + dateTimePicker2.Text + "'", myConn);

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

        void FillCombo()
        {
            comboBox1.Items.Add("Date");
            comboBox1.Items.Add("Details");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(dbDataSet);
            DV.RowFilter = string.Format("Details LIKE '%{0}%'", textBox1.Text);
            dataGridView1.DataSource = DV;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadTable_between_dates();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadTable();
        }

       
    }
}
