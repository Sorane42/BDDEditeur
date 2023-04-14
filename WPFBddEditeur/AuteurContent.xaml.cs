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
    /// Logique d'interaction pour AuteurContent.xaml
    /// </summary>
    public partial class AuteurContent : UserControl
    {
        private BddEditeur bdd = null;
        
        public AuteurContent()
        {
            InitializeComponent();

            try
            {
                bdd = new BddEditeur(Properties.Settings.Default.AdrIpServeur, Properties.Settings.Default.Port, Properties.Settings.Default.Utilisateur, Properties.Settings.Default.Mdp);
                //bdd = new BddEditeur("127.0.0.1", "3306", "AdminEditeur", "@Password1234!");
                List<Bookauthor> listeAuteurs = bdd.getallAuthors();
                auteurDataGrid.ItemsSource = listeAuteurs;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur lors de la connexion à la Bdd");
            }
        }

        private void getListeAuteur(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender is DataGrid)
                {
                    Bookauthor auteur = (Bookauthor)(sender as DataGrid).SelectedItem;
                    if (auteur != null)
                    {
                        this.nomBox.Text = auteur.FirstName;
                        this.prenomBox.Text = auteur.LastName;
                        this.isbnBox.Text = auteur.ISBN;
                        List<Booklist> listeLivre = bdd.getBooksOfAuthor(auteur.LastName, auteur.FirstName);
                        livreDataGrid.ItemsSource = listeLivre;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur lors de la selection");
            }
        }

        private void addAuthor_Click(object sender, RoutedEventArgs e)
        {
            addAuthor addAuthor = new addAuthor();
            addAuthor.Closed += AddAuthor_Closed;
            addAuthor.Show();
        }

        private void AddAuthor_Closed(object sender, EventArgs e)
        {
            List<Bookauthor> listeAuthor = bdd.getallAuthors();
            auteurDataGrid.ItemsSource = listeAuthor;
        }
    }
}
