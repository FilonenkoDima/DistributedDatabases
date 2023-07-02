using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RemLib;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;

namespace RemSrv1
{
    public partial class Form1 : Form
    {
        RemObj1 ro1;
        TcpChannel channel;
        
        public Form1()
        {
            InitializeComponent();
            channel = new TcpChannel(888);
            ChannelServices.RegisterChannel(channel, false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ro1 = new RemObj1();
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemObj1), "uri",
                WellKnownObjectMode.Singleton);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt=ro1.GetTable(comboBox1.Text, "Student");
            dataGridView1.DataSource=dt;
        }
    }
}
