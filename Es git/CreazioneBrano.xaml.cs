using System;
using System.Collections.Generic;
using System.IO.Packaging;
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
using System.IO;

namespace Es_git
{
    /// <summary>
    /// Logica di interazione per CreazioneBrano.xaml
    /// </summary>
    public partial class CreazioneBrano : Window
    {
        MainWindow main;
        string fileBrani;
        public CreazioneBrano(MainWindow window, string file)
        {
            InitializeComponent();

            main = window;
            fileBrani = file;
        }

        private void btnCrea_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fileBrani + ".txt", true))
                {
                    string titolo = txtTitolo.Text;
                    string autore = txtAutore.Text;
                    double durata = double.Parse(txtDurata.Text);

                    sw.WriteLine(titolo + "|" + autore + "|" + durata);
                }

                main.LeggiFile();

                this.Hide();
                main.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
