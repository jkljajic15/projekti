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
    public partial class frmIzmenaKupona : Form
    {
        string konekcioniString;
        SqlConnection konekcija;
        SqlCommand komanda;

        public frmIzmenaKupona()
        {
            InitializeComponent();
            konekcioniString = "server=.;Database=AvioKompanija;Integrated Security=SSPI;";
        }

        private void OsveziEkran()
        {
            using (konekcija = new SqlConnection(konekcioniString))
            {
                komanda = new SqlCommand("SELECT * FROM Kupon", konekcija);
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

        private void frmIzmenaKupona_Load(object sender, EventArgs e)
        {
            OsveziEkran();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (konekcija = new SqlConnection(konekcioniString))
            {
                konekcija.Open();
                                
                string tekstKomande = "UPDATE Kupon Set Klasa = @Klasa,StatusKupona = @StatusKupona,Komentar = @Komentar," +
                    " SifraLinije = @SifraLinije, BrLeta = @BrLeta, DatumVreme = @DatumVreme, BrojSedista = @BrojSedista, " +
                    "RegBr = @RegBr WHERE BrojKarte = @BrojKarte AND BrojKupona = @BrojKupona";
                komanda = new SqlCommand(tekstKomande, konekcija);

                komanda.Parameters.Add("@BrojKarte", SqlDbType.Int).Value = Convert.ToInt32(textBox1.Text);
                komanda.Parameters.Add("@BrojKupona", SqlDbType.Int).Value = Convert.ToInt32(textBox2.Text);
                komanda.Parameters.Add("@Klasa", SqlDbType.NVarChar).Value = textBox3.Text;
                komanda.Parameters.Add("@StatusKupona", SqlDbType.Bit).Value = Convert.ToInt32(textBox4.Text);
                komanda.Parameters.Add("@Komentar", SqlDbType.NVarChar).Value = textBox5.Text;
                komanda.Parameters.Add("@SifraLinije",SqlDbType.Int).Value = Convert.ToInt32(textBox6.Text);
                komanda.Parameters.Add("@BrLeta", SqlDbType.Int).Value = Convert.ToInt32(textBox7.Text);
                komanda.Parameters.Add("@DatumVreme", SqlDbType.SmallDateTime).Value = dateTimePicker1.Value.Date + /*" " +*/ dateTimePicker2.Value.TimeOfDay;
                komanda.Parameters.Add("@BrojSedista", SqlDbType.Int).Value = Convert.ToInt32(textBox8.Text);
                komanda.Parameters.Add("@RegBr", SqlDbType.Int).Value = Convert.ToInt32(textBox9.Text);

                try
                {
                    komanda.ExecuteNonQuery();
                    MessageBox.Show("Uspesno ste izmenili Kupon u bazi", "INFORMACIJA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    //MessageBox.Show("Nastala je greska ! Proverite ulazne podatke.", "GRESKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
