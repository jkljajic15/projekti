using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AvioKompanijaCRUD
{
    public partial class frmMeni : Form
    {
        public frmMeni()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmUnosPutnika up = new frmUnosPutnika();
            up.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmIzmenaPutnika ip = new frmIzmenaPutnika();
            ip.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmBrisanjePutnika bp = new frmBrisanjePutnika();
            bp.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmUnosKarata uk = new frmUnosKarata();
            uk.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmIzmenaKarata ik = new frmIzmenaKarata();
            ik.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmBrisanjeKarata bk = new frmBrisanjeKarata();
            bk.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmUnosKupona ukp = new frmUnosKupona();
            ukp.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            frmIzmenaKupona ikp = new frmIzmenaKupona();
            ikp.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            frmBrisanjeKupona bkp = new frmBrisanjeKupona();
            bkp.Show();
        }
    }
}
