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

namespace WPFBddEditeur
{
    /// <summary>
    /// Logique d'interaction pour Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private BddEditeur bdd = null;
        private AuteurContent auteurContent;
        
        
        public Login()
        {
            
            InitializeComponent();
            auteurContent = new AuteurContent();


            bdd = new BddEditeur(Properties.Settings.Default.AdrIpServeur, Properties.Settings.Default.Port, Properties.Settings.Default.Utilisateur, Properties.Settings.Default.Mdp);
            //bdd = new BddEditeur("127.0.0.1", "3306", "AdminEditeur", "@Password1234!");

        }

        public string Username { get; set; }
        public string Password { get; set; }

        private void connectBt_Click(object sender, RoutedEventArgs e)
        {
            string username = loginText.Text;
            string password = mdpText.Password;
            try
            {
                if (loginText.Text == "")
                    throw new Exception("Saisir un login");
                if (mdpText.Password == "")
                    throw new Exception("Saisir un mot de passe");
                List<User> users = bdd.getallUsers();
                foreach (User us in users)
                {
                    if (loginText.Text == us.Login && mdpText.Password == us.Mdp)
                    {
                        Username = loginText.Text;
                        Password = mdpText.Password;
                        MainWindow mainWindow = new MainWindow(loginText.Text, mdpText.Password);
                        mainWindow.Show();
                        this.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Login incorrect");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
