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

namespace Es_git
{
    /// <summary>
    /// Logica di interazione per VisualizzaBrani.xaml
    /// </summary>
    public partial class VisualizzaBrani : Window
    {
        Brano brano;
        public VisualizzaBrani(Brano b)
        {
            InitializeComponent();

            brano = b;

            lblTitolo.Content = brano.Titolo;
            lblAutore.Content = brano.Autore;
            lblDurata.Content = brano.Durata;
        }

        private void btnRitorna_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mw = new MainWindow();
            mw.Show();
        }

        private void btnConfronto_Click(object sender, RoutedEventArgs e)
        {
            if (brano.shortSong(double.Parse(txtConfrontoDurata.Text)) == true) 
            {
                MessageBox.Show("La durata inserita è maggiore della durata del disco");
            }
            else
            {
                MessageBox.Show("La durata inserita è minore (o uguale) della durata del disco");
            }
        }
    }
}
