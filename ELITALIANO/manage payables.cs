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
    public partial class manage_payables : Form
    {
        DataTable dbDataSet;
        public static string parsingString;
        bool isSeleceted;
        public manage_payables()
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
            buttonDisable();
        }
        //load table
        public void LoadTable()
        {
            try
            {
                MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                MySqlCommand SelectCom = new MySqlCommand("select invoiceNum as 'Invoice', date as 'Date(mm-dd-yyyy)',time as 'Time',details as 'Details',totalBill as 'Bill',discount as 'Discount', cashPaid as 'Paid', balance as 'Balance' from purchase_invoice ", myConn);

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
                MySqlCommand SelectCom = new MySqlCommand("select invoiceNum as 'Invoice', date as 'Date(mm-dd-yyyy)',time as 'Time',details as 'Details',totalBill as 'Bill',discount as 'Discount', cashPaid as 'Paid', balance as 'Balance' from purchase_invoice where date between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'", myConn);

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
                MySqlCommand SelectCom = new MySqlCommand("select Sum(totalBill) from purchase_invoice ", myConn);
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
                MySqlCommand SelectCom = new MySqlCommand("select Sum(discount) from purchase_invoice ", myConn);
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
                MySqlCommand SelectCom = new MySqlCommand("select Sum(cashPaid) from purchase_invoice ", myConn);
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
                MySqlCommand SelectCom = new MySqlCommand("select Sum(balance) from purchase_invoice ", myConn);
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
                MySqlCommand SelectCom = new MySqlCommand("select Sum(totalBill) from purchase_invoice where date between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "' ", myConn);
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
                MySqlCommand SelectCom = new MySqlCommand("select Sum(discount) from purchase_invoice where date between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "' ", myConn);
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
                MySqlCommand SelectCom = new MySqlCommand("select Sum(cashPaid) from purchase_invoice where date between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "' ", myConn);
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
                MySqlCommand SelectCom = new MySqlCommand("select Sum(balance) from purchase_invoice where date between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "' ", myConn);
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

        //Additional discount calculation function
        void newDiscount_cal()
        {
            try
            {
                Decimal newDiscount = Convert.ToDecimal(textBox6.Text);
                Decimal oldDiscount = Convert.ToDecimal(textBox3.Text);
                Decimal finalDiscount = newDiscount + oldDiscount;
                textBox3.Text = finalDiscount.ToString();
                Decimal newBalance = Convert.ToDecimal(textBox2.Text) - finalDiscount - Convert.ToDecimal(textBox4.Text);
                textBox5.Text = newBalance.ToString();
                //textBox6.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Additional payment calculation function
        void newPayment_cal()
        {
            try
            {
                Decimal newPayment = Convert.ToDecimal(textBox7.Text);
                Decimal oldPayment = Convert.ToDecimal(textBox4.Text);
                Decimal finalPayment = newPayment + oldPayment;
                textBox4.Text = finalPayment.ToString();
                Decimal newBalance = Convert.ToDecimal(textBox2.Text) - finalPayment - Convert.ToDecimal(textBox3.Text);
                textBox5.Text = newBalance.ToString();
                //textBox7.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //button disable function
        void buttonDisable()
        {
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button3.Enabled = false;
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
                textBox6.Text = "";
                textBox7.Text = "";
                buttonDisable();
            }
            if (comboBox1.Text == "Details")
            {
                groupBox2.Visible = true;
                groupBox1.Visible = false;
                isSeleceted = false;
                textBox6.Text = "";
                textBox7.Text = "";
                buttonDisable();
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
            buttonDisable();
            textBox6.Text = "";
            textBox7.Text = "";
        }

        //view all in view by detail
        private void button4_Click(object sender, EventArgs e)
        {
            LoadTable();
            cal_total_all();
            cal_discount_all();
            cal_cash_all();
            cal_balance_all();
            isSeleceted = false;
            buttonDisable();
            textBox6.Text = "";
            textBox7.Text = "";
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
            buttonDisable();
        }

        //select from grid
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
                textBox6.Enabled = true;
                textBox7.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button3.Enabled = true;
            }
        }

        //view all view by date
        private void button2_Click(object sender, EventArgs e)
        {
            LoadTable();
            cal_total_all();
            cal_discount_all();
            cal_cash_all();
            cal_balance_all();
            isSeleceted = false;
            buttonDisable();
            textBox6.Text = "";
            textBox7.Text = "";
        }

        //additional discount add button
        private void button5_Click(object sender, EventArgs e)
        {
            newDiscount_cal();
            textBox6.Enabled = false;
            button5.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            newPayment_cal();
            textBox7.Enabled = false;
            button6.Enabled = false;
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46 && ch != '-')
            {
                e.Handled = true;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46 && ch != '-')
            {
                e.Handled = true;
            }
        }

        //save button
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialog = MessageBox.Show("Are you Sure?", "Save", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                    MySqlCommand SelectCom = new MySqlCommand("update purchase_invoice set discount = '" + this.textBox3.Text + "',cashPaid = '" + this.textBox4.Text + "',balance = '" + this.textBox5.Text + "' where invoiceNum = '" + this.label8.Text + "';", myConn);
                    MySqlCommand SelectCom1 = new MySqlCommand("insert into cash_paid_to_suppliers (invoiceNum,date,time,cashPaid) values ('"+label8.Text+ "','" + dateTimePicker3.Text + "','" + DateTime.Now.ToLongTimeString() + "','" + textBox7.Text + "')", myConn);
                    MySqlDataReader myReader;
                    MySqlDataReader myReader1;

                    myConn.Open();
                    myReader = SelectCom.ExecuteReader();
                    myConn.Close();
                    myConn.Open();
                    myReader1 = SelectCom1.ExecuteReader();
                    MessageBox.Show("Changes Saved Succesfully");
                    LoadTable();
                    textBox6.Text = "";
                    textBox7.Text = "";

                }
                else if (dialog == DialogResult.No)
                {

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //close button
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult dialog = MessageBox.Show("Do you really want to exit?", "Exit", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                   

                    this.Close();

                }
                else if (dialog == DialogResult.No)
                {

                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
