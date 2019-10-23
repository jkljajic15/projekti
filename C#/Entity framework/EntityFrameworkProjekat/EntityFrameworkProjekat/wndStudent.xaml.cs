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
    /// Interaction logic for wndStudent.xaml
    /// </summary>
    public partial class wndStudent : Window
    {
        string konekcioniString;
        SqlConnection konekcija;
        SqlCommand komanda;

        public wndStudent()
        {
            InitializeComponent();
            konekcioniString = ConfigurationManager.ConnectionStrings["konfiguracijaKonekcije"].ConnectionString;
            OsveziEkran();
        }

        private void OsveziEkran()
        {
            using (konekcija = new SqlConnection(konekcioniString))
            {
                komanda = new SqlCommand("SELECT * FROM Student", konekcija);

                SqlDataAdapter da = new SqlDataAdapter(komanda);
                DataTable tabela = new DataTable();
                da.Fill(tabela);
                grdStudent.ItemsSource = tabela.DefaultView;



            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (konekcija = new SqlConnection(konekcioniString))
            {
                komanda = new SqlCommand("INSERT INTO Student VALUES(@studentid,@ime,@prezime,@smerid)", konekcija);

                komanda.Parameters.Add("@studentid", SqlDbType.Int).Value = txtStudentID.Text;
                komanda.Parameters.Add("@ime", SqlDbType.NVarChar).Value = txtIme.Text;
                komanda.Parameters.Add("@prezime", SqlDbType.NVarChar).Value = txtPrezime.Text;
                komanda.Parameters.Add("@smerid", SqlDbType.Int).Value = txtSmerID.Text;

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
                komanda = new SqlCommand("UPDATE Student SET Ime = @ime, Prezime = @prezime, SmerId = @smerid WHERE StudentID = @studentid", konekcija);

                komanda.Parameters.Add("@studentid", SqlDbType.Int).Value = txtStudentID.Text;
                komanda.Parameters.Add("@ime", SqlDbType.NVarChar).Value = txtIme.Text;
                komanda.Parameters.Add("@prezime", SqlDbType.NVarChar).Value = txtPrezime.Text;
                komanda.Parameters.Add("@smerid", SqlDbType.Int).Value = txtSmerID.Text;

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
                komanda = new SqlCommand("DELETE Student WHERE StudentID = @studentid", konekcija);

                komanda.Parameters.Add("@studentid", SqlDbType.Int).Value = txtStudentID.Text;

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
