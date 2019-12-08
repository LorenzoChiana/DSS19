using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Configuration;

namespace DSS19
{
    public partial class View : Form
    {
        private Controller C;
        TextBoxTraceListener _textBoxListener; // variabile classe Form
        string dbOrdiniPath, pythonPath, pythonScriptPath;
        Bitmap bmp;
     
        public View()
        {
            InitializeComponent();

            _textBoxListener = new TextBoxTraceListener(txtConsole); 
            Trace.Listeners.Add(_textBoxListener);

            /*string dbPath = "";
            OpenFileDialog OFD = new OpenFileDialog();
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                dbPath = OFD.FileName;
                txtConsole.AppendText("Sqlite file name: " + dbPath + Environment.NewLine);
            }*/

            dbOrdiniPath = ConfigurationManager.AppSettings["dbOrdiniFile"];
            pythonPath = ConfigurationManager.AppSettings["pythonPath"];
            pythonScriptPath = ConfigurationManager.AppSettings["pyScripts"];

            C = new Controller(/*dbOrdiniPath, */pythonPath, pythonScriptPath);
        }



        private void readDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            readDB();
        }

        private void btnReadDB_Click(object sender, EventArgs e)
        {
            readDB();
        }

        private async void readDB()
        {
            //C.readDB(txtCustomer.Text);
            C.readClientiDB(dbOrdiniPath);
            bmp = await C.readCustomerOrdersChart(dbOrdiniPath);
            pictureBox1.Image = bmp;
            btnSARIMA.Enabled = true;
        }

        private void deleteDBADOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteDB();
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertDB();
        }

        private void updateDBADOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateDB();
        }

        private void btnDeleteDB_Click(object sender, EventArgs e)
        {
            deleteDB();
        }

        private void deleteDB()
        {
            C.deleteDB(txtCustomer.Text);
        }

        private void insertDB()
        {
            C.insertDB(txtCustomer.Text);
        }

        private void updateDB()
        {
            C.updateDB(txtCustomer.Text);
        }

        private void btnInsertDB_Click(object sender, EventArgs e)
        {
            insertDB();
        }

        private void btnUpdateDB_Click(object sender, EventArgs e)
        {
            updateDB();
        }

        private async void ARIMAClient(string cust)
        {
            //C.readDB(txtCustomer.Text);
            bmp = await C.arimaCustomer(dbOrdiniPath, cust);
            pictureBox1.Image = bmp;
        }

        private void btnARIMA_Click(object sender, EventArgs e)
        {
            ARIMAClient("'" + txtCustomer.Text + "'");
        }

        private async void btnForecasts_Click(object sender, EventArgs e)
        {
            //string arimaForecasts = await C.arimaForecasts(dbOrdiniPath);
            Trace.WriteLine("Getting forecast's values ... ");
            for (int i = 0; i < Controller.NUMCUST; i++)
            {
                double val = await C.arimaForecasts(dbOrdiniPath, i);
                Trace.WriteLine("Forecast value: " + val.ToString());
            }
        }

        private void txtCustomer_TextChanged(object sender, EventArgs e)
        {

        }

        private void readDBORMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            C.readCustomerListORM();
        }

        private void readOrdiniCustomerORMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            C.readCustomerListORM(txtCustomer.Text);
        }
    }

    public class TextBoxTraceListener : TraceListener
    {
        private TextBox _target;
        private StringSendDelegate _invokeWrite;
        public TextBoxTraceListener(TextBox target)
        {
            _target = target;
            _invokeWrite = new StringSendDelegate(SendString);
        }
        public override void Write(string message)
        { _target.Invoke(_invokeWrite, new object[] { message }); }
        public override void WriteLine(string message)
        { _target.Invoke(_invokeWrite, new object[] { message + Environment.NewLine }); }
        private delegate void StringSendDelegate(string message);
        private void SendString(string message)
        { _target.AppendText(message); }
    }
}
