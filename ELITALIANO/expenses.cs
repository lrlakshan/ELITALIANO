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
    public partial class expenses : Form
    {
        DataTable dbDataSet;
        //bool isSelected = false;
        public expenses()
        {
            InitializeComponent();
            LoadTable();
        }

        //load table at the begining
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

        

        //delete button
        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (label2.Text == "")
                {
                    MessageBox.Show("You have not selected the transaction you want to remove");
                }
                else
                {
                    DialogResult dialog = MessageBox.Show("Do you really want to delete this transaction?", "Delete", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                        MySqlCommand SelectCom = new MySqlCommand("delete from expenses where transactionNum = '" + label2.Text + "'", myConn);
                        MySqlDataReader myReader;

                        myConn.Open();
                        myReader = SelectCom.ExecuteReader();
                        richTextBox1.Text = "";
                        textBox1.Text = "";
                        label2.Text = "";
                        MessageBox.Show("Deleted");
                        LoadTable();
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
        }

        //change button
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (label2.Text == "")
                {
                    MessageBox.Show("You have not selected the transaction you want to change");
                }
                else
                {
                    DialogResult dialog = MessageBox.Show("Do you really want to change this transaction?", "Change", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                        MySqlCommand SelectCom = new MySqlCommand("update expenses set details = '" + richTextBox1.Text + "',cost = '" + textBox1.Text + "' where transactionNum = '" + label2.Text + "'", myConn);
                        MySqlDataReader myReader;

                        myConn.Open();
                        myReader = SelectCom.ExecuteReader();
                        richTextBox1.Text = "";
                        textBox1.Text = "";
                        label2.Text = "";
                        MessageBox.Show("Changed");
                        LoadTable();
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
        }

        //add button
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (richTextBox1.Text == "" || textBox1.Text == "")
                {
                    MessageBox.Show("You have to fill all the fields");
                }

                else
                {
                    MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                    MySqlCommand SelectCom = new MySqlCommand("insert into expenses (date,time,details,cost) values ('" + dateTimePicker1.Text + "','" + DateTime.Now.ToLongTimeString() + "','" + richTextBox1.Text + "','" + textBox1.Text + "') ", myConn);
                    MySqlDataReader myReader;

                    myConn.Open();
                    myReader = SelectCom.ExecuteReader();
                    richTextBox1.Text = "";
                    textBox1.Text = "";
                    MessageBox.Show("Added");
                    LoadTable();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //close button
        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        //accept only numbers
        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        //grid cell click
        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                richTextBox1.Text = row.Cells["Details"].Value.ToString();
                textBox1.Text = row.Cells["Cost"].Value.ToString();
                label2.Text = row.Cells["Transaction"].Value.ToString();
                //isSelected = true;
            }
        }
    }
}
