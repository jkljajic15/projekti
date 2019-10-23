using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace EntityFrameworkProjekat
{
    /// <summary>
    /// Interaction logic for wndPredmet.xaml
    /// </summary>
    public partial class wndPredmet : Window
    {
        string konekcioniString;
        SqlConnection konekcija;
        SqlCommand komanda;

        public wndPredmet()
        {
            InitializeComponent();
            konekcioniString = ConfigurationManager.ConnectionStrings["konfiguracijaKonekcije"].ConnectionString;
            OsveziEkran();

        }

        private void OsveziEkran()
        {
            using (konekcija = new SqlConnection(konekcioniString))
            {
                komanda = new SqlCommand("SELECT * FROM Predmet", konekcija);

                SqlDataAdapter da = new SqlDataAdapter(komanda);
                DataTable tabela = new DataTable();
                da.Fill(tabela);
                grdPredmet.ItemsSource = tabela.DefaultView;



            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (konekcija = new SqlConnection(konekcioniString))
            {
                komanda = new SqlCommand("INSERT INTO Predmet VALUES(@predmetid,@nazivpredmeta,@smerid)", konekcija);

                komanda.Parameters.Add("@predmetid", SqlDbType.Int).Value = txtPredmetID.Text;
                komanda.Parameters.Add("@nazivpredmeta", SqlDbType.NVarChar).Value = txtNazivPredmeta.Text;
                komanda.Parameters.Add("@smerid", SqlDbType.NVarChar).Value = txtSmerID.Text;

                try
                {
                    konekcija.Open();
                    komanda.ExecuteNonQuery();
                    MessageBox.Show("Uspesna akcija", "INFORMACIJA", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    OsveziEkran();
                    konekcija.Close();
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (konekcija = new SqlConnection(konekcioniString))
            {
                komanda = new SqlCommand("UPDATE Predmet SET NaizvPredmeta = @nazivpredmeta, SmerID = @smerid WHERE PredmetID = @predmetid", konekcija);

                komanda.Parameters.Add("@predmetid", SqlDbType.Int).Value = txtPredmetID.Text;
                komanda.Parameters.Add("@nazivpredmeta", SqlDbType.NVarChar).Value = txtNazivPredmeta.Text;
                komanda.Parameters.Add("@smerid", SqlDbType.NVarChar).Value = txtSmerID.Text;

                try
                {
                    konekcija.Open();
                    komanda.ExecuteNonQuery();
                    MessageBox.Show("Uspesna akcija", "INFORMACIJA", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    OsveziEkran();
                    konekcija.Close();
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            using (konekcija = new SqlConnection(konekcioniString))
            {
                komanda = new SqlCommand("DELETE Predmet WHERE PredmetID = @predmetid", konekcija);

                komanda.Parameters.Add("@predmetid", SqlDbType.Int).Value = txtPredmetID.Text;

                try
                {
                    konekcija.Open();
                    komanda.ExecuteNonQuery();
                    MessageBox.Show("Uspesna akcija", "INFORMACIJA", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
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
