namespace ELITALIANO
{
    partial class admin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inventoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewStocksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purchasesFromSupplierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addExpensesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purchasesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expensesHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cashPaidToSuppliersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cashReceivedFromSalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.receivableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageReceivablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.managePayablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inventoryToolStripMenuItem,
            this.expenseToolStripMenuItem,
            this.accountsToolStripMenuItem,
            this.receivableToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // inventoryToolStripMenuItem
            // 
            this.inventoryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewStocksToolStripMenuItem,
            this.purchasesFromSupplierToolStripMenuItem,
            this.addNewItemsToolStripMenuItem});
            this.inventoryToolStripMenuItem.Name = "inventoryToolStripMenuItem";
            this.inventoryToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.inventoryToolStripMenuItem.Text = "Inventory";
            // 
            // viewStocksToolStripMenuItem
            // 
            this.viewStocksToolStripMenuItem.Name = "viewStocksToolStripMenuItem";
            this.viewStocksToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.viewStocksToolStripMenuItem.Text = "View Stocks";
            this.viewStocksToolStripMenuItem.Click += new System.EventHandler(this.viewStocksToolStripMenuItem_Click);
            // 
            // purchasesFromSupplierToolStripMenuItem
            // 
            this.purchasesFromSupplierToolStripMenuItem.Name = "purchasesFromSupplierToolStripMenuItem";
            this.purchasesFromSupplierToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.purchasesFromSupplierToolStripMenuItem.Text = "Purchases From Supplier";
            this.purchasesFromSupplierToolStripMenuItem.Click += new System.EventHandler(this.purchasesFromSupplierToolStripMenuItem_Click);
            // 
            // addNewItemsToolStripMenuItem
            // 
            this.addNewItemsToolStripMenuItem.Name = "addNewItemsToolStripMenuItem";
            this.addNewItemsToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.addNewItemsToolStripMenuItem.Text = "Add/Remove/Change Items";
            this.addNewItemsToolStripMenuItem.Click += new System.EventHandler(this.addNewItemsToolStripMenuItem_Click);
            // 
            // expenseToolStripMenuItem
            // 
            this.expenseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addExpensesToolStripMenuItem});
            this.expenseToolStripMenuItem.Name = "expenseToolStripMenuItem";
            this.expenseToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.expenseToolStripMenuItem.Text = "Expenses";
            // 
            // addExpensesToolStripMenuItem
            // 
            this.addExpensesToolStripMenuItem.Name = "addExpensesToolStripMenuItem";
            this.addExpensesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addExpensesToolStripMenuItem.Text = "Add Expenses";
            this.addExpensesToolStripMenuItem.Click += new System.EventHandler(this.addExpensesToolStripMenuItem_Click);
            // 
            // accountsToolStripMenuItem
            // 
            this.accountsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salesToolStripMenuItem,
            this.purchasesToolStripMenuItem,
            this.expensesHistoryToolStripMenuItem,
            this.cashPaidToSuppliersToolStripMenuItem,
            this.cashReceivedFromSalesToolStripMenuItem});
            this.accountsToolStripMenuItem.Name = "accountsToolStripMenuItem";
            this.accountsToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.accountsToolStripMenuItem.Text = "Accounts";
            // 
            // salesToolStripMenuItem
            // 
            this.salesToolStripMenuItem.Name = "salesToolStripMenuItem";
            this.salesToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.salesToolStripMenuItem.Text = "Sales History";
            // 
            // purchasesToolStripMenuItem
            // 
            this.purchasesToolStripMenuItem.Name = "purchasesToolStripMenuItem";
            this.purchasesToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.purchasesToolStripMenuItem.Text = "Purchases History";
            this.purchasesToolStripMenuItem.Click += new System.EventHandler(this.purchasesToolStripMenuItem_Click);
            // 
            // expensesHistoryToolStripMenuItem
            // 
            this.expensesHistoryToolStripMenuItem.Name = "expensesHistoryToolStripMenuItem";
            this.expensesHistoryToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.expensesHistoryToolStripMenuItem.Text = "Expenses History";
            this.expensesHistoryToolStripMenuItem.Click += new System.EventHandler(this.expensesHistoryToolStripMenuItem_Click);
            // 
            // cashPaidToSuppliersToolStripMenuItem
            // 
            this.cashPaidToSuppliersToolStripMenuItem.Name = "cashPaidToSuppliersToolStripMenuItem";
            this.cashPaidToSuppliersToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.cashPaidToSuppliersToolStripMenuItem.Text = "Cash Paid to Suppliers";
            this.cashPaidToSuppliersToolStripMenuItem.Click += new System.EventHandler(this.cashPaidToSuppliersToolStripMenuItem_Click);
            // 
            // cashReceivedFromSalesToolStripMenuItem
            // 
            this.cashReceivedFromSalesToolStripMenuItem.Name = "cashReceivedFromSalesToolStripMenuItem";
            this.cashReceivedFromSalesToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.cashReceivedFromSalesToolStripMenuItem.Text = "Cash Received from Sales";
            // 
            // receivableToolStripMenuItem
            // 
            this.receivableToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageReceivablesToolStripMenuItem,
            this.managePayablesToolStripMenuItem});
            this.receivableToolStripMenuItem.Name = "receivableToolStripMenuItem";
            this.receivableToolStripMenuItem.Size = new System.Drawing.Size(121, 20);
            this.receivableToolStripMenuItem.Text = "Receivable/Payable";
            // 
            // manageReceivablesToolStripMenuItem
            // 
            this.manageReceivablesToolStripMenuItem.Name = "manageReceivablesToolStripMenuItem";
            this.manageReceivablesToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.manageReceivablesToolStripMenuItem.Text = "Manage Receivables";
            // 
            // managePayablesToolStripMenuItem
            // 
            this.managePayablesToolStripMenuItem.Name = "managePayablesToolStripMenuItem";
            this.managePayablesToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.managePayablesToolStripMenuItem.Text = "Manage Payables";
            this.managePayablesToolStripMenuItem.Click += new System.EventHandler(this.managePayablesToolStripMenuItem_Click);
            // 
            // admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "admin";
            this.Text = "admin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.admin_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem inventoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewStocksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purchasesFromSupplierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewItemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purchasesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expensesHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem receivableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageReceivablesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem managePayablesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cashPaidToSuppliersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addExpensesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cashReceivedFromSalesToolStripMenuItem;
    }
}