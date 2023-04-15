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
       
        private Login login;
        private string _username;
        private string _password;
        public MainWindow(string username, string password)
        {
            InitializeComponent();
            livre = new livre();
            auteurContent = new AuteurContent();
            userContent = new UserContent();
           
            prixContent = new PrixContent();
            login = new Login();
            try
            {
                bdd = new BddEditeur(Properties.Settings.Default.AdrIpServeur, Properties.Settings.Default.Port, Properties.Settings.Default.Utilisateur, Properties.Settings.Default.Mdp);
                //bdd = new BddEditeur("127.0.0.1", "3306", "AdminEditeur", "@Password1234!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur lors de la connexion à la bdd");
                
            }
            mainContent.Content = auteurContent;

            _username = username;
            _password = password;
            
            if (!bdd.GetPermission(_username, _password))
            {
                
                userBt.ToolTip = "Vous n'avez pas la permission d'accéder à cet écran";
                userBt.IsEnabled = false;
                
            }

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
            Login login = new Login();
            login.Show();
            this.Close();
        }

      
    }
}
