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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Login adminLogin = new Admin_Login();
            adminLogin.Show();
        }

        //private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    DialogResult dialog = MessageBox.Show("Do you really want to close ELITALIANO program?", "Close", MessageBoxButtons.YesNo);
        //    if (dialog == DialogResult.Yes)
        //    {

        //        Application.Exit();
        //    }
        //    else if (dialog == DialogResult.No)
        //    {
        //        e.Cancel = true;
        //    }
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            cashier_login cashierLogin = new cashier_login();
            cashierLogin.Show();
        }
    }
}
