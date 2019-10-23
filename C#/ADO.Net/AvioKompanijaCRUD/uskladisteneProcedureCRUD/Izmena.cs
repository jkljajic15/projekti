using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace uskladisteneProcedureCRUD
{
    public partial class Izmena : Form
    {
        string konekcioniString = "";
        SqlConnection konekcija;
        SqlCommand komanda;

        public Izmena()
        {
            InitializeComponent();
            konekcioniString = "Server=.;Database=AvioKompanija;Integrated Security=SSPI;";
        }

        private void OsveziEkran()
        {
            using (konekcija = new SqlConnection(konekcioniString))
            {
                komanda = new SqlCommand("exec LetilicaSelect", konekcija);
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

        private void Izmena_Load(object sender, EventArgs e)
        {
            OsveziEkran();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (konekcija = new SqlConnection(konekcioniString))
            {
                komanda = new SqlCommand("exec LetilicaUpdate @regbr, @tip, @naziv, @opis", konekcija);

                komanda.Parameters.Add("@regbr", SqlDbType.Int).Value = Convert.ToInt32(textBox1.Text);
                komanda.Parameters.Add("@tip", SqlDbType.NVarChar).Value = textBox2.Text;
                komanda.Parameters.Add("@naziv", SqlDbType.NVarChar).Value = textBox3.Text;
                komanda.Parameters.Add("@opis", SqlDbType.NVarChar).Value = textBox4.Text;

                try
                {
                    konekcija.Open();
                    komanda.ExecuteNonQuery();
                    MessageBox.Show("Uspesno ste uradili update Letilice u bazi", "INFORMACIJA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch (Exception)
                {
                    //MessageBox.Show(ex.ToString());
                    MessageBox.Show("Greska, Letilica nije izmenjena!", "GRESKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
