using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DenormalizovanaCRUD
{
    public partial class frmBrisanje : Form
    {
        string konekcioniString = "";
        SqlConnection konekcija;
        SqlCommand komanda;

        public frmBrisanje()
        {
            InitializeComponent();
            konekcioniString = "Server=.;Database=AvioKompanija;Integrated Security=SSPI;";
        }

        private void OsveziEkran()
        {
            using (konekcija = new SqlConnection(konekcioniString))
            {
                komanda = new SqlCommand("SELECT * FROM KartaDenormalizovana", konekcija);
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

        private void frmBrisanje_Load(object sender, EventArgs e)
        {
            OsveziEkran();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (konekcija = new SqlConnection(konekcioniString))
            {
                konekcija.Open();
                                
                string tekstKomande = "DELETE KartaDenormalizovana WHERE BrojKarte = @brojkarte";
                komanda = new SqlCommand(tekstKomande, konekcija);

                komanda.Parameters.Add("@brojkarte", SqlDbType.Int).Value = Convert.ToInt32(textBox1.Text);

                try
                {
                    komanda.ExecuteNonQuery();
                    MessageBox.Show("Uspesno ste obrisali Kartu u bazi", "INFORMACIJA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch (Exception)
                {
                    //MessageBox.Show(ex.ToString());
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
