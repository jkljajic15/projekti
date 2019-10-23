using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Domaci_zadatak_1
{
    public partial class Form1 : Form
    {
        string imeFajla, promenjenitxt;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text files|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            imeFajla = openFileDialog1.FileName;

             otvoriIspisi(imeFajla);
                                   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (imeFajla == "")
            {
                MessageBox.Show("Fajl je prazan!");
                return;
            }

            if(textBox1.Text.Trim() == "")
            {
                MessageBox.Show("Unesi tekst koji treba da se pronađe!");
                textBox1.Focus();
                return;
            }

            if (textBox2.Text.Trim() == "")
            {
                MessageBox.Show("Unesi tekst kojim se menja!");
                textBox2.Focus();
                return;
            }

            string pronađi, zameni;

            pronađi = textBox1.Text;
            zameni = textBox2.Text;
            promenjenitxt = otvoriIspisi(imeFajla).Replace(pronađi, zameni);
            MessageBox.Show("Zamena je uspesna", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBox3.Text = promenjenitxt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string izabranifajl;
            saveFileDialog1.Filter = "Text files|*.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            izabranifajl = saveFileDialog1.FileName;

            snimanje(izabranifajl, promenjenitxt);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            Application.Exit();
        }

        string otvoriIspisi(string a)
        {
            string b = "";
            try
            {
                StreamReader sr = new StreamReader(a);
                textBox3.Text = sr.ReadToEnd();
                sr.Close();
                b = textBox3.Text;
                return b;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return b;
            }
        }

        bool snimanje(string a, string b)
        {
            try
            {
                StreamWriter sw = new StreamWriter(a);
                sw.Write(b);
                sw.Close();
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
    }
}
