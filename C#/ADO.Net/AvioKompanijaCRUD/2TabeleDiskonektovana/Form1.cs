using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace _2TabeleDiskonektovana
{
    public partial class Form1 : Form
    {
        string konekcioniString;
        SqlConnection konekcija;
        SqlCommand komanda;

        public Form1()
        {
            InitializeComponent();
            konekcioniString = "Server=.;Database=AvioKompanija;Integrated Security=SSPI";
        }

        private void UcitajUGrid()
        {
            using(konekcija = new SqlConnection(konekcioniString))
            {
                SqlDataAdapter adapter1 = new SqlDataAdapter("SELECT * FROM Aerodrom", konekcija);
                DataTable tabela1 = new DataTable();
                adapter1.Fill(tabela1);
                dataGridView1.DataSource = tabela1;

                SqlDataAdapter adapter2 = new SqlDataAdapter("SELECT * FROM AvioRuta", konekcija);
                DataTable tabela2 = new DataTable();
                adapter2.Fill(tabela2);
                dataGridView2.DataSource = tabela2;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UcitajUGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (konekcija = new SqlConnection(konekcioniString))
            {
                komanda = new SqlCommand("INSERT INTO Aerodrom VALUES(@sifra,@naziv)", konekcija);

                komanda.Parameters.Add("@sifra", SqlDbType.Int).Value = Convert.ToInt32(textBox1.Text);
                komanda.Parameters.Add("@naziv", SqlDbType.NVarChar).Value = textBox2.Text;

                SqlDataAdapter da = new SqlDataAdapter();
                da.InsertCommand = komanda;

                try
                {
                    konekcija.Open();
                    da.InsertCommand.ExecuteNonQuery();
                    MessageBox.Show("Uspesna operacija", "INFORMACIJA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    UcitajUGrid();
                    konekcija.Close();

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (konekcija = new SqlConnection(konekcioniString))
            {
                komanda = new SqlCommand("UPDATE Aerodrom SET NazivAer = @naziv WHERE SifraAer = @sifra", konekcija);

                komanda.Parameters.Add("@sifra", SqlDbType.Int).Value = Convert.ToInt32(textBox1.Text);
                komanda.Parameters.Add("@naziv", SqlDbType.NVarChar).Value = textBox2.Text;

                SqlDataAdapter da = new SqlDataAdapter();
                da.UpdateCommand = komanda;

                try
                {
                    konekcija.Open();
                    da.UpdateCommand.ExecuteNonQuery();
                    MessageBox.Show("Uspesna operacija", "INFORMACIJA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    UcitajUGrid();
                    konekcija.Close();

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (konekcija = new SqlConnection(konekcioniString))
            {
                komanda = new SqlCommand("DELETE Aerodrom WHERE SifraAer = @sifra", konekcija);

                komanda.Parameters.Add("@sifra", SqlDbType.Int).Value = Convert.ToInt32(textBox1.Text);
                
                SqlDataAdapter da = new SqlDataAdapter();
                da.DeleteCommand = komanda;

                try
                {
                    konekcija.Open();
                    da.DeleteCommand.ExecuteNonQuery();
                    MessageBox.Show("Uspesna operacija", "INFORMACIJA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    UcitajUGrid();
                    konekcija.Close();

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (konekcija = new SqlConnection(konekcioniString))
            {
                komanda = new SqlCommand("INSERT INTO AvioRuta VALUES(@sifra,@let,@pol,@dol)", konekcija);

                komanda.Parameters.Add("@sifra", SqlDbType.Int).Value = Convert.ToInt32(textBox3.Text);
                komanda.Parameters.Add("@let", SqlDbType.Int).Value = Convert.ToInt32(textBox4.Text);
                komanda.Parameters.Add("@pol", SqlDbType.NVarChar).Value = textBox5.Text;
                komanda.Parameters.Add("@dol", SqlDbType.NVarChar).Value = textBox6.Text;

                SqlDataAdapter da = new SqlDataAdapter();
                da.InsertCommand = komanda;

                try
                {
                    konekcija.Open();
                    da.InsertCommand.ExecuteNonQuery();
                    MessageBox.Show("Uspesna operacija", "INFORMACIJA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    UcitajUGrid();
                    konekcija.Close();

                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (konekcija = new SqlConnection(konekcioniString))
            {
                komanda = 
                    new SqlCommand("UPDATE AvioRuta SET SifraPolAer = @pol, SifraOdrAer = @dol WHERE SifraLinije = @sifra AND BrLeta = @let ", konekcija);

                komanda.Parameters.Add("@sifra", SqlDbType.Int).Value = Convert.ToInt32(textBox3.Text);
                komanda.Parameters.Add("@let", SqlDbType.Int).Value = Convert.ToInt32(textBox4.Text);
                komanda.Parameters.Add("@pol", SqlDbType.NVarChar).Value = textBox5.Text;
                komanda.Parameters.Add("@dol", SqlDbType.NVarChar).Value = textBox6.Text;

                SqlDataAdapter da = new SqlDataAdapter();
                da.InsertCommand = komanda;

                try
                {
                    konekcija.Open();
                    da.InsertCommand.ExecuteNonQuery();
                    MessageBox.Show("Uspesna operacija", "INFORMACIJA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    UcitajUGrid();
                    konekcija.Close();

                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (konekcija = new SqlConnection(konekcioniString))
            {
                komanda = new SqlCommand("DELETE AvioRuta WHERE SifraLinije = @sifra AND BrLeta = @let", konekcija);

                komanda.Parameters.Add("@sifra", SqlDbType.Int).Value = Convert.ToInt32(textBox3.Text);
                komanda.Parameters.Add("@let", SqlDbType.Int).Value = Convert.ToInt32(textBox4.Text);

                SqlDataAdapter da = new SqlDataAdapter();
                da.DeleteCommand = komanda;

                try
                {
                    konekcija.Open();
                    da.DeleteCommand.ExecuteNonQuery();
                    MessageBox.Show("Uspesna operacija", "INFORMACIJA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    UcitajUGrid();
                    konekcija.Close();

                }
            }
        }
    }
}
