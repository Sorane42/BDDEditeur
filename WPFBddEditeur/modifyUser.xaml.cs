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
    /// Logique d'interaction pour modifyUser.xaml
    /// </summary>
    public partial class modifyUser : Window
    {
        private BddEditeur bdd = null;
        private string originalLogin = "";
        public modifyUser()
        {
            InitializeComponent();
            try
            {
                bdd = new BddEditeur(Properties.Settings.Default.AdrIpServeur, Properties.Settings.Default.Port, Properties.Settings.Default.Utilisateur, Properties.Settings.Default.Mdp);
                //bdd = new BddEditeur("127.0.0.1", "3306", "AdminEditeur", "@Password1234!");
                List<User> listerUsers = bdd.getallUsers();
                userBDataGrid.ItemsSource = listerUsers;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur lors de la connexion à la Bdd");
            }
        }

        private void getListeUser(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender is DataGrid)
                {
                    User us = (User)(sender as DataGrid).SelectedItem;
                    if (us != null)
                    {
                        this.fNameTb.Text = us.Nom;
                        this.lNameTb.Text = us.Prenom;
                        this.loginTb.Text = us.Login;
                        this.originalLogin = us.Login;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur lors de la selection");
            }
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void modify_Button_Click(object sender, RoutedEventArgs e)
        {
           
            try
            {
                if (fNameTb.Text == "" || lNameTb.Text == "" || loginTb.Text == "")
                {
                    MessageBox.Show("Tous les champs doivent être remplis");
                    return;
                }
                
                if (bdd.UserExiste(loginTb.Text) == true && loginTb.Text != originalLogin)
                {
                    MessageBox.Show("Ce login est déjà utilisé");
                    return;
                }
                if (bdd.ModifyUser(originalLogin, fNameTb.Text, lNameTb.Text, loginTb.Text))
                {
                    bdd = new BddEditeur("127.0.0.1", "3306", "AdminEditeur", "@Password1234!");
                    List<User> listerUsers = bdd.getallUsers();
                    userBDataGrid.ItemsSource = listerUsers;
                   
                    MessageBox.Show("Modification réussie");
                    this.Close();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur lors de l'ajout");
            }
        }
    }
}
 
