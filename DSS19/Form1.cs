﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace DSS19
{
    public partial class Form1 : Form
    {
        private Controller c = new Controller();
        TextBoxTraceListener _textBoxListener;
        public Form1()
        {
            InitializeComponent();
            _textBoxListener = new TextBoxTraceListener(txtConsole); 
            Trace.Listeners.Add(_textBoxListener);
        }

        private void readDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            readDB();
        }

        private void btnReadDB_Click(object sender, EventArgs e)
        {
            readDB();
        }

        private void readDB()
        {
            //Trace.WriteLine("ciao ciao");
            //txtConsole.AppendText();
            c.readDB();
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
