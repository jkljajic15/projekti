using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WebServisDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SW.ServiceSoapClient x = new SW.ServiceSoapClient();
            dataGridView1.DataSource = x.FaktureKupaca(Convert.ToInt32(textBox1.Text)).Tables[0];
        }
    }
}
