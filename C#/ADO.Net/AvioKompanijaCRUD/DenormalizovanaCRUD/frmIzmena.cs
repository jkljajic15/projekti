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
    public partial class frmIzmena : Form
    {
        string konekcioniString = "";
        SqlConnection konekcija;
        SqlCommand komanda;

        public frmIzmena()
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

        private void frmIzmena_Load(object sender, EventArgs e)
        {
            OsveziEkran();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (konekcija = new SqlConnection(konekcioniString))
            {
                konekcija.Open();

                string tekstKomande = "UPDATE KartaDenormalizovana SET DatIzd = @datizd, VaziDO = @vazido, Cena = @cena, Brlk = @brlk WHERE BrojKarte = @brojkarte";
                komanda = new SqlCommand(tekstKomande, konekcija);

                komanda.Parameters.Add("@brojkarte", SqlDbType.Int).Value = Convert.ToInt32(textBox1.Text);
                komanda.Parameters.Add("@datizd", SqlDbType.Date).Value = dateTimePicker1.Value.Date;
                komanda.Parameters.Add("@vazido", SqlDbType.Date).Value = dateTimePicker2.Value.Date;
                komanda.Parameters.Add("@cena", SqlDbType.Decimal).Value = Convert.ToInt32(textBox4.Text);
                komanda.Parameters.Add("@brlk", SqlDbType.Int).Value = Convert.ToInt32(textBox5.Text);

                try
                {
                    komanda.ExecuteNonQuery();
                    MessageBox.Show("Uspesno ste izmenili Kartu u bazi", "INFORMACIJA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch (Exception ex)
                {
                    if(ex is SqlException)
                    {
                        MessageBox.Show("Nije dozvoljeno azuriranje Brlk", "GRESKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        //MessageBox.Show(ex.ToString());
                        MessageBox.Show("Nastala je greska ! Proverite ulazne podatke.", "GRESKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
