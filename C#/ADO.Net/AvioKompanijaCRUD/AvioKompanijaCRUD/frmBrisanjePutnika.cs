using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AvioKompanijaCRUD
{
    public partial class frmBrisanjePutnika : Form
    {
        string konekcioniString;
        SqlConnection konekcija;
        SqlCommand komanda;

        public frmBrisanjePutnika()
        {
            InitializeComponent();
            konekcioniString = "server=.;Database=AvioKompanija;Integrated Security=SSPI;";
        }

        private void OsveziEkran()
        {
            using (konekcija = new SqlConnection(konekcioniString))
            {
                komanda = new SqlCommand("SELECT * FROM Putnik", konekcija);
                konekcija.Open();
                SqlDataReader rider = komanda.ExecuteReader();

                if (rider.HasRows)
                {
                    DataTable tabela = new DataTable();
                    tabela.Load(rider);
                    dataGridView1.DataSource = tabela;
                }
            }
        }

        private void frmBrisanjePutnika_Load(object sender, EventArgs e)
        {
            OsveziEkran();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (konekcija = new SqlConnection(konekcioniString))
            {
                komanda = new SqlCommand
                ("DELETE Putnik WHERE Brlk = " + int.Parse(textBox1.Text), konekcija);

                try
                {
                    konekcija.Open();
                    int redovi = komanda.ExecuteNonQuery();
                    MessageBox.Show("Uspesno ste izbrisali Putnika iz baze", "INFORMACIJA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch (Exception)
                {
                    MessageBox.Show("Greska, Putnik nije obrisan !", "GRESKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                finally
                {
                    OsveziEkran();
                    konekcija.Close();
                }
            }
        }
    }
}
