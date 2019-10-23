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
    /// Interaction logic for wndStudentPredmet.xaml
    /// </summary>
    public partial class wndStudentPredmet : Window
    {
        string konekcioniString;
        SqlConnection konekcija;
        SqlCommand komanda;

        public wndStudentPredmet()
        {
            InitializeComponent();
            konekcioniString = ConfigurationManager.ConnectionStrings["EntityDBCodeFirstContext"].ConnectionString;
            OsveziEkran();
        }

        private void OsveziEkran()
        {
            using (konekcija = new SqlConnection(konekcioniString))
            {
                komanda = new SqlCommand("SELECT * FROM StudentPredmet", konekcija);

                SqlDataAdapter da = new SqlDataAdapter(komanda);
                DataTable tabela = new DataTable();
                da.Fill(tabela);
                grdStudentPredmet.ItemsSource = tabela.DefaultView;
            }
        }

        private void btnUnos_Click(object sender, RoutedEventArgs e)
        {
            using (konekcija = new SqlConnection(konekcioniString))
            {
                komanda = new SqlCommand("INSERT INTO StudentPredmet VALUES(@studentid,@predmetid)", konekcija);

                komanda.Parameters.Add("@studentid", SqlDbType.Int).Value = txtStudentID.Text;
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

        private void btnIzmena_Click(object sender, RoutedEventArgs e)
        {
            using (konekcija = new SqlConnection(konekcioniString))
            {
                komanda = new SqlCommand("UPDATE StudentPredmet SET Student_StudentID = @studentid, Predmet_PredmetID = @predmetid WHERE Student_StudentID = @studentid AND Predmet_PredmetID = @predmetid", konekcija);

                komanda.Parameters.Add("@studentid", SqlDbType.Int).Value = txtStudentID.Text;
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

        private void btnBrisanje_Click(object sender, RoutedEventArgs e)
        {
            using (konekcija = new SqlConnection(konekcioniString))
            {
                komanda = new SqlCommand("DELETE StudentPredmet WHERE Student_StudentID = @studentid AND Predmet_PredmetID = @predmetid", konekcija);

                komanda.Parameters.Add("@studentid", SqlDbType.Int).Value = txtStudentID.Text;
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
