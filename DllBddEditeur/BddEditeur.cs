using System;
using System.Collections.Generic;
using System.Linq;
using BddediteurContext;

namespace DllBddEditeur
{
    public class BddEditeur
    {
        private BddediteurDataContext bdd = null;
        public BddEditeur()
        {
            try
            {
                bdd = new BddediteurDataContext();
            }
            catch
            {
                throw new Exception("problème pour instancier l'attribut bdd");
            }
        }
        public BddEditeur(string serveurIp, string port, string user, string mdp)
        {
            try
            {
                bdd = new BddediteurDataContext("User Id=" + user + ";Password=" + mdp + ";Host=" + serveurIp + ";Port=" + port + ";Database=BddEditeur;Persist Security Info=True");
            }
            catch
            {
                throw;
            }
        }
        public List<Bookauthor> getallAuthors()
        {
            try
            {
                return bdd.Bookauthors.ToList();
            }
            catch { throw; }
        }

        public List<User> getallUsers()
        {
            try
            {
                return bdd.Users.ToList();
            }
            catch { throw; }
        }
        public List<Booklist> getallBooks()
        {
            try
            {
                return bdd.Booklists.ToList();
            }
            catch { throw; }
        }
        public List<Bookprice> GetBookprices()
        {
            try
            {
                return bdd.Bookprices.ToList();
            }
            catch { throw; }
        }
        public bool authorExiste(string isbn)
        {
            try
            {
                Bookauthor aut = bdd.Bookauthors.Where(s => s.ISBN.ToLower() == isbn.ToLower()).FirstOrDefault();
                if (aut != null)
                    return true;
                return false;
            }
            catch { throw; }
        }

        public bool UserExiste(string isbn)
        {
            try
            {
                User us = bdd.Users.Where(s => s.Login.ToLower() == isbn.ToLower()).FirstOrDefault();
                if (us != null)
                    return true;
                return false;
            }
            catch { throw; }
        }

        public bool BookExiste(string isbn)
        {
            try
            {
                Booklist book = bdd.Booklists.Where(s => s.ISBN.ToLower() == isbn.ToLower()).FirstOrDefault();
                if (book != null)
                    return true;
                return false;
            }
            catch { throw; }
        }

        public bool addAuthor(string n, string p, string isb)
        {
            bool Result;
            try
            {
                Bookauthor aut = new Bookauthor();
                aut.FirstName = n;
                aut.LastName = p;
                aut.ISBN = isb;
                bdd.Bookauthors.InsertOnSubmit(aut);
                bdd.SubmitChanges();
                Result = true;
            }
            catch { Result = false; }
            return Result;
        }
        public bool addUser(string n, string p, string lo, string mdp)
        {
            bool Result;
            try
            {
                User u = new User();
                u.Nom = n;
                u.Prenom = p;
                u.Login = lo;
                u.Mdp = mdp;
                bdd.Users.InsertOnSubmit(u);
                bdd.SubmitChanges();
                Result = true;
            }
            catch { Result = false; }
            return Result;
        }
        public bool DeleteUser(string login)
        {
            bool result;
            try
            {
                User utilisateur = bdd.Users.FirstOrDefault(u => u.Login == login);
                if (utilisateur != null)
                {
                    bdd.Users.DeleteOnSubmit(utilisateur);
                    bdd.SubmitChanges();
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch{result = false;}
            return result;
        }
        public bool AddBook(string isb, string titre, DateTime dateP)
        {
            bool Result;
            try
            {
                Booklist livre = new Booklist();
                livre.ISBN = isb;
                livre.Title = titre;
                livre.PublicationDate = dateP;
                bdd.Booklists.InsertOnSubmit(livre);
                Result = true;
            }
            catch { Result = false; }
            return Result;
        }
        public bool DeleteBook(string isbn)
        {
            bool result;
            try
            {
                Booklist livre = bdd.Booklists.FirstOrDefault(b => b.ISBN == isbn);
                if (livre != null)
                {
                    bdd.Booklists.DeleteOnSubmit(livre);
                    bdd.SubmitChanges();
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch{ result = false;}
            return result;
        }
        public List<Booklist> getBooksOfAuthor(String nom, String prenom)
        {
            List<Booklist> listeLivre = new List<Booklist>();
            try
            {
                var res = from auteur in bdd.Bookauthors
                          join livre in bdd.Booklists
                          on auteur.ISBN equals livre.ISBN
                          where auteur.LastName.Equals(nom) && auteur.FirstName.Equals(prenom)
                          select livre;
                foreach (var book in res)
                {
                    listeLivre.Add(book);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Aucun livre trouvé"+ ex.Message);

            }
            return listeLivre;
        }

       
    }
}
