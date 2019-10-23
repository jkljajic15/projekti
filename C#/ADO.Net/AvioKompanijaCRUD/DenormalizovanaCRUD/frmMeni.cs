using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DenormalizovanaCRUD
{
    public partial class frmMeni : Form
    {
        public frmMeni()
        {
            InitializeComponent();
        }

        private void unosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUnos frmUnos = new frmUnos();
            frmUnos.Show();
        }

        private void izmenaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIzmena frmIzmena = new frmIzmena();
            frmIzmena.Show();
        }

        private void brisanjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBrisanje frmBrisanje = new frmBrisanje();
            frmBrisanje.Show();
        }
    }
}
