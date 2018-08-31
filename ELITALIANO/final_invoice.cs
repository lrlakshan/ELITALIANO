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
    
    public partial class final_invoice : Form
    {
        DataTable dbDataSet;

        public final_invoice()
        {
            InitializeComponent();
            LoadTable_after_proceed();
            LoadInvoiceNumber();
            Cal_total_amount();
            
        }
        public void LoadTable_after_proceed()
        {
            try
            {
                MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                MySqlCommand SelectCom = new MySqlCommand("select pr.productID as 'Product ID',pr.productName as 'Product Name',pr.purchasePrice as 'Purchase Price',pu.amountPurchases as 'Purchased Amount',pu.amountPurchases*pr.purchasePrice as 'Value' from purchase pu inner join product pr ON pu.productID = pr.productID where pu.invoiceNum = (SELECT MAX(invoiceNum) from purchase) order by transactionNum ASC", myConn);

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
        //calculate the total bill
        public void Cal_total_amount()
        {
            try
            {
                MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                MySqlCommand SelectCom = new MySqlCommand("select Sum(pu.amountPurchases*pr.purchasePrice) from purchase pu, product pr where pu.invoiceNum = '" + label7.Text + "' && pu.productID = pr.productID ", myConn);
                MySqlDataReader myReader;

                myConn.Open();
                myReader = SelectCom.ExecuteReader();

                while (myReader.Read())
                {
                    Decimal s = myReader.GetDecimal("Sum(pu.amountPurchases*pr.purchasePrice)");
                    String sTA = s.ToString();


                    textBox1.Text = sTA;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("You have nothing in your list");
                textBox1.Text = "";

            }
        }
        //fill the invoice number
        public void LoadInvoiceNumber()
        {
            try
            {
                MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                MySqlCommand SelectCom = new MySqlCommand("select Max(invoiceNum) from purchase ", myConn);
                MySqlDataReader myReader;

                myConn.Open();
                myReader = SelectCom.ExecuteReader();

                while (myReader.Read())
                {
                    int s = myReader.GetInt32("Max(invoiceNum)");
                    String sIV = s.ToString();


                    label7.Text = sIV;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //calculate balance amount 
        public void cal_balance()
        {
            Decimal balance;

            if (textBox2.Text == "")
            {
                textBox3.Text = textBox1.Text;
            }
            else
            {
                balance = Decimal.Parse(textBox1.Text) - Decimal.Parse(textBox2.Text);

                textBox3.Text = balance.ToString();
            }

           
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cal_balance();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }
        private void ChildForm_Load(object sender, EventArgs e)
        {
            this.Owner.Enabled = false;
        }

        private void ChildForm_Closed(object sender, EventArgs e)
        {
            this.Owner.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox2.Text == "")
            {
                try
                {

                    DialogResult dialog = MessageBox.Show("You have not entered Cash Paid. Do you want to continue?", "Payment", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                        MySqlCommand SelectCom = new MySqlCommand("insert into purchase_invoice  (invoiceNum,date,time,details,totalBill,cashPaid,balance) values ('" + label7.Text + "','" + dateTimePicker1.Text + "','" + DateTime.Now.ToLongTimeString() + "','" + richTextBox1.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox1.Text + "') ", myConn);
                        MySqlDataReader myReader;

                        myConn.Open();
                        myReader = SelectCom.ExecuteReader();

                        this.Close();
                        foreach (Form s in Application.OpenForms)
                        {
                            if (s.Text == "Purchases From Suppliers")
                            {

                                s.Close();
                                break;
                            }
                        }


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
            else if(textBox3.Text == "")
            {
                MessageBox.Show("You have not calculated the balance");
            }
            else
            {
                try
                {

                    cal_balance();
                        MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                        MySqlCommand SelectCom = new MySqlCommand("insert into purchase_invoice  (invoiceNum,date,time,details,totalBill,cashPaid,balance) values ('" + label7.Text + "','" + dateTimePicker1.Text + "','" + DateTime.Now.ToLongTimeString() + "','" + richTextBox1.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "') ", myConn);
                        MySqlDataReader myReader;

                        myConn.Open();
                        myReader = SelectCom.ExecuteReader();

                        MessageBox.Show("Payment has been completed");

                        this.Close();
                    foreach (Form s in Application.OpenForms)
                    {
                        if (s.Text == "Purchases From Suppliers")
                        {
                            
                            s.Close();
                            break;
                        }
                    }





                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult dialog = MessageBox.Show("Do you want to exit without payment process", "Payment", MessageBoxButtons.YesNo);
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

        private void button4_Click(object sender, EventArgs e)
        {
            
        }
    }


   
}
