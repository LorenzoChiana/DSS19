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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(View));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readDBRandomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sARIMAForecastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optimizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnOptimization = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.comboBoxClients = new System.Windows.Forms.ComboBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.sqLiteCommandBuilder1 = new System.Data.SQLite.SQLiteCommandBuilder();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnDB = new System.Windows.Forms.ToolStripButton();
            this.btnSARIMA = new System.Windows.Forms.ToolStripButton();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
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
            this.readDBRandomToolStripMenuItem,
            this.sARIMAForecastToolStripMenuItem,
            this.optimizationToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // readDBRandomToolStripMenuItem
            // 
            this.readDBRandomToolStripMenuItem.Name = "readDBRandomToolStripMenuItem";
            this.readDBRandomToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.readDBRandomToolStripMenuItem.Text = "Read DB random";
            this.readDBRandomToolStripMenuItem.Click += new System.EventHandler(this.readDBRandomToolStripMenuItem_Click);
            // 
            // sARIMAForecastToolStripMenuItem
            // 
            this.sARIMAForecastToolStripMenuItem.Enabled = false;
            this.sARIMAForecastToolStripMenuItem.Name = "sARIMAForecastToolStripMenuItem";
            this.sARIMAForecastToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.sARIMAForecastToolStripMenuItem.Text = "SARIMA Forecast";
            this.sARIMAForecastToolStripMenuItem.Click += new System.EventHandler(this.sARIMAForecastToolStripMenuItem_Click);
            // 
            // optimizationToolStripMenuItem
            // 
            this.optimizationToolStripMenuItem.Name = "optimizationToolStripMenuItem";
            this.optimizationToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.optimizationToolStripMenuItem.Text = "Optimization";
            this.optimizationToolStripMenuItem.Click += new System.EventHandler(this.optimizationToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDB,
            this.btnSARIMA,
            this.btnOptimization});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(847, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnOptimization
            // 
            this.btnOptimization.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOptimization.Image = global::DSS19.Properties.Resources.Center_City_Sign_svg;
            this.btnOptimization.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOptimization.Name = "btnOptimization";
            this.btnOptimization.Size = new System.Drawing.Size(23, 22);
            this.btnOptimization.Text = "Optimization";
            this.btnOptimization.Click += new System.EventHandler(this.btnOptimization_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.comboBoxClients);
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
            // comboBoxClients
            // 
            this.comboBoxClients.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxClients.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxClients.FormattingEnabled = true;
            this.comboBoxClients.Location = new System.Drawing.Point(75, 7);
            this.comboBoxClients.Name = "comboBoxClients";
            this.comboBoxClients.Size = new System.Drawing.Size(203, 23);
            this.comboBoxClients.TabIndex = 2;
            this.comboBoxClients.SelectedIndexChanged += new System.EventHandler(this.comboBoxClients_SelectedIndexChanged);
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(10, 10);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(63, 15);
            this.lblCustomer.TabIndex = 1;
            this.lblCustomer.Text = "Customer:";
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
            // sqLiteCommandBuilder1
            // 
            this.sqLiteCommandBuilder1.DataAdapter = null;
            this.sqLiteCommandBuilder1.QuoteSuffix = "]";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(562, 472);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
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
            // btnSARIMA
            // 
            this.btnSARIMA.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSARIMA.Enabled = false;
            this.btnSARIMA.Image = global::DSS19.Properties.Resources.gaussian__pure;
            this.btnSARIMA.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSARIMA.Name = "btnSARIMA";
            this.btnSARIMA.Size = new System.Drawing.Size(23, 22);
            this.btnSARIMA.Text = "SARIMA";
            this.btnSARIMA.Click += new System.EventHandler(this.btnSARIMA_Click);
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
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnDB;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblCustomer;
        private System.Data.SQLite.SQLiteCommandBuilder sqLiteCommandBuilder1;
        private System.Windows.Forms.ToolStripButton btnSARIMA;
        private System.Windows.Forms.ToolStripMenuItem readDBRandomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sARIMAForecastToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton btnOptimization;
        private System.Windows.Forms.ToolStripMenuItem optimizationToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBoxClients;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}

