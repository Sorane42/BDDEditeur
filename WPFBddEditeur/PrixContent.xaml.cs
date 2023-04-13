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
    /// Logique d'interaction pour prixContent.xaml
    /// </summary>
    public partial class PrixContent : UserControl
    {
        private BddEditeur bdd = null;
        public PrixContent()
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

        private void bookDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
