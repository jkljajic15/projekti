using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace AvioKompanijaCRUD
{
    public partial class frmUnosKarata : Form
    {
        string konekcioniString;
        SqlConnection konekcija;
        SqlCommand komanda;

        public frmUnosKarata()
        {
            InitializeComponent();
            konekcioniString = "server=.;Database=AvioKompanija;Integrated Security=SSPI;";
        }

        private void OsveziEkran()
        {
            using (konekcija = new SqlConnection(konekcioniString))
            {
                komanda = new SqlCommand("SELECT * FROM Karta", konekcija);
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

        private void frmUnosKarata_Load(object sender, EventArgs e)
        {
            OsveziEkran();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (konekcija = new SqlConnection(konekcioniString))
            {
                komanda =
                new SqlCommand("INSERT INTO Karta (BrojKarte,DatIzd,VaziDo,Cena,Brlk) VALUES(@BrojKarte,@DatIzd,@VaziDo,@Cena,@Brlk)", konekcija);

                komanda.Parameters.Add("@BrojKarte", SqlDbType.Int);
                komanda.Parameters["@BrojKarte"].Value = Convert.ToInt32(textBox1.Text);

                komanda.Parameters.Add("@DatIzd", SqlDbType.Date).Value = dateTimePicker1.Value.Date;

                komanda.Parameters.Add("@VaziDo", SqlDbType.Date).Value = dateTimePicker2.Value.Date;

                komanda.Parameters.Add("@Cena", SqlDbType.Decimal).Value = textBox4.Text;

                komanda.Parameters.Add("@Brlk", SqlDbType.Int).Value = textBox5.Text;


                konekcija.Open();

                try
                {
                    komanda.ExecuteNonQuery();
                    MessageBox.Show("Uspesno ste ubacili Kartu u bazu", "INFORMACIJA", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
