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
    public partial class frmUnosPutnika : Form
    {
        string konekcioniString;
        SqlConnection konekcija;
        SqlCommand komanda;

        public frmUnosPutnika()
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

        private void frmUnosPutnika_Load(object sender, EventArgs e)
        {
            OsveziEkran();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (konekcija = new SqlConnection(konekcioniString))
            {
                komanda =
                new SqlCommand("INSERT INTO Putnik (Brlk, Ime, Prezime) " +
                "VALUES(" + int.Parse(textBox1.Text) + ", '" + textBox2.Text + "', '" + textBox3.Text + "')", konekcija);
                konekcija.Open();

                try
                {
                    komanda.ExecuteNonQuery();
                    MessageBox.Show("Uspesno ste ubacili Putnika u bazu", "INFORMACIJA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch (Exception)
                {
                    MessageBox.Show("Nastala je greska ! Proverite ulazne podatke.", "GRESKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
