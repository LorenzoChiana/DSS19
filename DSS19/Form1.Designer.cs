namespace DSS19
{
    partial class View
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(View));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteDBADOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateDBADOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readDBORMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readOrdiniCustomerORMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnDB = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteDB = new System.Windows.Forms.ToolStripButton();
            this.btnInsertDB = new System.Windows.Forms.ToolStripButton();
            this.btnUpdateDB = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.sqLiteCommandBuilder1 = new System.Data.SQLite.SQLiteCommandBuilder();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(847, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readDBToolStripMenuItem,
            this.deleteDBADOToolStripMenuItem,
            this.insertToolStripMenuItem,
            this.updateDBADOToolStripMenuItem,
            this.readDBORMToolStripMenuItem,
            this.readOrdiniCustomerORMToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // readDBToolStripMenuItem
            // 
            this.readDBToolStripMenuItem.Name = "readDBToolStripMenuItem";
            this.readDBToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.readDBToolStripMenuItem.Text = "Read DB (ADO)";
            this.readDBToolStripMenuItem.Click += new System.EventHandler(this.readDBToolStripMenuItem_Click);
            // 
            // deleteDBADOToolStripMenuItem
            // 
            this.deleteDBADOToolStripMenuItem.Name = "deleteDBADOToolStripMenuItem";
            this.deleteDBADOToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.deleteDBADOToolStripMenuItem.Text = "Delete DB (ADO)";
            this.deleteDBADOToolStripMenuItem.Click += new System.EventHandler(this.deleteDBADOToolStripMenuItem_Click);
            // 
            // insertToolStripMenuItem
            // 
            this.insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            this.insertToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.insertToolStripMenuItem.Text = "Insert DB (ADO)";
            this.insertToolStripMenuItem.Click += new System.EventHandler(this.insertToolStripMenuItem_Click);
            // 
            // updateDBADOToolStripMenuItem
            // 
            this.updateDBADOToolStripMenuItem.Name = "updateDBADOToolStripMenuItem";
            this.updateDBADOToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.updateDBADOToolStripMenuItem.Text = "Update DB (ADO)";
            this.updateDBADOToolStripMenuItem.Click += new System.EventHandler(this.updateDBADOToolStripMenuItem_Click);
            // 
            // readDBORMToolStripMenuItem
            // 
            this.readDBORMToolStripMenuItem.Name = "readDBORMToolStripMenuItem";
            this.readDBORMToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.readDBORMToolStripMenuItem.Text = "Read DB clienti (ORM)";
            this.readDBORMToolStripMenuItem.Click += new System.EventHandler(this.readDBORMToolStripMenuItem_Click);
            // 
            // readOrdiniCustomerORMToolStripMenuItem
            // 
            this.readOrdiniCustomerORMToolStripMenuItem.Name = "readOrdiniCustomerORMToolStripMenuItem";
            this.readOrdiniCustomerORMToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.readOrdiniCustomerORMToolStripMenuItem.Text = "Read DB ordini cliente (ORM)";
            this.readOrdiniCustomerORMToolStripMenuItem.Click += new System.EventHandler(this.readOrdiniCustomerORMToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDB,
            this.btnDeleteDB,
            this.btnInsertDB,
            this.btnUpdateDB});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(847, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnDB
            // 
            this.btnDB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDB.Image = ((System.Drawing.Image)(resources.GetObject("btnDB.Image")));
            this.btnDB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDB.Name = "btnDB";
            this.btnDB.Size = new System.Drawing.Size(23, 22);
            this.btnDB.Text = "toolStripButton1";
            this.btnDB.ToolTipText = "Read DB data";
            this.btnDB.Click += new System.EventHandler(this.btnReadDB_Click);
            // 
            // btnDeleteDB
            // 
            this.btnDeleteDB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDeleteDB.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteDB.Image")));
            this.btnDeleteDB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteDB.Name = "btnDeleteDB";
            this.btnDeleteDB.Size = new System.Drawing.Size(23, 22);
            this.btnDeleteDB.Text = "toolStripButton1";
            this.btnDeleteDB.ToolTipText = "Delete DB data";
            this.btnDeleteDB.Click += new System.EventHandler(this.btnDeleteDB_Click);
            // 
            // btnInsertDB
            // 
            this.btnInsertDB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnInsertDB.Image = ((System.Drawing.Image)(resources.GetObject("btnInsertDB.Image")));
            this.btnInsertDB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInsertDB.Name = "btnInsertDB";
            this.btnInsertDB.Size = new System.Drawing.Size(23, 22);
            this.btnInsertDB.Text = "toolStripButton1";
            this.btnInsertDB.ToolTipText = "Insert DB data";
            this.btnInsertDB.Click += new System.EventHandler(this.btnInsertDB_Click);
            // 
            // btnUpdateDB
            // 
            this.btnUpdateDB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUpdateDB.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateDB.Image")));
            this.btnUpdateDB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpdateDB.Name = "btnUpdateDB";
            this.btnUpdateDB.Size = new System.Drawing.Size(23, 22);
            this.btnUpdateDB.Text = "toolStripButton1";
            this.btnUpdateDB.ToolTipText = "Update DB data";
            this.btnUpdateDB.Click += new System.EventHandler(this.btnUpdateDB_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtCustomer);
            this.splitContainer1.Panel1.Controls.Add(this.lblCustomer);
            this.splitContainer1.Panel1.Controls.Add(this.txtConsole);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Size = new System.Drawing.Size(847, 472);
            this.splitContainer1.SplitterDistance = 281;
            this.splitContainer1.TabIndex = 2;
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(86, 9);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(192, 21);
            this.txtCustomer.TabIndex = 2;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(12, 9);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(57, 15);
            this.lblCustomer.TabIndex = 1;
            this.lblCustomer.Text = "Cutomer:";
            // 
            // txtConsole
            // 
            this.txtConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConsole.Location = new System.Drawing.Point(-2, 36);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtConsole.Size = new System.Drawing.Size(281, 436);
            this.txtConsole.TabIndex = 0;
            this.txtConsole.WordWrap = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(562, 472);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // sqLiteCommandBuilder1
            // 
            this.sqLiteCommandBuilder1.DataAdapter = null;
            this.sqLiteCommandBuilder1.QuoteSuffix = "]";
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 521);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "View";
            this.Text = "View";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readDBToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnDB;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.ToolStripMenuItem deleteDBADOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateDBADOToolStripMenuItem;
        private System.Data.SQLite.SQLiteCommandBuilder sqLiteCommandBuilder1;
        private System.Windows.Forms.ToolStripButton btnDeleteDB;
        private System.Windows.Forms.ToolStripButton btnInsertDB;
        private System.Windows.Forms.ToolStripButton btnUpdateDB;
        private System.Windows.Forms.ToolStripMenuItem readDBORMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readOrdiniCustomerORMToolStripMenuItem;
    }
}

