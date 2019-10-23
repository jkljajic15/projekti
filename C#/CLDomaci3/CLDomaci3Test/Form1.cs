using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CLDomaci3Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CLDomaci3.Class1 x = new CLDomaci3.Class1();

            openFileDialog1.Filter = "Text files|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            x.putanja = openFileDialog1.FileName;

            textBox1.Text = x.Read(x.putanja);

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CLDomaci3.Class1 x = new CLDomaci3.Class1();

            saveFileDialog1.Filter = "Text files|*.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) return;

            x.putanja = saveFileDialog1.FileName;
            x.sadrzaj = textBox1.Text;
            x.Save(x.sadrzaj, x.putanja);
        }
    }
}
