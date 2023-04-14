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
    public partial class LoginContent : UserControl
    {
        private BddEditeur bdd = null;
        private AuteurContent auteurContent;
        

        public LoginContent()
        {
            InitializeComponent();
            auteurContent = new AuteurContent();
        

            bdd = new BddEditeur(Properties.Settings.Default.AdrIpServeur, Properties.Settings.Default.Port, Properties.Settings.Default.Utilisateur, Properties.Settings.Default.Mdp);
            //bdd = new BddEditeur("127.0.0.1", "3306", "AdminEditeur", "@Password1234!");



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
                List<User> users = bdd.getallUsers();
                foreach (User us in users)
                {
                    if (loginText.Text == us.Login && mdpText.Password == us.Mdp)
                    {
                        //mainWindow.mainContent.Content = auteurContent;
                    }
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Login incorrect");
            }

        }
    
    }
}
