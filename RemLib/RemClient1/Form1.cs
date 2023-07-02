using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RemLib;
using System.Runtime.Remoting;

namespace RemClient1
{
    public partial class Form1 : Form
    {
        RemObj1 obj = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*RemotingConfiguration.RegisterWellKnownClientType(typeof(RemObj1), "tcp://localhost:888/uri");
            obj = new RemObj1();*/
            this.obj = (RemObj1)Activator.GetObject(typeof(RemObj1), "TCP://localhost:888/uri");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dgv.DataSource = obj.GetTable(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\MyDB.mdb;Persist Security Info=False;", tb.Text);
        }
    }
}
