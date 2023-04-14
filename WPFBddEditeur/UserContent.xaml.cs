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
    /// Logique d'interaction pour UserContent.xaml
    /// </summary>
    public partial class UserContent : UserControl
    {
        private BddEditeur bdd = null;
        public UserContent()
        {
            
            InitializeComponent();

            try
            {
                bdd = new BddEditeur(Properties.Settings.Default.AdrIpServeur, Properties.Settings.Default.Port, Properties.Settings.Default.Utilisateur, Properties.Settings.Default.Mdp);
                //bdd = new BddEditeur("127.0.0.1", "3306", "AdminEditeur", "@Password1234!");
                List<User> listerUsers = bdd.getallUsers();
                userDataGrid.ItemsSource = listerUsers;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur lors de la connexion à la Bdd");
            }
        }

     

        private void addUser_Click(object sender, RoutedEventArgs e)
        {
            addUser addUser = new addUser();
            addUser.Closed += AddUser_Closed;
            addUser.Show();
            
        }
        private void modifyUser_Click(object sender, RoutedEventArgs e)
        {
            modifyUser modifyUser = new modifyUser();
            modifyUser.Closed += AddUser_Closed;
            
            modifyUser.Show();
            
        }
        private void AddUser_Closed(object sender, EventArgs e)
        {
            List<User> listerUsers = bdd.getallUsers();
            userDataGrid.ItemsSource = listerUsers;
        }

        private void delUser_Click(object sender, RoutedEventArgs e)
        {
            User userToDel = (User)userDataGrid.SelectedItem;
            if (userToDel != null)
            {
                string login = userToDel.Login;
                bool result = bdd.DeleteUser(login);
                if (result)
                {
                    MessageBox.Show("L'utilisateur a été supprimé avec succès.");
                }
                else
                {
                    MessageBox.Show("Une erreur est survenue lors de la suppression de l'utilisateur.");
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un utilisateur à supprimer.");
            }
            List<User> listerUsers = bdd.getallUsers();
            userDataGrid.ItemsSource = listerUsers;
        }

        
    }
}
