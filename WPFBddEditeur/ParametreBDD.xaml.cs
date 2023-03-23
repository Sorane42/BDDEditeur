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
using DllBddEditeur;
using BddediteurContext;
using WpfAppEditeur;

namespace WPFBddEditeur
{
    /// <summary>
    /// Logique d'interaction pour ParametreBDD.xaml
    /// </summary>
    public partial class ParametreBDD : Window
    {
        private BddEditeur bdd = null;
        public ParametreBDD()
        {
            InitializeComponent();
            try
            {
                //bdd = new BddEditeur(Properties.Settings.Default.AdrIpServeur, Properties.Settings.Default.Port, Properties.Settings.Default.Utilisateur, Properties.Settings.Default.Mdp);
                bdd = new BddEditeur("127.0.0.1", "3306", "AdminEditeur", "@Password1234!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur lors de la connexion à la Bddd");
            }
        }

        private void enregiBt_Click(object sender, RoutedEventArgs e)
        {
            if (!CValidateByRegex.IsAdressIpv4(this.ipServer.Text))
            {
                MessageBox.Show("Adresse IP invalide", "Erreur d'adresse Ipv4");
                return;
            }
            if (!CValidateByRegex.IsPortNumber(this.port.Text))
            {
                MessageBox.Show("Port invalide", "Erreur de port");
                return;
            }
            this.DialogResult = true;
            this.Close();
        }

        private void returnBt_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
