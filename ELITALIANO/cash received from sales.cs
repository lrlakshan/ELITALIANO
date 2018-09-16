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
    public partial class cash_received_from_sales : Form
    {
        DataTable dbDataSet;
        public cash_received_from_sales()
        {
            InitializeComponent();
            LoadTable();
            cal_cash_all();
        }

        //load table
        public void LoadTable()
        {
            try
            {
                MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                MySqlCommand SelectCom = new MySqlCommand("select invoiceNum as 'Invoice', date as 'Date(mm-dd-yyyy)',time as 'Time', cashPaid as 'Paid' from cash_received_from_sales ", myConn);

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

        //load table between two dates
        void LoadTable_between_dates()
        {
            try
            {
                MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                MySqlCommand SelectCom = new MySqlCommand("select invoiceNum as 'Invoice', date as 'Date(mm-dd-yyyy)',time as 'Time', cashPaid as 'Paid' from cash_received_from_sales  where date between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'", myConn);

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

        //total cash paid
        void cal_cash_all()
        {
            try
            {
                MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                MySqlCommand SelectCom = new MySqlCommand("select Sum(cashPaid) from cash_received_from_sales ", myConn);
                MySqlDataReader myReader;

                myConn.Open();
                myReader = SelectCom.ExecuteReader();

                while (myReader.Read())
                {
                    Decimal s = myReader.GetDecimal("Sum(cashPaid)");
                    String sum = s.ToString();


                    textBox4.Text = sum;

                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show("You have nothing in your list");
                textBox4.Text = "0.00";

            }
        }
        //cash paid between two dates
        void cal_cash_Between_Dates()
        {
            try
            {
                MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                MySqlCommand SelectCom = new MySqlCommand("select Sum(cashPaid) from cash_received_from_sales where date between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "' ", myConn);
                MySqlDataReader myReader;

                myConn.Open();
                myReader = SelectCom.ExecuteReader();

                while (myReader.Read())
                {
                    Decimal s = myReader.GetDecimal("Sum(cashPaid)");
                    String sum = s.ToString();


                    textBox4.Text = sum;

                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show("You have nothing in your list");
                textBox4.Text = "0.00";

            }
        }

        //search bby date
        private void button1_Click(object sender, EventArgs e)
        {
            LoadTable_between_dates();
            cal_cash_Between_Dates();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            textBox4.Text = row.Cells["Paid"].Value.ToString();
        }

        //view all by date
        private void button2_Click(object sender, EventArgs e)
        {
            LoadTable();
            cal_cash_all();
        }
    }
}
