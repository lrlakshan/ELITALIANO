using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;


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
            button1.Enabled = false;
            
        }

        
        public void LoadTable_after_proceed()
        {
            try
            {
                MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                MySqlCommand SelectCom = new MySqlCommand("select pr.productName as 'Product Name',pr.purchasePrice as 'Unit Price',pu.amountPurchases as 'Qty',pu.amountPurchases*pr.purchasePrice as 'Value' from purchase pu inner join product pr ON pu.productID = pr.productID where pu.invoiceNum = (SELECT MAX(invoiceNum) from purchase) order by transactionNum ASC", myConn);

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
            //no cash paid no discount entered
            if (textBox2.Text == "" && textBox4.Text =="")
            {
                textBox3.Text = textBox1.Text;
                label9.Text = "0.00";
                label10.Text = "0.00";
            }
            //only cash paid entered
            else if (textBox2.Text != "" && textBox4.Text == "")
            {
                balance = Decimal.Parse(textBox1.Text) - Decimal.Parse(textBox2.Text);
                Decimal tempCash = Decimal.Parse(textBox1.Text) - Decimal.Parse(textBox1.Text) + Decimal.Parse(textBox2.Text) ;
                textBox3.Text = balance.ToString();
                label9.Text = "0.00";
                label10.Text = tempCash.ToString();
            }
            //both cash paid and discount entered
            else if (textBox2.Text != "" && textBox4.Text != "")
            {
                balance = Decimal.Parse(textBox1.Text) - Decimal.Parse(textBox2.Text) - Decimal.Parse(textBox4.Text);
                Decimal tempCash = Decimal.Parse(textBox1.Text) - Decimal.Parse(textBox1.Text) + Decimal.Parse(textBox2.Text);
                Decimal tempDiscount = Decimal.Parse(textBox1.Text) - Decimal.Parse(textBox1.Text) + Decimal.Parse(textBox4.Text);
                textBox3.Text = balance.ToString();
                label9.Text = tempDiscount.ToString();
                label10.Text = tempCash.ToString();
            }
            //only discount entered
            else if (textBox2.Text == "" && textBox4.Text != "")
            {
                balance = Decimal.Parse(textBox1.Text) - Decimal.Parse(textBox4.Text);
                Decimal tempDiscount = Decimal.Parse(textBox1.Text) - Decimal.Parse(textBox1.Text) + Decimal.Parse(textBox4.Text);
                textBox3.Text = balance.ToString();
                label9.Text = tempDiscount.ToString();
                label10.Text = "0.00";
            }



        }

        

       
        //calculate button
        private void button3_Click(object sender, EventArgs e)
        {
            cal_balance();
            textBox2.Text = "";
            textBox4.Text = "";

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46 )
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

        //payment button
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("You have not calculated the balance");
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }
            
            else
            {
                try
                {
                    DialogResult dialog = MessageBox.Show("Confirm the Payment?", "Payment Confirm", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        
                        MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                        MySqlCommand SelectCom = new MySqlCommand("insert into purchase_invoice  (invoiceNum,date,time,details,totalBill,discount,cashPaid,balance) values ('" + label7.Text + "','" + dateTimePicker1.Text + "','" + DateTime.Now.ToLongTimeString() + "','" + richTextBox1.Text + "','" + textBox1.Text + "','" + label9.Text + "','" + label10.Text + "','" + textBox3.Text + "') ", myConn);
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
                    else if (dialog == DialogResult.No)
                    {
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
        }
        //close the final invoice form
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

        DataTable MakeDataTable()
        {

            try
            {
                MySqlConnection myConn = new MySqlConnection(Connection.myConnection);
                MySqlCommand SelectCom = new MySqlCommand("select pr.productName as 'Product Name',pr.purchasePrice as 'Unit Price',pu.amountPurchases as 'Qty',pu.amountPurchases*pr.purchasePrice as 'Value' from purchase pu inner join product pr ON pu.productID = pr.productID where pu.invoiceNum = (SELECT MAX(invoiceNum) from purchase) order by transactionNum ASC", myConn);

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

            return dbDataSet;
        }

        
        void ExportDataTableToPdf(DataTable dtblTable, String strPdfPath, string strHeader)
        {

            System.IO.FileStream fs = new FileStream(strPdfPath, FileMode.Create, FileAccess.Write, FileShare.None);
            Document document = new Document();
            document.SetPageSize(iTextSharp.text.PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();

            //Report Header
            BaseFont bfntHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntHead = new Font(bfntHead, 26, 1, Color.GRAY);
            Paragraph prgHeading = new Paragraph();
            prgHeading.Alignment = Element.ALIGN_RIGHT;
            prgHeading.Add(new Chunk(strHeader.ToUpper(), fntHead));
            document.Add(prgHeading);

            //EL ITALIANO
            Paragraph name = new Paragraph();
            name.Alignment = Element.ALIGN_LEFT;
            name.Add(new Chunk("EL ITALIANO", fntHead));
            document.Add(name);

            //Address
            BaseFont btnAuthor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntAuthor = new Font(btnAuthor, 8, 2, Color.GRAY);
            Paragraph address = new Paragraph();
            address.Alignment = Element.ALIGN_LEFT;
            address.Add(new Chunk("Liyanage Distributors", fntAuthor));
            address.Add(new Chunk("\n1394/7, Hokandara road,Pannipitiya", fntAuthor));
            address.Add(new Chunk("\nJanith  : +94 71 329 9627", fntAuthor));
            address.Add(new Chunk("\nLakshan : +94 71 303 2396", fntAuthor));
            address.Add(new Chunk("\nEmail   : elitaliano.lanka@gmail.com", fntAuthor));
            document.Add(address);

            //Author
            Paragraph prgAuthor = new Paragraph();
            prgAuthor.Alignment = Element.ALIGN_RIGHT;
            prgAuthor.Add(new Chunk("Invoice Number : "+label7.Text, fntAuthor));
            prgAuthor.Add(new Chunk("\nDate : " + dateTimePicker1.Text, fntAuthor));
            document.Add(prgAuthor);

            //Add a line seperation
            Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, Color.BLACK, Element.ALIGN_LEFT, 1)));
            document.Add(p);

            //Add line break
            document.Add(new Chunk("\n", fntHead));

            //Write the table
            PdfPTable table = new PdfPTable(dtblTable.Columns.Count);

            table.TotalWidth = 500f;
            table.LockedWidth = true;
            float[] widths = new float[] { 200f, 50f, 50f, 100f };
            table.SetWidths(widths);

            //Table header
            BaseFont btnColumnHeader = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntColumnHeader = new Font(btnColumnHeader, 10, 1, Color.WHITE);
            Font fntData = new Font(btnColumnHeader, 9, 1, Color.DARK_GRAY);
            for (int i = 0; i < dtblTable.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell();
                cell.BackgroundColor = Color.GRAY;
                cell.Border = PdfCell.NO_BORDER;
                Paragraph aligmentTemp = new Paragraph();
                aligmentTemp.Alignment = Element.ALIGN_RIGHT;
                aligmentTemp.Add(new Chunk(dtblTable.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                if(i == 0)
                {
                    aligmentTemp.Alignment = Element.ALIGN_LEFT;
                }
                else
                {
                    aligmentTemp.Alignment = Element.ALIGN_RIGHT;
                }
                cell.AddElement(aligmentTemp);
                table.AddCell(cell);

            }
            //table Data
            for (int i = 0; i < dtblTable.Rows.Count; i++)
            {
                for (int j = 0; j < dtblTable.Columns.Count; j++)
                {
                    //PdfPCell data = new PdfPCell();
                    //data.Border = PdfCell.NO_BORDER;
                    //data.AddElement(new Chunk(dtblTable.Rows[i][j].ToString(), fntData));
                    //table.AddCell(data);
                    PdfPCell data = new PdfPCell();
                    data.Border = PdfCell.NO_BORDER;

                    if (j == 0)
                    {
                        data.AddElement(new Chunk(dtblTable.Rows[i][j].ToString(), fntData));
                        table.AddCell(data);
                    }
                    else
                    {
                        Paragraph aligmentTemp = new Paragraph();
                        aligmentTemp.Alignment = Element.ALIGN_RIGHT;
                        aligmentTemp.Add(new Chunk(dtblTable.Rows[i][j].ToString(), fntData));
                        data.AddElement(aligmentTemp);
                        table.AddCell(data);
                    }

                }
            }
            //empty field before subtotal
            for (int i = 0; i < dtblTable.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell();
                //cell.BackgroundColor = Color.GRAY;
                cell.Border = PdfCell.NO_BORDER;
                cell.AddElement(new Chunk("  ", fntData));

                table.AddCell(cell);
            }
           //boarder bottom before subtotal
            for (int i = 0; i < dtblTable.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell();
                //cell.BackgroundColor = Color.GRAY;
                cell.Border = PdfCell.NO_BORDER;
                if (i == 3)
                {
                    //cell.Border = Color.BLACK;
                    cell.Border = PdfCell.BOTTOM_BORDER;
                }

                table.AddCell(cell);
            }
            //subtotal column of the table
            for (int i = 0; i < dtblTable.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell();
                //cell.BackgroundColor = Color.GRAY;
                cell.Border = PdfCell.NO_BORDER;
                if (i == 0)
                {
                    cell.AddElement(new Chunk("SUB TOTAL", fntData));
                }
                else if (i == 3)
                {
                    Paragraph aligmentTemp = new Paragraph();
                    aligmentTemp.Alignment = Element.ALIGN_RIGHT;
                    aligmentTemp.Add(new Chunk(textBox1.Text, fntData));
                    cell.AddElement(aligmentTemp);

                }

                table.AddCell(cell);
            }
            //discount column of table
            for (int i = 0; i < dtblTable.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell();
                //cell.BackgroundColor = Color.GRAY;
                cell.Border = PdfCell.NO_BORDER;
                if (i == 0)
                {
                    cell.AddElement(new Chunk("DISCOUNT", fntData));
                }
                else if (i == 3)
                {


                    Paragraph aligmentTemp = new Paragraph();
                    aligmentTemp.Alignment = Element.ALIGN_RIGHT;
                    aligmentTemp.Add(new Chunk(label9.Text, fntData));
                    cell.AddElement(aligmentTemp);
                    cell.Border = PdfCell.BOTTOM_BORDER | PdfCell.BOTTOM_BORDER;


                }

                table.AddCell(cell);
            }
            // total column of table
            for (int i = 0; i < dtblTable.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell();
                //cell.BackgroundColor = Color.GRAY;
                cell.Border = PdfCell.NO_BORDER;
                if (i == 0)
                {
                    cell.AddElement(new Chunk("TOTAL", fntData));
                }
                else if (i == 3)
                {
                    Decimal tot = Decimal.Parse(textBox1.Text) - Decimal.Parse(label9.Text);
                    Paragraph aligmentTemp = new Paragraph();
                    aligmentTemp.Alignment = Element.ALIGN_RIGHT;
                    aligmentTemp.Add(new Chunk(tot.ToString(), fntData));
                    cell.AddElement(aligmentTemp);
                    cell.Border = PdfCell.BOTTOM_BORDER | PdfCell.BOTTOM_BORDER;

                }

                table.AddCell(cell);
            }


            document.Add(table);

            
            

            document.Close();
            writer.Close();
            fs.Close();
        }

        //create the pdf invoice
        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("You have not calculated the balance");
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                label10.Text = "";
                label9.Text = "";
            }
            else
            {
                SaveFileDialog sv = new SaveFileDialog();
                sv.FileName = label7.Text + ".pdf";
                if (sv.ShowDialog() == DialogResult.OK)
                {

                    try
                    {
                        
                        DataTable dtbl = MakeDataTable();
                        ExportDataTableToPdf(dtbl, sv.FileName, "INVOICE");


                        System.Diagnostics.Process.Start(sv.FileName);
                        //this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
                        button1.Enabled = true;
                        textBox2.Enabled = false;
                        textBox4.Enabled = false;


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error Message");
                    }

                }
            }
         

        }

        
    }


   
}
