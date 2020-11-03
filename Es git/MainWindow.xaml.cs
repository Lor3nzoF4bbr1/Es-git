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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace Es_git
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CD cd;
        string fileBrani;
        public MainWindow()
        {
            InitializeComponent();

            fileBrani = "";

            LeggiFile();
        }

        public void LeggiFile()
        {
            List<Brano> brani = new List<Brano>();
            string[] elementiCD;

            using (StreamReader file = new StreamReader("CD.txt"))
            {
                string linea = file.ReadLine();

                elementiCD = linea.Split('|');
                fileBrani = elementiCD[2];
            }

            using (StreamReader file = new StreamReader(fileBrani + ".txt")) 
            {
                while (!file.EndOfStream)
                {
                    string linea = file.ReadLine();

                    string[] elementi = linea.Split('|');

                    Brano b = new Brano(elementi[0], elementi[1], double.Parse(elementi[2]));
                    brani.Add(b);
                }
            }

            cd = new CD(brani, elementiCD[0], elementiCD[1]);

            scriviInListbox();
        }

        private void scriviInListbox()
        {
            lstBrani.Items.Clear();

            foreach (Brano b in cd.ListaBraniInCD)
            {
                lstBrani.Items.Add(b.ToString());
            }
        }

        private void btnIns_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            CreazioneBrano cb = new CreazioneBrano(this, fileBrani);
            cb.Show();
        }
    }
}
