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
    /// Logique d'interaction pour addAuthor.xaml
    /// </summary>
    public partial class addAuthor : Window
    {
        private BddEditeur bdd = null;
        public addAuthor()
        {
            InitializeComponent();
            try
            {
                //bdd = new BddEditeur(Properties.Settings.Default.AdrIpServeur, Properties.Settings.Default.Port, Properties.Settings.Default.Utilisateur, Properties.Settings.Default.Mdp);
                bdd = new BddEditeur("127.0.0.1", "3306", "AdminEditeur", "@Password1234!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur lors de la connexion à la Bdd");
            }
        }

      
        private void addBt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(firstNameTb.Text == "" || lastNameTb.Text == "" || isbnTb.Text == "")
                {
                    MessageBox.Show("Tous les champs doivent être remplis");
                    return;
                }
                if(bdd.authorExiste(isbnTb.Text) == true)
                {
                    MessageBox.Show("L'auteur existe déjà");
                    return;
                }
                if (bdd.addAuthor(firstNameTb.Text,lastNameTb.Text,isbnTb.Text))
                {
                    MessageBox.Show("Ajout réussi");
                    this.Close();
                }
            } catch (Exception ex){
                MessageBox.Show(ex.Message, "Erreur lors de l'ajout");
            }
        }

        private void cancelBt_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
    }
}
