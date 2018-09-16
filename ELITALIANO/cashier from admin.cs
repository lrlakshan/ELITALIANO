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
    public partial class cashier_from_admin : Form
    {
        DataTable dbDataSet;
        public cashier_from_admin()
        {
            InitializeComponent();
            LoadTable();
            FillCombo();
            LoadInvoiceNumber();
            button4.Enabled = false;
        }
        public void LoadTable()
        {
            try
            {
                MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                MySqlCommand SelectCom = new MySqlCommand("select s.transactionNum as 'Transaction',pr.productID as 'Product ID',pr.productName as 'Product Name',pr.sellingPrice as 'Sales Price',s.amount as 'Purchased Amount',s.amount*pr.sellingPrice as 'Value' from sales s inner join product pr ON s.productID = pr.productID where s.invoiceNum = (SELECT MAX(invoiceNum)+1 from sales) order by transactionNum ASC", myConn);

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
        //this table loads after add button pressed
        public void LoadTable_after_press_add()
        {
            try
            {
                MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                MySqlCommand SelectCom = new MySqlCommand("select s.transactionNum as 'Transaction',pr.productID as 'Product ID',pr.productName as 'Product Name',pr.sellingPrice as 'Sales Price',s.amount as 'Purchased Amount',s.amount*pr.sellingPrice as 'Value' from sales s inner join product pr ON s.productID = pr.productID where s.invoiceNum = (SELECT MAX(invoiceNum) from sales) order by transactionNum ASC", myConn);

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
        //load table after delete
        public void LoadTable_after_press_delete()
        {
            try
            {
                MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                MySqlCommand SelectCom = new MySqlCommand("select s.transactionNum as 'Transaction',pr.productID as 'Product ID',pr.productName as 'Product Name',pr.sellingPrice as 'Sales Price',s.amount as 'Purchased Amount',s.amount*pr.sellingPrice as 'Value' from sales s inner join product pr ON s.productID = pr.productID where s.invoiceNum = '" + label7.Text + "' order by transactionNum ASC", myConn);

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
        //fill the invoice number
        public void LoadInvoiceNumber()
        {
            try
            {
                MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                MySqlCommand SelectCom = new MySqlCommand("select Max(invoiceNum) from sales ", myConn);
                MySqlDataReader myReader;

                myConn.Open();
                myReader = SelectCom.ExecuteReader();

                while (myReader.Read())
                {
                    int s = myReader.GetInt32("Max(invoiceNum)") + 1;
                    String sIV = s.ToString();


                    label7.Text = sIV;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void FillCombo()
        {
            try
            {
                MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                MySqlCommand SelectCom = new MySqlCommand("select * from product ", myConn);
                MySqlDataReader myReader;

                myConn.Open();
                myReader = SelectCom.ExecuteReader();

                while (myReader.Read())
                {
                    String sName = myReader.GetString("productName");
                    comboBox1.Items.Add(sName);
                }
                comboBox1.Items.Add("None");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //calculate the total bill
        public void Cal_total_amount()
        {
            try
            {
                MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                MySqlCommand SelectCom = new MySqlCommand("select Sum(s.amount*pr.sellingPrice) from sales s, product pr where s.invoiceNum = '" + label7.Text + "' && s.productID = pr.productID ", myConn);
                MySqlDataReader myReader;

                myConn.Open();
                myReader = SelectCom.ExecuteReader();

                while (myReader.Read())
                {
                    Decimal s = myReader.GetDecimal("Sum(s.amount*pr.sellingPrice)");
                    String sTA = s.ToString();


                    textBox4.Text = sTA;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("You have nothing in your list");
                textBox4.Text = "";

            }
        }

        //add button
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "" || textBox1.Text == "" || textBox5.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("You have not selected a new item form the dropdown menu to add");
                }
                else if (textBox3.Text == "")
                {
                    MessageBox.Show("You have not entered the amount purchased");

                }
                else if (Convert.ToInt32(textBox3.Text) < 1)
                {
                    MessageBox.Show("You have entered invalid number to amount purchased");
                }
                else
                {
                    MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                    MySqlCommand SelectCom = new MySqlCommand("insert into sales  (invoiceNum,date,time,productID,amount) values ('" + label7.Text + "','" + dateTimePicker1.Text + "','" + DateTime.Now.ToLongTimeString() + "','" + textBox1.Text + "','" + textBox3.Text + "') ", myConn);
                    MySqlDataReader myReader;

                    myConn.Open();
                    myReader = SelectCom.ExecuteReader();
                    comboBox1.Text = "";
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox5.Text = "";
                    //MessageBox.Show("Saved");
                    LoadTable_after_press_add();
                    Cal_total_amount();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //delete button
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "" || textBox1.Text == "" || textBox5.Text == "" || textBox3.Text == "" || textBox2.Text != "")
                {
                    MessageBox.Show("You have not selected the transaction you want to remove");
                }
                else
                {
                    DialogResult dialog = MessageBox.Show("Do you really want to delete this transaction?", "Delete", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                        MySqlCommand SelectCom = new MySqlCommand("delete from sales where transactionNum = '" + label8.Text + "'", myConn);
                        MySqlDataReader myReader;

                        myConn.Open();
                        myReader = SelectCom.ExecuteReader();
                        comboBox1.Text = "";
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox5.Text = "";
                        label8.Text = "";
                        //MessageBox.Show("Saved");
                    }
                    else if (dialog == DialogResult.No)
                    {

                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            LoadTable_after_press_delete();
            Cal_total_amount();
        }

        //update which has already inserted
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "" || textBox1.Text == "" || textBox5.Text == "" || textBox3.Text == "" || textBox2.Text != "")
                {
                    MessageBox.Show("You have not selected the transaction you want to change");
                }
                else
                {
                    DialogResult dialog = MessageBox.Show("Do you really want to change this transaction?", "Change", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                        MySqlCommand SelectCom = new MySqlCommand("update sales set transactionNum = '" + this.label8.Text + "',invoiceNum = '" + this.label7.Text + "',date = '" + this.dateTimePicker1.Text + "',productID = '" + this.textBox1.Text + "',amount = '" + this.textBox3.Text + "',time = '" + DateTime.Now.ToLongTimeString() + "' where transactionNum = '" + this.label8.Text + "';", myConn);
                        MySqlDataReader myReader;

                        myConn.Open();
                        myReader = SelectCom.ExecuteReader();
                        comboBox1.Text = "";
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox5.Text = "";
                        label8.Text = "";
                        //MessageBox.Show("Saved");
                    }
                    else if (dialog == DialogResult.No)
                    {

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            LoadTable_after_press_delete();
            Cal_total_amount();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        //proceed button
        private void button4_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;


            foreach (Form s in Application.OpenForms)
            {
                if (s.Text == "Final Bill")
                {
                    IsOpen = true;
                    s.BringToFront();
                    break;
                }
            }

            if (IsOpen == false)
            {
                final_bill_for_admin_cashier fi = new final_bill_for_admin_cashier();
                fi.Owner = this;
                fi.Show();

            }
        }

        //hide proceed button until atleast one item added
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            button4.Enabled = !string.IsNullOrEmpty(textBox4.Text);
        }

        //close form
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult dialog = MessageBox.Show("Do you really want to clear the bill?", "Clear", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                    MySqlCommand SelectCom = new MySqlCommand("delete from sales where invoiceNum = '" + label7.Text + "'", myConn);
                    MySqlDataReader myReader;

                    myConn.Open();
                    myReader = SelectCom.ExecuteReader();

                    this.Close();
                    cashier_from_admin c = new cashier_from_admin();
                    c.Show();

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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                comboBox1.Text = row.Cells["Product Name"].Value.ToString();
                label8.Text = row.Cells["Transaction"].Value.ToString();
                textBox1.Text = row.Cells["Product ID"].Value.ToString();
                textBox5.Text = row.Cells["Sales Price"].Value.ToString();
                textBox2.Text = "";
                textBox3.Text = row.Cells["Purchased Amount"].Value.ToString();
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                MySqlCommand SelectCom = new MySqlCommand("select productID,amountAvailable,sellingPrice from product where productName = '" + comboBox1.Text + "'; ", myConn);
                MySqlDataReader myReader;

                myConn.Open();
                myReader = SelectCom.ExecuteReader();

                while (myReader.Read())
                {
                    String sPID = myReader.GetInt32("productID").ToString();
                    String sAA = myReader.GetInt32("amountAvailable").ToString();
                    String sPP = myReader.GetDecimal("sellingPrice").ToString();

                    textBox1.Text = sPID;
                    textBox2.Text = sAA;
                    textBox5.Text = sPP;
                }
                if (comboBox1.Text == "None")
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox5.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //form close
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult dialog = MessageBox.Show("Do you really want to exit without proceeding?", "Exit", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                    MySqlCommand SelectCom = new MySqlCommand("delete from sales where invoiceNum = '" + label7.Text + "'", myConn);
                    MySqlDataReader myReader;

                    myConn.Open();
                    myReader = SelectCom.ExecuteReader();

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
