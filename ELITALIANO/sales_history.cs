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
    public partial class sales_history : Form
    {
        DataTable dbDataSet;
        public static string parsingString;
        bool isSeleceted;
        public sales_history()
        {
            InitializeComponent();
            LoadTable();
            FillCombo();
            cal_total_all();
            cal_discount_all();
            cal_cash_all();
            cal_balance_all();
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            isSeleceted = false;
        }

        public void LoadTable()
        {
            try
            {
                MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                MySqlCommand SelectCom = new MySqlCommand("select invoiceNum as 'Invoice', date as 'Date(mm-dd-yyyy)',time as 'Time',details as 'Details',totalBill as 'Bill',discount as 'Discount', cashPaid as 'Paid', balance as 'Balance' from sales_invoice ", myConn);

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
                MySqlCommand SelectCom = new MySqlCommand("select invoiceNum as 'Invoice', date as 'Date(mm-dd-yyyy)',time as 'Time',details as 'Details',totalBill as 'Bill',discount as 'Discount', cashPaid as 'Paid', balance as 'Balance' from sales_invoice where date between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'", myConn);

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

        //total bill
        void cal_total_all()
        {
            try
            {
                MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                MySqlCommand SelectCom = new MySqlCommand("select Sum(totalBill) from sales_invoice ", myConn);
                MySqlDataReader myReader;

                myConn.Open();
                myReader = SelectCom.ExecuteReader();

                while (myReader.Read())
                {
                    Decimal s = myReader.GetDecimal("Sum(totalBill)");
                    String sum = s.ToString();


                    textBox2.Text = sum;

                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show("You have nothing in your list");
                textBox2.Text = "0.00";

            }
        }

        //total discount
        void cal_discount_all()
        {
            try
            {
                MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                MySqlCommand SelectCom = new MySqlCommand("select Sum(discount) from sales_invoice ", myConn);
                MySqlDataReader myReader;

                myConn.Open();
                myReader = SelectCom.ExecuteReader();

                while (myReader.Read())
                {
                    Decimal s = myReader.GetDecimal("Sum(discount)");
                    String sum = s.ToString();


                    textBox3.Text = sum;

                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show("You have nothing in your list");
                textBox3.Text = "0.00";

            }
        }

        //total cash paid
        void cal_cash_all()
        {
            try
            {
                MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                MySqlCommand SelectCom = new MySqlCommand("select Sum(cashPaid) from sales_invoice ", myConn);
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

        //total balance
        void cal_balance_all()
        {
            try
            {
                MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                MySqlCommand SelectCom = new MySqlCommand("select Sum(balance) from sales_invoice ", myConn);
                MySqlDataReader myReader;

                myConn.Open();
                myReader = SelectCom.ExecuteReader();

                while (myReader.Read())
                {
                    Decimal s = myReader.GetDecimal("Sum(balance)");
                    String sum = s.ToString();


                    textBox5.Text = sum;

                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show("You have nothing in your list");
                textBox5.Text = "0.00";

            }
        }

        //total bill between two dates
        void cal_total_Between_Dates()
        {
            try
            {
                MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                MySqlCommand SelectCom = new MySqlCommand("select Sum(totalBill) from sales_invoice where date between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "' ", myConn);
                MySqlDataReader myReader;

                myConn.Open();
                myReader = SelectCom.ExecuteReader();

                while (myReader.Read())
                {
                    Decimal s = myReader.GetDecimal("Sum(totalBill)");
                    String sum = s.ToString();


                    textBox2.Text = sum;

                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show("You have nothing in your list");
                textBox2.Text = "0.00";

            }
        }

        //discount between two dates
        void cal_discount_Between_Dates()
        {
            try
            {
                MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                MySqlCommand SelectCom = new MySqlCommand("select Sum(discount) from sales_invoice where date between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "' ", myConn);
                MySqlDataReader myReader;

                myConn.Open();
                myReader = SelectCom.ExecuteReader();

                while (myReader.Read())
                {
                    Decimal s = myReader.GetDecimal("Sum(discount)");
                    String sum = s.ToString();


                    textBox3.Text = sum;

                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show("You have nothing in your list");
                textBox3.Text = "0.00";

            }
        }

        //cash paid between two dates
        void cal_cash_Between_Dates()
        {
            try
            {
                MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                MySqlCommand SelectCom = new MySqlCommand("select Sum(cashPaid) from sales_invoice where date between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "' ", myConn);
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

        //balance between two dates
        void cal_balance_Between_Dates()
        {
            try
            {
                MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                MySqlCommand SelectCom = new MySqlCommand("select Sum(balance) from sales_invoice where date between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "' ", myConn);
                MySqlDataReader myReader;

                myConn.Open();
                myReader = SelectCom.ExecuteReader();

                while (myReader.Read())
                {
                    Decimal s = myReader.GetDecimal("Sum(balance)");
                    String sum = s.ToString();


                    textBox5.Text = sum;

                }

            }
            catch (Exception ex)
            {
                // MessageBox.Show("You have nothing in your list");
                textBox5.Text = "0.00";

            }
        }

        void FillCombo()
        {
            comboBox1.Items.Add("Date");
            comboBox1.Items.Add("Details");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Date")
            {
                groupBox1.Visible = true;
                groupBox2.Visible = false;
                isSeleceted = false;
            }
            if (comboBox1.Text == "Details")
            {
                groupBox2.Visible = true;
                groupBox1.Visible = false;
                isSeleceted = false;
            }
        }

        //date search button
        private void button1_Click(object sender, EventArgs e)
        {
            LoadTable_between_dates();
            cal_total_Between_Dates();
            cal_discount_Between_Dates();
            cal_cash_Between_Dates();
            cal_balance_Between_Dates();
            isSeleceted = false;
        }

        //view all in view by date
        private void button2_Click(object sender, EventArgs e)
        {
            LoadTable();
            cal_total_all();
            cal_discount_all();
            cal_cash_all();
            cal_balance_all();
            isSeleceted = false;
        }

        //search bar
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(dbDataSet);
            DV.RowFilter = string.Format("Details LIKE '%{0}%'", textBox1.Text);
            dataGridView1.DataSource = DV;

            String Total = DV.Table.Compute("SUM(Bill)", DV.RowFilter).ToString();
            String discount = DV.Table.Compute("SUM(Discount)", DV.RowFilter).ToString();
            String cash = DV.Table.Compute("SUM(Paid)", DV.RowFilter).ToString();
            String balance = DV.Table.Compute("SUM(Balance)", DV.RowFilter).ToString();

            if (Total == "" || discount == "" || cash == "" || balance == "")
            {
                textBox2.Text = "0.00";
                textBox3.Text = "0.00";
                textBox4.Text = "0.00";
                textBox5.Text = "0.00";
            }
            else
            {
                textBox2.Text = Total;
                textBox3.Text = discount;
                textBox4.Text = cash;
                textBox5.Text = balance;
            }
        }

        //open invoice
        private void button3_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            if (isSeleceted == false)
            {
                MessageBox.Show("You have not selected the invoice you want to view");
            }
            else
            {
                foreach (Form s in Application.OpenForms)
                {
                    if (s.Text == "Bill History")
                    {
                        IsOpen = true;
                        s.BringToFront();
                        break;
                    }
                }

                if (IsOpen == false)
                {
                    parsingString = label8.Text;
                    bill_history bh = new bill_history();
                    bh.Show();
                }
            }
        }

        //cell click
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                label8.Text = row.Cells["Invoice"].Value.ToString();
                textBox2.Text = row.Cells["Bill"].Value.ToString();
                textBox3.Text = row.Cells["Discount"].Value.ToString();
                textBox4.Text = row.Cells["Paid"].Value.ToString();
                textBox5.Text = row.Cells["Balance"].Value.ToString();
                isSeleceted = true;
            }
        }

        //view all in view by details
        private void button4_Click(object sender, EventArgs e)
        {
            LoadTable();
            cal_total_all();
            cal_discount_all();
            cal_cash_all();
            cal_balance_all();
            isSeleceted = false;
        }
    }
}
