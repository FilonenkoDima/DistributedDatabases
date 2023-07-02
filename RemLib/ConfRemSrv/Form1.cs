using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting;

namespace ConfRemSrv
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RemotingConfiguration.Configure(@"Srv.config",false);
            WellKnownServiceTypeEntry[] entries = RemotingConfiguration.GetRegisteredWellKnownServiceTypes();
            foreach (var entry in entries)
            {
                listBox1.Items.Add(string.Format("Сборка: {0}", entry.AssemblyName));
                listBox1.Items.Add(string.Format("Режим: {0}", entry.Mode));
                listBox1.Items.Add(string.Format("URI: {0}", entry.ObjectUri));
                listBox1.Items.Add(string.Format("Тип: {0}", entry.TypeName));
            }
        }
    }
}
