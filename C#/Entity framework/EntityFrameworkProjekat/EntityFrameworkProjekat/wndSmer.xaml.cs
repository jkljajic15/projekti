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
    /// Interaction logic for wndSmer.xaml
    /// </summary>
    public partial class wndSmer : Window
    {
        string konekcioniString;
        SqlConnection konekcija;
        SqlCommand komanda;

        public wndSmer()
        {
            InitializeComponent();
            konekcioniString = ConfigurationManager.ConnectionStrings["konfiguracijaKonekcije"].ConnectionString;
            OsveziEkran();
        }

        private void OsveziEkran()
        {
            using (konekcija = new SqlConnection(konekcioniString))
            {
                komanda = new SqlCommand("SELECT * FROM Smer", konekcija);

                SqlDataAdapter da = new SqlDataAdapter(komanda);
                DataTable tabela = new DataTable();
                da.Fill(tabela);
                grdSmer.ItemsSource = tabela.DefaultView;
                

                
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (konekcija = new SqlConnection(konekcioniString))
            {
                komanda = new SqlCommand("INSERT INTO Smer VALUES(@smerid,@nazivsmera)",konekcija);

                komanda.Parameters.Add("@smerid", SqlDbType.Int).Value = txtSmer.Text;
                komanda.Parameters.Add("@nazivsmera", SqlDbType.NVarChar).Value = txtNazivSmera.Text;

                try
                {
                    konekcija.Open();
                    komanda.ExecuteNonQuery();
                    MessageBox.Show("Uspesna akcija", "INFORMACIJA", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch(Exception ex)
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
                komanda = new SqlCommand("UPDATE Smer SET NazivSmera = @nazivsmera WHERE SmerID = @smerid", konekcija);

                komanda.Parameters.Add("@smerid", SqlDbType.Int).Value = txtSmer.Text;
                komanda.Parameters.Add("@nazivsmera", SqlDbType.NVarChar).Value = txtNazivSmera.Text;

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
                komanda = new SqlCommand("DELETE Smer WHERE SmerID = @smerid", konekcija);

                komanda.Parameters.Add("@smerid", SqlDbType.Int).Value = txtSmer.Text;

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
