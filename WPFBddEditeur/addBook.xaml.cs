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
    /// Logique d'interaction pour addBook.xaml
    /// </summary>
    public partial class addBook : Window
    {
        private BddEditeur bdd = null;
        public addBook()
        {
            InitializeComponent();
            bdd = new BddEditeur("127.0.0.1", "3306", "AdminEditeur", "@Password1234!");
        }

        private void cancelBt_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void addBt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (titleTb.Text == "" || dateTb.Text == "" || isbnBTb.Text == "")
                {
                    MessageBox.Show("Tous les champs doivent être remplis");
                    return;
                }
                if (bdd.BookExiste(isbnBTb.Text) == true)
                {
                    MessageBox.Show("Le livre existe déjà");
                    return;
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur lors de l'ajout");
            }
        }
    
    }
}
