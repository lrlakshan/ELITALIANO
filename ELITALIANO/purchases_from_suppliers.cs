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
    public partial class purchases_from_suppliers : Form
    {
        DataTable dbDataSet;
        final_invoice f;

        public purchases_from_suppliers()
        {
            InitializeComponent();
            LoadTable();
            FillCombo();
            LoadInvoiceNumber();
            button4.Enabled = false;    
        }
        //load table at the begining
        public void LoadTable()
        {
            try
            {
                MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                MySqlCommand SelectCom = new MySqlCommand("select pu.transactionNum as 'Transaction',pr.productID as 'Product ID',pr.productName as 'Product Name',pr.purchasePrice as 'Purchase Price',pu.amountPurchases as 'Purchased Amount',pu.amountPurchases*pr.purchasePrice as 'Value' from purchase pu inner join product pr ON pu.productID = pr.productID where pu.invoiceNum = (SELECT MAX(invoiceNum)+1 from purchase) order by transactionNum ASC", myConn);

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
                MySqlCommand SelectCom = new MySqlCommand("select pu.transactionNum as 'Transaction',pr.productID as 'Product ID',pr.productName as 'Product Name',pr.purchasePrice as 'Purchase Price',pu.amountPurchases as 'Purchased Amount',pu.amountPurchases*pr.purchasePrice as 'Value' from purchase pu inner join product pr ON pu.productID = pr.productID where pu.invoiceNum = (SELECT MAX(invoiceNum) from purchase) order by transactionNum ASC", myConn);

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
                MySqlCommand SelectCom = new MySqlCommand("select pu.transactionNum as 'Transaction',pr.productID as 'Product ID',pr.productName as 'Product Name',pr.purchasePrice as 'Purchase Price',pu.amountPurchases as 'Purchased Amount',pu.amountPurchases*pr.purchasePrice as 'Value' from purchase pu inner join product pr ON pu.productID = pr.productID where pu.invoiceNum = '" + label7.Text+"' order by transactionNum ASC", myConn);

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
                MySqlCommand SelectCom = new MySqlCommand("select Max(invoiceNum) from purchase ", myConn);
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
                MySqlCommand SelectCom = new MySqlCommand("select Sum(pu.amountPurchases*pr.purchasePrice) from purchase pu, product pr where pu.invoiceNum = '"+label7.Text+"' && pu.productID = pr.productID ", myConn);
                MySqlDataReader myReader;

                myConn.Open();
                myReader = SelectCom.ExecuteReader();

                while (myReader.Read())
                {
                    Decimal s = myReader.GetDecimal("Sum(pu.amountPurchases*pr.purchasePrice)");
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
        //dropdown combo box
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                MySqlCommand SelectCom = new MySqlCommand("select productID,amountAvailable,purchasePrice from product where productName = '" + comboBox1.Text + "'; ", myConn);
                MySqlDataReader myReader;

                myConn.Open();
                myReader = SelectCom.ExecuteReader();

                while (myReader.Read())
                {
                    String sPID = myReader.GetInt32("productID").ToString();
                    String sAA = myReader.GetInt32("amountAvailable").ToString();
                    String sPP = myReader.GetDecimal("purchasePrice").ToString();

                    textBox1.Text = sPID;
                    textBox2.Text = sAA;
                    textBox5.Text = sPP;
                }
                if(comboBox1.Text == "None")
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
                else if(Convert.ToInt32(textBox3.Text) < 1)
                {
                    MessageBox.Show("You have entered invalid number to amount purchased");
                }
                else
                {
                    MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                    MySqlCommand SelectCom = new MySqlCommand("insert into purchase  (invoiceNum,date,productID,amountPurchases,time) values ('" + label7.Text + "','" + dateTimePicker1.Text + "','" + textBox1.Text + "','" + textBox3.Text + "','" + DateTime.Now.ToLongTimeString() + "') ", myConn);
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
        //select item form the grid view
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                comboBox1.Text = row.Cells["Product Name"].Value.ToString();
                label8.Text = row.Cells["Transaction"].Value.ToString();
                textBox1.Text = row.Cells["Product ID"].Value.ToString();
                textBox5.Text = row.Cells["Purchase Price"].Value.ToString();
                textBox2.Text = "";
                textBox3.Text = row.Cells["Purchased Amount"].Value.ToString();
            }
        }
        //delete button
        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                if (comboBox1.Text == ""|| textBox1.Text == "" || textBox5.Text == "" || textBox3.Text == "" || textBox2.Text != "")
                {
                    MessageBox.Show("You have not selected the transaction you want to remove");
                }
                else
                {
                    DialogResult dialog = MessageBox.Show("Do you really want to delete this transaction?", "Delete", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                        MySqlCommand SelectCom = new MySqlCommand("delete from purchase where transactionNum = '" + label8.Text + "'", myConn);
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
            
            
        
        //Update which has already inserted
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
                        MySqlCommand SelectCom = new MySqlCommand("update purchase set transactionNum = '" + this.label8.Text + "',invoiceNum = '" + this.label7.Text + "',date = '" + this.dateTimePicker1.Text + "',productID = '" + this.textBox1.Text + "',amountPurchases = '" + this.textBox3.Text + "',time = '" + DateTime.Now.ToLongTimeString() + "' where transactionNum = '" + this.label8.Text + "';", myConn);
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
            if(!Char.IsDigit(ch) && ch !=8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;


            foreach (Form s in Application.OpenForms)
            {
                if (s.Text == "Final Invoice")
                {
                    IsOpen = true;
                    s.BringToFront();
                    break;
                }
            }

            if (IsOpen == false)
            {
                final_invoice fi = new final_invoice();
                fi.Owner = this;
                fi.Show();
             
            }
        }

        //disable the button until atleast one item is added
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            button4.Enabled = !string.IsNullOrEmpty(textBox4.Text);
        }

        //close the form
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult dialog = MessageBox.Show("Do you really want to exit without proceeding?", "Exit", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                    MySqlCommand SelectCom = new MySqlCommand("delete from purchase where invoiceNum = '" + label7.Text + "'", myConn);
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
