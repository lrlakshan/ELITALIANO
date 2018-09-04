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
    public partial class add_new_items : Form
    {
        DataTable dbDataSet;
        bool isSelected = false;
        public add_new_items()
        {
            InitializeComponent();
            LoadTable();
            
        }
        //load table
        public void LoadTable()
        {
            try
            {
                MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                MySqlCommand SelectCommand = new MySqlCommand("select productID as 'Product ID', productName as 'Product Name', purchasePrice as 'Purchase Price', sellingPrice as 'Selling Price' from product", myConn);

                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = SelectCommand;
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
        //add new itmes
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
                {
                    MessageBox.Show("You have to fill all the fields");
                }

                else
                {
                    MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                MySqlCommand SelectCommand = new MySqlCommand("insert into product (productID,productName,purchasePrice,sellingPrice) values ('"+textBox1.Text+ "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')", myConn);

                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = SelectCommand;
                dbDataSet = new DataTable();
                sda.Fill(dbDataSet);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbDataSet;
                dataGridView1.DataSource = bSource;
                sda.Update(dbDataSet);

                myConn.Open();
                LoadTable();

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }
        //remove items
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (isSelected == false)
                {
                    MessageBox.Show("You have not selected the item you want to remove");
                }
                
                else
                {
                    DialogResult dialog = MessageBox.Show("Do you really want to delete this Item?", "Delete", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                        MySqlCommand SelectCom = new MySqlCommand("delete from product where productID = '" + textBox1.Text + "'", myConn);
                        MySqlDataReader myReader;

                        myConn.Open();
                        myReader = SelectCom.ExecuteReader();
                        
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        
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
            LoadTable();
            isSelected = false;
        }

        
        //change items
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (isSelected == false)
                {
                    MessageBox.Show("You have not selected the item you want to change");
                }
                else
                {
                    DialogResult dialog = MessageBox.Show("Do you really want to Change this Item?", "Change", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                        MySqlCommand SelectCom = new MySqlCommand("update product set productID = '" + textBox1.Text + "',productName = '" + textBox2.Text + "',purchasePrice = '" + textBox3.Text + "',sellingPrice = '" + textBox4.Text + "' where productID = '" + textBox1.Text + "'", myConn);
                        MySqlDataReader myReader;

                        myConn.Open();
                        myReader = SelectCom.ExecuteReader();

                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";

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
            LoadTable();
            isSelected = false;
        }

        //select from the grid
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];


                textBox1.Text = row.Cells["Product ID"].Value.ToString();
                textBox2.Text = row.Cells["Product Name"].Value.ToString(); ;
                textBox3.Text = row.Cells["Purchase Price"].Value.ToString();
                textBox4.Text = row.Cells["Selling Price"].Value.ToString();

                isSelected = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}
