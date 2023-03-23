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
    /// <summary>
    /// Logique d'interaction pour LoginContent.xaml
    /// </summary>
    public partial class LoginContent : UserControl
    {
        private BddEditeur bdd = null;
        public LoginContent()
        {
            InitializeComponent();
            try
            {
                bdd = new BddEditeur(Properties.Settings.Default.AdrIpServeur, Properties.Settings.Default.Port, Properties.Settings.Default.Utilisateur, Properties.Settings.Default.Mdp);
                //bdd = new BddEditeur("127.0.0.1", "3306", "AdminEditeur", "@Password1234!");
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur lors de la connexion à la Bddd");
            }
        }

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

                /*if (username == "votre_identifiant" && password == "votre_mot_de_passe")
                    if(permission = 1)
                    {
                        MessageBox.Show("Bienvenue Gestionnaire");
                    }
                    if(permission = 0)
                    {
                    MessageBox.Show("Bienvenue Employé");
                    }
                    */


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Login incorrect");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ParametreBDD parametre = new ParametreBDD();
            parametre.Show();
           
          
   
            }
        }
    }
}
