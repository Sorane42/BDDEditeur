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
using DllBddEditeur;
using BddediteurContext;

namespace WPFBddEditeur
{
   
    public partial class MainWindow : Window
    {
        private BddEditeur bdd = null;
        private livre livre;
        private AuteurContent auteurContent;
        private UserContent userContent;
        private PrixContent prixContent;
        private LoginContent loginContent;

        public MainWindow()
        {
            InitializeComponent();
            livre = new livre();
            auteurContent = new AuteurContent();
            userContent = new UserContent();
            loginContent = new LoginContent();
            prixContent = new PrixContent();
            try
            {
                bdd = new BddEditeur(Properties.Settings.Default.AdrIpServeur, Properties.Settings.Default.Port, Properties.Settings.Default.Utilisateur, Properties.Settings.Default.Mdp);
                //bdd = new BddEditeur("127.0.0.1", "3306", "AdminEditeur", "@Password1234!");
                
                List<Bookauthor> listeAuteurs = bdd.getallAuthors();

               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur lors de la connexion à la bdd");
                
            }
            mainContent.Content = loginContent;
        }

        

        private void userBt_Click(object sender, RoutedEventArgs e)
        {

            mainContent.Content = userContent;
        }

        private void bookBt_Click(object sender, RoutedEventArgs e)
        {
            mainContent.Content = livre;
        }

        private void authorBt_Click(object sender, RoutedEventArgs e)
        {
            mainContent.Content = auteurContent;
        }

        private void priceBt_Click(object sender, RoutedEventArgs e)
        {
            mainContent.Content = prixContent;
        }

        private void logoutBt_Click(object sender, RoutedEventArgs e)
        {
            this.Close();  
        }

      
    }
}
