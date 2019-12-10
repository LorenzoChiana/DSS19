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
            this.readDBRandomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sARIMAForecastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forecastsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnDB = new System.Windows.Forms.ToolStripButton();
            this.btnSARIMA = new System.Windows.Forms.ToolStripButton();
            this.btnForecasts = new System.Windows.Forms.ToolStripButton();
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
            this.readDBRandomToolStripMenuItem,
            this.sARIMAForecastToolStripMenuItem,
            this.forecastsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // readDBRandomToolStripMenuItem
            // 
            this.readDBRandomToolStripMenuItem.Name = "readDBRandomToolStripMenuItem";
            this.readDBRandomToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.readDBRandomToolStripMenuItem.Text = "Read DB random";
            this.readDBRandomToolStripMenuItem.Click += new System.EventHandler(this.readDBRandomToolStripMenuItem_Click);
            // 
            // sARIMAForecastToolStripMenuItem
            // 
            this.sARIMAForecastToolStripMenuItem.Name = "sARIMAForecastToolStripMenuItem";
            this.sARIMAForecastToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sARIMAForecastToolStripMenuItem.Text = "SARIMA Forecast";
            this.sARIMAForecastToolStripMenuItem.Click += new System.EventHandler(this.sARIMAForecastToolStripMenuItem_Click);
            // 
            // forecastsToolStripMenuItem
            // 
            this.forecastsToolStripMenuItem.Name = "forecastsToolStripMenuItem";
            this.forecastsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.forecastsToolStripMenuItem.Text = "Forecasts";
            this.forecastsToolStripMenuItem.Click += new System.EventHandler(this.forecastsToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDB,
            this.btnSARIMA,
            this.btnForecasts});
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
            // btnSARIMA
            // 
            this.btnSARIMA.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSARIMA.Image = ((System.Drawing.Image)(resources.GetObject("btnSARIMA.Image")));
            this.btnSARIMA.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSARIMA.Name = "btnSARIMA";
            this.btnSARIMA.Size = new System.Drawing.Size(23, 22);
            this.btnSARIMA.Text = "SARIMA";
            this.btnSARIMA.Click += new System.EventHandler(this.btnSARIMA_Click);
            // 
            // btnForecasts
            // 
            this.btnForecasts.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnForecasts.Image = ((System.Drawing.Image)(resources.GetObject("btnForecasts.Image")));
            this.btnForecasts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnForecasts.Name = "btnForecasts";
            this.btnForecasts.Size = new System.Drawing.Size(23, 22);
            this.btnForecasts.Text = "Forecasts";
            this.btnForecasts.Click += new System.EventHandler(this.btnForecasts_Click);
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
            this.txtCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustomer.Location = new System.Drawing.Point(86, 9);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(192, 21);
            this.txtCustomer.TabIndex = 2;
            this.txtCustomer.TextChanged += new System.EventHandler(this.txtCustomer_TextChanged);
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
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnDB;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label lblCustomer;
        private System.Data.SQLite.SQLiteCommandBuilder sqLiteCommandBuilder1;
        private System.Windows.Forms.ToolStripButton btnSARIMA;
        private System.Windows.Forms.ToolStripButton btnForecasts;
        private System.Windows.Forms.ToolStripMenuItem readDBRandomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sARIMAForecastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forecastsToolStripMenuItem;
    }
}

