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


    public partial class summary : Form
    {
        DataTable dbDataSet;
        //public String salesRevenue;

        public summary()
        {
            InitializeComponent();
            FillCombo();

            //Query set
            //salesRevenue = "select  date as 'Date(mm-dd-yyyy)',details as 'Details',totalBill as 'Bill' from sales_invoice where date between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'";

        }
        

        void FillCombo()
        {
            comboBox1.Items.Add("Sales Revenue");
            comboBox1.Items.Add("Cash Received from Sales");
            comboBox1.Items.Add("Discounts Given in Sales");
            comboBox1.Items.Add("Receivables from Sales");
            comboBox1.Items.Add("Purchase Cost");
            comboBox1.Items.Add("Cash paid to Suppliers");
            comboBox1.Items.Add("Discounts received from Suppliers");
            comboBox1.Items.Add("Payables to Suppliers");
            comboBox1.Items.Add("Expenses");
        }

        //load table
        public void LoadTable(string Query)
        {

            try
            {
                MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                MySqlCommand SelectCom = new MySqlCommand(Query, myConn);

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

        //load total
        public void LoadTotal(string Query, string total)
        {

            try
            {
                MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                MySqlCommand SelectCom = new MySqlCommand(Query, myConn);
                MySqlDataReader myReader;

                myConn.Open();
                myReader = SelectCom.ExecuteReader();

                while (myReader.Read())
                {
                    Decimal s = myReader.GetDecimal(total);
                    String sum = s.ToString();


                    textBox8.Text = sum;

                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show("You have nothing in your list");
                textBox8.Text = "0.00";

            }
        }

        //Revenue textbox
        public void LoadRevenue(string Query, string total)
        {

            try
            {
                MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                MySqlCommand SelectCom = new MySqlCommand(Query, myConn);
                MySqlDataReader myReader;

                myConn.Open();
                myReader = SelectCom.ExecuteReader();

                while (myReader.Read())
                {
                    Decimal s = myReader.GetDecimal(total);
                    String sum = s.ToString();


                    textBox1.Text = sum;
                    textBox24.Text = sum;


                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show("You have nothing in your list");
                textBox1.Text = "0.00";
                textBox24.Text = "0.00";


            }
        }

        //Cost of sales textbox
        public void LoadCostOfSales(string Query, string total)
        {

            try
            {
                MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                MySqlCommand SelectCom = new MySqlCommand(Query, myConn);
                MySqlDataReader myReader;

                myConn.Open();
                myReader = SelectCom.ExecuteReader();

                while (myReader.Read())
                {
                    Decimal s = myReader.GetDecimal(total);
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

        //Gross profit calculation
        public void LoadGrossProfit()
        {

            try
            {
                Decimal GrossProfit = Convert.ToDecimal(textBox1.Text) - Convert.ToDecimal(textBox2.Text);
                textBox3.Text = GrossProfit.ToString();

            }
            catch (Exception ex)
            {
                //MessageBox.Show("You have nothing in your list");
                textBox3.Text = "0.00";

            }
        }

        //Discount Received textbox
        public void LoadDiscountsReceived(string Query, string total)
        {

            try
            {
                MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                MySqlCommand SelectCom = new MySqlCommand(Query, myConn);
                MySqlDataReader myReader;

                myConn.Open();
                myReader = SelectCom.ExecuteReader();

                while (myReader.Read())
                {
                    Decimal s = myReader.GetDecimal(total);
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

        //Discount given textbox
        public void LoadDiscountsGiven(string Query, string total)
        {

            try
            {
                MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                MySqlCommand SelectCom = new MySqlCommand(Query, myConn);
                MySqlDataReader myReader;

                myConn.Open();
                myReader = SelectCom.ExecuteReader();

                while (myReader.Read())
                {
                    Decimal s = myReader.GetDecimal(total);
                    String sum = s.ToString();


                    textBox5.Text = sum;
                    textBox20.Text = sum;

                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show("You have nothing in your list");
                textBox5.Text = "0.00";
                textBox20.Text = "0.00";

            }
        }

        //Profit after discounts textbox
        public void LoadProfitAfterDiscounts()
        {

            try
            {
                //Decimal OtherExpenses = Convert.ToDecimal(textBox4.Text) - Convert.ToDecimal(textBox5.Text) - Convert.ToDecimal(textBox6.Text);
                Decimal ProfitAfterDiscounts = Convert.ToDecimal(textBox3.Text) + Convert.ToDecimal(textBox4.Text) - Convert.ToDecimal(textBox5.Text);
                textBox9.Text = ProfitAfterDiscounts.ToString();

            }
            catch (Exception ex)
            {
                //MessageBox.Show("You have nothing in your list");
                textBox9.Text = "0.00";

            }
        }

        //Expenses textbox
        public void LoadExpenses(string Query, string total)
        {

            try
            {
                MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                MySqlCommand SelectCom = new MySqlCommand(Query, myConn);
                MySqlDataReader myReader;

                myConn.Open();
                myReader = SelectCom.ExecuteReader();

                while (myReader.Read())
                {
                    Decimal s = myReader.GetDecimal(total);
                    String sum = s.ToString();


                    textBox6.Text = sum;
                    textBox10.Text = sum;

                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show("You have nothing in your list");
                textBox6.Text = "0.00";
                textBox10.Text = "0.00";

            }
        }

        //Net Profit textbox
        public void LoadNetProfit()
        {

            try
            {
                //Decimal OtherExpenses = Convert.ToDecimal(textBox4.Text) - Convert.ToDecimal(textBox5.Text) - Convert.ToDecimal(textBox6.Text);
                Decimal NetProfit = Convert.ToDecimal(textBox3.Text) + Convert.ToDecimal(textBox4.Text) - Convert.ToDecimal(textBox5.Text) - Convert.ToDecimal(textBox6.Text);
                textBox7.Text = NetProfit.ToString();

            }
            catch (Exception ex)
            {
                //MessageBox.Show("You have nothing in your list");
                textBox7.Text = "0.00";

            }
        }

        //Total Cash Received textbox
        public void LoadCashReceived(string Query, string total)
        {

            try
            {
                MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                MySqlCommand SelectCom = new MySqlCommand(Query, myConn);
                MySqlDataReader myReader;

                myConn.Open();
                myReader = SelectCom.ExecuteReader();

                while (myReader.Read())
                {
                    Decimal s = myReader.GetDecimal(total);
                    String sum = s.ToString();


                    textBox15.Text = sum;

                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show("You have nothing in your list");
                textBox15.Text = "0.00";

            }
        }

        //Total Cash Paid textbox
        public void LoadCashPaid(string Query, string total)
        {

            try
            {
                MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                MySqlCommand SelectCom = new MySqlCommand(Query, myConn);
                MySqlDataReader myReader;

                myConn.Open();
                myReader = SelectCom.ExecuteReader();

                while (myReader.Read())
                {
                    Decimal s = myReader.GetDecimal(total);
                    String sum = s.ToString();


                    textBox14.Text = sum;

                }
                
                
            }
            catch (Exception ex)
            {
                //MessageBox.Show("You have nothing in your list");
                textBox14.Text = "0.00";

            }
        }

        //Cash in hand textbox
        public void LoadCashInHand()
        {

            try
            {
                //Decimal OtherExpenses = Convert.ToDecimal(textBox4.Text) - Convert.ToDecimal(textBox5.Text) - Convert.ToDecimal(textBox6.Text);
                Decimal CashInHand = Convert.ToDecimal(textBox15.Text) - Convert.ToDecimal(textBox14.Text) - Convert.ToDecimal(textBox10.Text) ;
                textBox13.Text = CashInHand.ToString();

            }
            catch (Exception ex)
            {
                //MessageBox.Show("You have nothing in your list");
                textBox13.Text = "0.00";

            }
        }

        //Total Receivables textbox
        public void LoadReceivables(string Query, string total)
        {

            try
            {
                MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                MySqlCommand SelectCom = new MySqlCommand(Query, myConn);
                MySqlDataReader myReader;

                myConn.Open();
                myReader = SelectCom.ExecuteReader();

                while (myReader.Read())
                {
                    Decimal s = myReader.GetDecimal(total);
                    String sum = s.ToString();


                    textBox17.Text = sum;

                }


            }
            catch (Exception ex)
            {
                //MessageBox.Show("You have nothing in your list");
                textBox17.Text = "0.00";

            }
        }

        //Total Payables textbox
        public void LoadPayables(string Query, string total)
        {

            try
            {
                MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                MySqlCommand SelectCom = new MySqlCommand(Query, myConn);
                MySqlDataReader myReader;

                myConn.Open();
                myReader = SelectCom.ExecuteReader();

                while (myReader.Read())
                {
                    Decimal s = myReader.GetDecimal(total);
                    String sum = s.ToString();


                    textBox16.Text = sum;

                }


            }
            catch (Exception ex)
            {
                //MessageBox.Show("You have nothing in your list");
                textBox16.Text = "0.00";

            }
        }

        //Diiference textbox
        public void LoadDifference()
        {

            try
            {
                //Decimal OtherExpenses = Convert.ToDecimal(textBox4.Text) - Convert.ToDecimal(textBox5.Text) - Convert.ToDecimal(textBox6.Text);
                Decimal Difference = Convert.ToDecimal(textBox17.Text) - Convert.ToDecimal(textBox16.Text);
                textBox12.Text = Difference.ToString();

            }
            catch (Exception ex)
            {
                //MessageBox.Show("You have nothing in your list");
                textBox12.Text = "0.00";

            }
        }

        //Cost of sales based on sales  textbox
        public void LoadCostOfSalesBasedOnSales(string Query, string total)
        {

            try
            {
                MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                MySqlCommand SelectCom = new MySqlCommand(Query, myConn);
                MySqlDataReader myReader;

                myConn.Open();
                myReader = SelectCom.ExecuteReader();

                while (myReader.Read())
                {
                    Decimal s = myReader.GetDecimal(total);
                    String sum = s.ToString();


                    textBox23.Text = sum;

                }


            }
            catch (Exception ex)
            {
                //MessageBox.Show("You have nothing in your list");
                textBox23.Text = "0.00";

            }
        }

        //Gross profit based onn sales textbox
        public void LoadGrossProfitBasedOnSales()
        {

            try
            {
                Decimal gpbos = Convert.ToDecimal(textBox24.Text) - Convert.ToDecimal(textBox23.Text) - Convert.ToDecimal(textBox20.Text);
                textBox22.Text = gpbos.ToString();

            }
            catch (Exception ex)
            {
                //MessageBox.Show("You have nothing in your list");
                textBox22.Text = "0.00";

            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //sales revenue query set
            string salesRevenue = "select  date as 'Date(mm-dd-yyyy)',details as 'Details',totalBill as 'Bill' from sales_invoice where date between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'";
            string salesRevenueTotal = "select Sum(totalBill) from sales_invoice where date between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "' ";
            string sumTotalBill = "Sum(totalBill)";

            //cash received from sales query set
            string cashReceivedFromSales = "select  date as 'Date(mm-dd-yyyy)',cashPaid as 'Cash Paid' from cash_received_from_sales where date between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'";
            string cashReceivedFromSalesTotal = "select Sum(cashPaid) from cash_received_from_sales where date between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "' ";
            string sumCashReceivedFromSales = "Sum(cashPaid)";

            //Discounts given in sales query set
            string discountsGivenInSales = "select  date as 'Date(mm-dd-yyyy)',discount as 'Discount' from sales_invoice where date between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'";
            string discountsGivenInSalesTotal = "select Sum(discount) from sales_invoice where date between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "' ";
            string sumDiscountsGivenInSales = "Sum(discount)";

            //Receivables from sales query set
            string receivablesFromSales = "select  date as 'Date(mm-dd-yyyy)',balance as 'Balance' from sales_invoice where date between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'";
            string receivablesFromSalesTotal = "select Sum(balance) from sales_invoice where date between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "' ";
            string sumReceivablesFromSales = "Sum(balance)";

            //Purchase Cost query set
            string purchaseCost = "select  date as 'Date(mm-dd-yyyy)',details as 'Details',totalBill as 'Bill' from purchase_invoice where date between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'";
            string purchaseCostTotal = "select Sum(totalBill) from purchase_invoice where date between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "' ";
            string sumPurchaseCost = "Sum(totalBill)";

            //cash paid to suppliers query set
            string cashPaidToSuppliers = "select  date as 'Date(mm-dd-yyyy)',cashPaid as 'Cash Paid' from cash_paid_to_suppliers where date between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'";
            string cashPaidToSuppliersTotal = "select Sum(cashPaid) from cash_paid_to_suppliers where date between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "' ";
            string sumCashPaidToSuppliers = "Sum(cashPaid)";

            //Discounts received from suppliers query set
            string discountsReceivedFromSuppliers = "select  date as 'Date(mm-dd-yyyy)',discount as 'Discount' from purchase_invoice where date between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'";
            string discountsReceivedFromSuppliersTotal = "select Sum(discount) from purchase_invoice where date between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "' ";
            string sumDiscountsReceivedFromSuppliers = "Sum(discount)";

            //Payables to Suppliers query set
            string payablesToSuppliers = "select  date as 'Date(mm-dd-yyyy)',balance as 'Balance' from purchase_invoice where date between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'";
            string payablesToSuppliersTotal = "select Sum(balance) from purchase_invoice where date between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "' ";
            string sumPayablesToSuppliers = "Sum(balance)";

            //Expenses query set
            string expenses = "select  date as 'Date(mm-dd-yyyy)',details as 'Details',cost as 'Cost' from expenses where date between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'";
            string expensesTotal = "select Sum(cost) from expenses where date between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "' ";
            string sumExpenses = "Sum(cost)";

            if (comboBox1.Text == "Sales Revenue")
            {
                LoadTable(salesRevenue);
                LoadTotal(salesRevenueTotal, sumTotalBill);
            }
            else if (comboBox1.Text == "Cash Received from Sales")
            {
                LoadTable(cashReceivedFromSales);
                LoadTotal(cashReceivedFromSalesTotal, sumCashReceivedFromSales);
            }
            else if (comboBox1.Text == "Discounts Given in Sales")
            {
                LoadTable(discountsGivenInSales);
                LoadTotal(discountsGivenInSalesTotal, sumDiscountsGivenInSales);
            }
            else if (comboBox1.Text == "Receivables from Sales")
            {
                LoadTable(receivablesFromSales);
                LoadTotal(receivablesFromSalesTotal, sumReceivablesFromSales);
            }
            else if (comboBox1.Text == "Purchase Cost")
            {
                LoadTable(purchaseCost);
                LoadTotal(purchaseCostTotal, sumPurchaseCost);
            }
            else if (comboBox1.Text == "Cash paid to Suppliers")
            {
                LoadTable(cashPaidToSuppliers);
                LoadTotal(cashPaidToSuppliersTotal, sumCashPaidToSuppliers);
            }
            else if (comboBox1.Text == "Discounts received from Suppliers")
            {
                LoadTable(discountsReceivedFromSuppliers);
                LoadTotal(discountsReceivedFromSuppliersTotal, sumDiscountsReceivedFromSuppliers);
            }
            else if (comboBox1.Text == "Payables to Suppliers")
            {
                LoadTable(payablesToSuppliers);
                LoadTotal(payablesToSuppliersTotal, sumPayablesToSuppliers);
            }
            else if (comboBox1.Text == "Expenses")
            {
                LoadTable(expenses);
                LoadTotal(expensesTotal, sumExpenses);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //sales revenue query set
            string salesRevenue = "select  date as 'Date(mm-dd-yyyy)',details as 'Details',totalBill as 'Bill' from sales_invoice where date between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'";
            string salesRevenueTotal = "select Sum(totalBill) from sales_invoice where date between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "' ";
            string sumTotalBill = "Sum(totalBill)";

            //cash received from sales query set
            string cashReceivedFromSales = "select  date as 'Date(mm-dd-yyyy)',cashPaid as 'Cash Paid' from cash_received_from_sales where date between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'";
            string cashReceivedFromSalesTotal = "select Sum(cashPaid) from cash_received_from_sales where date between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "' ";
            string sumCashReceivedFromSales = "Sum(cashPaid)";

            //Discounts given in sales query set
            string discountsGivenInSales = "select  date as 'Date(mm-dd-yyyy)',discount as 'Discount' from sales_invoice where date between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'";
            string discountsGivenInSalesTotal = "select Sum(discount) from sales_invoice where date between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "' ";
            string sumDiscountsGivenInSales = "Sum(discount)";

            //Receivables from sales query set
            string receivablesFromSales = "select  date as 'Date(mm-dd-yyyy)',balance as 'Balance' from sales_invoice where date between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'";
            string receivablesFromSalesTotal = "select Sum(balance) from sales_invoice where date between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "' ";
            string sumReceivablesFromSales = "Sum(balance)";

            //Purchase Cost query set
            string purchaseCost = "select  date as 'Date(mm-dd-yyyy)',details as 'Details',totalBill as 'Bill' from purchase_invoice where date between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'";
            string purchaseCostTotal = "select Sum(totalBill) from purchase_invoice where date between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "' ";
            string sumPurchaseCost = "Sum(totalBill)";

            //cash paid to suppliers query set
            string cashPaidToSuppliers = "select  date as 'Date(mm-dd-yyyy)',cashPaid as 'Cash Paid' from cash_paid_to_suppliers where date between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'";
            string cashPaidToSuppliersTotal = "select Sum(cashPaid) from cash_paid_to_suppliers where date between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "' ";
            string sumCashPaidToSuppliers = "Sum(cashPaid)";

            //Discounts received from suppliers query set
            string discountsReceivedFromSuppliers = "select  date as 'Date(mm-dd-yyyy)',discount as 'Discount' from purchase_invoice where date between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'";
            string discountsReceivedFromSuppliersTotal = "select Sum(discount) from purchase_invoice where date between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "' ";
            string sumDiscountsReceivedFromSuppliers = "Sum(discount)";

            //Payables to Suppliers query set
            string payablesToSuppliers = "select  date as 'Date(mm-dd-yyyy)',balance as 'Balance' from purchase_invoice where date between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'";
            string payablesToSuppliersTotal = "select Sum(balance) from purchase_invoice where date between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "' ";
            string sumPayablesToSuppliers = "Sum(balance)";

            //Expenses query set
            string expenses = "select  date as 'Date(mm-dd-yyyy)',details as 'Details',cost as 'Cost' from expenses where date between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'";
            string expensesTotal = "select Sum(cost) from expenses where date between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "' ";
            string sumExpenses = "Sum(cost)";




            //cost of sales based on sales query list
            string cosbosTotal = "select Sum(s.amount*pr.purchasePrice) from sales s, product pr where s.date between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "' && s.productID = pr.productID";
            string sumCosbos = "Sum(s.amount*pr.purchasePrice)";

            //Discounts received based on sales
            string drbosTotal = "select Sum(s.amount*pr.purchasePrice) from sales s, product pr where s.date between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "' && s.productID = pr.productID";
            string sumDrbos = "Sum(s.amount*pr.purchasePrice)";

            if (comboBox1.Text == "Sales Revenue")
            {
                LoadTable(salesRevenue);
                LoadTotal(salesRevenueTotal, sumTotalBill);
            }
            else if (comboBox1.Text == "Cash Received from Sales")
            {
                LoadTable(cashReceivedFromSales);
                LoadTotal(cashReceivedFromSalesTotal, sumCashReceivedFromSales);
            }
            else if (comboBox1.Text == "Discounts Given in Sales")
            {
                LoadTable(discountsGivenInSales);
                LoadTotal(discountsGivenInSalesTotal, sumDiscountsGivenInSales);
            }
            else if (comboBox1.Text == "Receivables from Sales")
            {
                LoadTable(receivablesFromSales);
                LoadTotal(receivablesFromSalesTotal, sumReceivablesFromSales);
            }
            else if (comboBox1.Text == "Purchase Cost")
            {
                LoadTable(purchaseCost);
                LoadTotal(purchaseCostTotal, sumPurchaseCost);
            }
            else if (comboBox1.Text == "Cash paid to Suppliers")
            {
                LoadTable(cashPaidToSuppliers);
                LoadTotal(cashPaidToSuppliersTotal, sumCashPaidToSuppliers);
            }
            else if (comboBox1.Text == "Discounts received from Suppliers")
            {
                LoadTable(discountsReceivedFromSuppliers);
                LoadTotal(discountsReceivedFromSuppliersTotal, sumDiscountsReceivedFromSuppliers);
            }
            else if (comboBox1.Text == "Payables to Suppliers")
            {
                LoadTable(payablesToSuppliers);
                LoadTotal(payablesToSuppliersTotal, sumPayablesToSuppliers);
            }
            else if (comboBox1.Text == "Expenses")
            {
                LoadTable(expenses);
                LoadTotal(expensesTotal, sumExpenses);
            }

            LoadRevenue(salesRevenueTotal, sumTotalBill);
            LoadCostOfSales(purchaseCostTotal, sumPurchaseCost);
            LoadGrossProfit();
            LoadDiscountsReceived(discountsReceivedFromSuppliersTotal, sumDiscountsReceivedFromSuppliers);
            LoadDiscountsGiven(discountsGivenInSalesTotal, sumDiscountsGivenInSales);
            LoadProfitAfterDiscounts();
            LoadExpenses(expensesTotal, sumExpenses);
            LoadNetProfit();
            LoadCashReceived(cashReceivedFromSalesTotal, sumCashReceivedFromSales);
            LoadCashPaid(cashPaidToSuppliersTotal, sumCashPaidToSuppliers);
            LoadCashInHand();
            LoadReceivables(receivablesFromSalesTotal, sumReceivablesFromSales);
            LoadPayables(payablesToSuppliersTotal, sumPayablesToSuppliers);
            LoadDifference();
            LoadCostOfSalesBasedOnSales(cosbosTotal, sumCosbos);
            LoadGrossProfitBasedOnSales();
        }

        
    }
}
