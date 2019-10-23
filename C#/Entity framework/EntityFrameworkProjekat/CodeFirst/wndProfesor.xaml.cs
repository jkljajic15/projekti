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

namespace CodeFirst
{
    /// <summary>
    /// Interaction logic for wndProfesor.xaml
    /// </summary>
    public partial class wndProfesor : Window
    {
        string konekcioniString;
        SqlConnection konekcija;
        SqlCommand komanda;

        public wndProfesor()
        {
            InitializeComponent();
            konekcioniString = ConfigurationManager.ConnectionStrings["EntityDBCodeFirstContext"].ConnectionString;
            OsveziEkran();
        }

        private void OsveziEkran()
        {
            using (konekcija = new SqlConnection(konekcioniString))
            {
                komanda = new SqlCommand("SELECT * FROM Profesor", konekcija);

                SqlDataAdapter da = new SqlDataAdapter(komanda);
                DataTable tabela = new DataTable();
                da.Fill(tabela);
                grdProfesor.ItemsSource = tabela.DefaultView;
            }
        }

        private void btnUnos_Click(object sender, RoutedEventArgs e)
        {
            using (konekcija = new SqlConnection(konekcioniString))
            {
                komanda = new SqlCommand("INSERT INTO Profesor VALUES(@profesorid,@ime)", konekcija);

                komanda.Parameters.Add("@profesorid", SqlDbType.Int).Value = txtProfesorID.Text;
                komanda.Parameters.Add("@ime", SqlDbType.NVarChar).Value = txtIme.Text;

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

        private void btnIzmena_Click(object sender, RoutedEventArgs e)
        {
            using (konekcija = new SqlConnection(konekcioniString))
            {
                komanda = new SqlCommand("UPDATE Profesor SET Ime = @ime WHERE ProfesorID = @profesorid", konekcija);

                komanda.Parameters.Add("@profesorid", SqlDbType.Int).Value = txtProfesorID.Text;
                komanda.Parameters.Add("@ime", SqlDbType.NVarChar).Value = txtIme.Text;

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

        private void btnBrisanje_Click(object sender, RoutedEventArgs e)
        {
            using (konekcija = new SqlConnection(konekcioniString))
            {
                komanda = new SqlCommand("DELETE Profesor WHERE ProfesorID = @profesorid", konekcija);

                komanda.Parameters.Add("@profesorid", SqlDbType.Int).Value = txtProfesorID.Text;

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
