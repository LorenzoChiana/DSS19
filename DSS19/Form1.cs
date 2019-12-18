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

            dbOrdiniPath = ConfigurationManager.AppSettings["dbOrdiniFile"];
            pythonPath = ConfigurationManager.AppSettings["pythonPath"];
            pythonScriptPath = ConfigurationManager.AppSettings["pyScripts"];

            C = new Controller(pythonPath, pythonScriptPath);
        }


        private void btnReadDB_Click(object sender, EventArgs e)
        {
            readDB();
        }

        private async void readDB()
        {
            C.readRandClientiDB(dbOrdiniPath);                      //lettura da parte del controller dei clienti in maniera random
            string strClients = C.readClientiDB(dbOrdiniPath);      //lettura di tutti i clienti da mettere poi nella combo box
            bmp = await C.readCustomerOrdersChart(dbOrdiniPath);    //grafico degli ordini dei clienti random
            pictureBox1.Image = bmp;

            fillComboBox(strClients);                               //riempio la combo box con tutti i clienti
        }

        private void fillComboBox(string strClients)
        {
            comboBoxClients.Items.Clear();
            string[] clients = strClients.Split(',');
            foreach (var client in clients)
            {
                comboBoxClients.Items.Add(client);
            }
        }


        private async void SARIMAClient(string cust)
        {
            bmp = await C.arimaCustomer(dbOrdiniPath, cust);
            pictureBox1.Image = bmp;
        }

        private void btnSARIMA_Click(object sender, EventArgs e)
        {
            SARIMAClient("'" + comboBoxClients.Text + "'");
        }

        private void readDBRandomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            readDB();
        }

        private void sARIMAForecastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SARIMAClient("'" + comboBoxClients.Text + "'");
        }

        private void comboBoxClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSARIMA.Enabled = true;
            sARIMAForecastToolStripMenuItem.Enabled = true;
        }

        private void btnOptimization_Click(object sender, EventArgs e)
        {
            C.optimizeGAP(dbOrdiniPath);
        }

        private void optimizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            C.optimizeGAP(dbOrdiniPath);
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
