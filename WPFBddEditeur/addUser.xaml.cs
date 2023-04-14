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
    /// Logique d'interaction pour addUser.xaml
    /// </summary>
    public partial class addUser : Window
    {
        private BddEditeur bdd = null;
        public addUser()
        {
            InitializeComponent();
            bdd = new BddEditeur("127.0.0.1", "3306", "AdminEditeur", "@Password1234!");
        }

        private void addBt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (firstNameTb.Text == "" || lastNameTb.Text == "" || loginTb.Text == "" || mdpTb.Text == "")
                {
                    MessageBox.Show("Tous les champs doivent être remplis");
                    return;
                }
                if (bdd.UserExiste(loginTb.Text) == true)
                {
                    MessageBox.Show("Cet utilisateur existe déjà");
                    return;
                }
                if (bdd.addUser(firstNameTb.Text, lastNameTb.Text, loginTb.Text, mdpTb.Text))
                {
                    bdd = new BddEditeur("127.0.0.1", "3306", "AdminEditeur", "@Password1234!");
                    MessageBox.Show("Ajout réussi");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur lors de l'ajout");
            }
        }

        private void cancelBt_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
