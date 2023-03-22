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
    /// Logique d'interaction pour livre.xaml
    /// </summary>
    public partial class livre : UserControl
    {
        private BddEditeur bdd = null;
        public livre()
        {
            InitializeComponent();
            try
            {
                //bdd = new BddEditeur(Properties.Settings.Default.AdrIpServeur, Properties.Settings.Default.Port, Properties.Settings.Default.Utilisateur, Properties.Settings.Default.Mdp);
                bdd = new BddEditeur("127.0.0.1", "3306", "AdminEditeur", "@Password1234!");
                List<Booklist> listeLivre = bdd.getallBooks();
                bookDataGrid.ItemsSource = listeLivre;




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur lors de la connexion à la Bdd");
            }
        }

        private void getListeLivre(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender is DataGrid)
                {
                    Booklist livreTB = (Booklist)(sender as DataGrid).SelectedItem;
                    if (livreTB != null)
                    {
                        this.isbnBox.Text = livreTB.ISBN;
                        this.titreBox.Text = livreTB.Title;
                        this.dateBox.SelectedDate = livreTB.PublicationDate;
                      
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur lors de selection de personnel");
            }
        }

        private void delBook_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void modifyBook_Click(object sender, RoutedEventArgs e)
        {

        }

        private void addBook_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
