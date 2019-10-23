using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace uskladisteneProcedureCRUD
{
    public partial class Meni : Form
    {
        public Meni()
        {
            InitializeComponent();
        }

        private void unosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Unos frmUnos = new Unos();
            frmUnos.Show();
        }

        private void izmenaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Izmena frmIzmena = new Izmena();
            frmIzmena.Show();
        }

        private void brisanjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Brisanje frmBrisanje = new Brisanje();
            frmBrisanje.Show();
        }
    }
}
