﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using LinqConnect template.
// Code is generated on: 09/03/2023 08:28:38
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using Devart.Data.Linq;
using Devart.Data.Linq.Mapping;
using System.Data;
using System.ComponentModel;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Extensions.Configuration;

namespace BddediteurContext
{

    [DatabaseAttribute(Name = "bddediteur")]
    [ProviderAttribute(typeof(Devart.Data.MySql.Linq.Provider.MySqlDataProvider))]
    public partial class BddediteurDataContext : Devart.Data.Linq.DataContext
    {
        public static CompiledQueryCache compiledQueryCache = CompiledQueryCache.RegisterDataContext(typeof(BddediteurDataContext));
        private static MappingSource mappingSource = new Devart.Data.Linq.Mapping.AttributeMappingSource();

        #region Extensibility Method Definitions
    
        partial void OnCreated();
        partial void OnSubmitError(Devart.Data.Linq.SubmitErrorEventArgs args);
        partial void InsertBookauthor(Bookauthor instance);
        partial void UpdateBookauthor(Bookauthor instance);
        partial void DeleteBookauthor(Bookauthor instance);
        partial void InsertBooklist(Booklist instance);
        partial void UpdateBooklist(Booklist instance);
        partial void DeleteBooklist(Booklist instance);
        partial void InsertBookprice(Bookprice instance);
        partial void UpdateBookprice(Bookprice instance);
        partial void DeleteBookprice(Bookprice instance);
        partial void InsertUser(User instance);
        partial void UpdateUser(User instance);
        partial void DeleteUser(User instance);

        #endregion

        public BddediteurDataContext() :
        base(GetConnectionString("BddediteurDataContextConnectionString"), mappingSource)
        {
            OnCreated();
        }

        public BddediteurDataContext(MappingSource mappingSource) :
        base(GetConnectionString("BddediteurDataContextConnectionString"), mappingSource)
        {
            OnCreated();
        }

        private static string GetConnectionString(string connectionStringName)
        {
            var configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: false);
            var configuration = configurationBuilder.Build();
            return configuration.GetConnectionString(connectionStringName);
        }

        public BddediteurDataContext(string connection) :
            base(connection, mappingSource)
        {
          OnCreated();
        }

        public BddediteurDataContext(System.Data.IDbConnection connection) :
            base(connection, mappingSource)
        {
          OnCreated();
        }

        public BddediteurDataContext(string connection, MappingSource mappingSource) :
            base(connection, mappingSource)
        {
          OnCreated();
        }

        public BddediteurDataContext(System.Data.IDbConnection connection, MappingSource mappingSource) :
            base(connection, mappingSource)
        {
          OnCreated();
        }

        public Devart.Data.Linq.Table<Bookauthor> Bookauthors
        {
            get
            {
                return this.GetTable<Bookauthor>();
            }
        }

        public Devart.Data.Linq.Table<Booklist> Booklists
        {
            get
            {
                return this.GetTable<Booklist>();
            }
        }

        public Devart.Data.Linq.Table<Bookprice> Bookprices
        {
            get
            {
                return this.GetTable<Bookprice>();
            }
        }

        public Devart.Data.Linq.Table<User> Users
        {
            get
            {
                return this.GetTable<User>();
            }
        }
    }
}

namespace BddediteurContext
{

    /// <summary>
    /// There are no comments for BddediteurContext.Bookauthor in the schema.
    /// </summary>
    [Table(Name = @"bddediteur.bookauthors")]
    public partial class Bookauthor : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(System.String.Empty);
        #pragma warning disable 0649

        private string _ISBN;

        private string _FirstName;

        private string _LastName;
        #pragma warning restore 0649

        #region Extensibility Method Definitions

        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
        partial void OnCreated();
        partial void OnISBNChanging(string value);
        partial void OnISBNChanged();
        partial void OnFirstNameChanging(string value);
        partial void OnFirstNameChanged();
        partial void OnLastNameChanging(string value);
        partial void OnLastNameChanged();
        #endregion

        public Bookauthor()
        {
            OnCreated();
        }

    
        /// <summary>
        /// There are no comments for ISBN in the schema.
        /// </summary>
        [Column(Storage = "_ISBN", CanBeNull = false, DbType = "VARCHAR(10) NOT NULL", IsPrimaryKey = true)]
        public string ISBN
        {
            get
            {
                return this._ISBN;
            }
            set
            {
                if (this._ISBN != value)
                {
                    this.OnISBNChanging(value);
                    this.SendPropertyChanging("ISBN");
                    this._ISBN = value;
                    this.SendPropertyChanged("ISBN");
                    this.OnISBNChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for FirstName in the schema.
        /// </summary>
        [Column(Storage = "_FirstName", DbType = "VARCHAR(50) NULL", UpdateCheck = UpdateCheck.Never)]
        public string FirstName
        {
            get
            {
                return this._FirstName;
            }
            set
            {
                if (this._FirstName != value)
                {
                    this.OnFirstNameChanging(value);
                    this.SendPropertyChanging("FirstName");
                    this._FirstName = value;
                    this.SendPropertyChanged("FirstName");
                    this.OnFirstNameChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for LastName in the schema.
        /// </summary>
        [Column(Storage = "_LastName", DbType = "VARCHAR(50) NULL", UpdateCheck = UpdateCheck.Never)]
        public string LastName
        {
            get
            {
                return this._LastName;
            }
            set
            {
                if (this._LastName != value)
                {
                    this.OnLastNameChanging(value);
                    this.SendPropertyChanging("LastName");
                    this._LastName = value;
                    this.SendPropertyChanged("LastName");
                    this.OnLastNameChanged();
                }
            }
        }
   
        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            var handler = this.PropertyChanging;
            if (handler != null)
                handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanging(System.String propertyName) 
        {
            var handler = this.PropertyChanging;
            if (handler != null)
                handler(this, new PropertyChangingEventArgs(propertyName));
        }

        protected virtual void SendPropertyChanged(System.String propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    /// <summary>
    /// There are no comments for BddediteurContext.Booklist in the schema.
    /// </summary>
    [Table(Name = @"bddediteur.booklist")]
    public partial class Booklist : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(System.String.Empty);
        #pragma warning disable 0649

        private string _ISBN;

        private string _Title;

        private System.DateTime? _PublicationDate;
        #pragma warning restore 0649

        #region Extensibility Method Definitions

        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
        partial void OnCreated();
        partial void OnISBNChanging(string value);
        partial void OnISBNChanged();
        partial void OnTitleChanging(string value);
        partial void OnTitleChanged();
        partial void OnPublicationDateChanging(System.DateTime? value);
        partial void OnPublicationDateChanged();
        #endregion

        public Booklist()
        {
            OnCreated();
        }

    
        /// <summary>
        /// There are no comments for ISBN in the schema.
        /// </summary>
        [Column(Storage = "_ISBN", CanBeNull = false, DbType = "VARCHAR(10) NOT NULL", IsPrimaryKey = true)]
        public string ISBN
        {
            get
            {
                return this._ISBN;
            }
            set
            {
                if (this._ISBN != value)
                {
                    this.OnISBNChanging(value);
                    this.SendPropertyChanging("ISBN");
                    this._ISBN = value;
                    this.SendPropertyChanged("ISBN");
                    this.OnISBNChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Title in the schema.
        /// </summary>
        [Column(Storage = "_Title", CanBeNull = false, DbType = "VARCHAR(255) NOT NULL", UpdateCheck = UpdateCheck.Never)]
        public string Title
        {
            get
            {
                return this._Title;
            }
            set
            {
                if (this._Title != value)
                {
                    this.OnTitleChanging(value);
                    this.SendPropertyChanging("Title");
                    this._Title = value;
                    this.SendPropertyChanged("Title");
                    this.OnTitleChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for PublicationDate in the schema.
        /// </summary>
        [Column(Storage = "_PublicationDate", DbType = "DATETIME NULL", UpdateCheck = UpdateCheck.Never)]
        public System.DateTime? PublicationDate
        {
            get
            {
                return this._PublicationDate;
            }
            set
            {
                if (this._PublicationDate != value)
                {
                    this.OnPublicationDateChanging(value);
                    this.SendPropertyChanging("PublicationDate");
                    this._PublicationDate = value;
                    this.SendPropertyChanged("PublicationDate");
                    this.OnPublicationDateChanged();
                }
            }
        }
   
        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            var handler = this.PropertyChanging;
            if (handler != null)
                handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanging(System.String propertyName) 
        {
            var handler = this.PropertyChanging;
            if (handler != null)
                handler(this, new PropertyChangingEventArgs(propertyName));
        }

        protected virtual void SendPropertyChanged(System.String propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    /// <summary>
    /// There are no comments for BddediteurContext.Bookprice in the schema.
    /// </summary>
    [Table(Name = @"bddediteur.bookprices")]
    public partial class Bookprice : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(System.String.Empty);
        #pragma warning disable 0649

        private string _ISBN;

        private string _Currency;

        private decimal? _Price;
        #pragma warning restore 0649

        #region Extensibility Method Definitions

        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
        partial void OnCreated();
        partial void OnISBNChanging(string value);
        partial void OnISBNChanged();
        partial void OnCurrencyChanging(string value);
        partial void OnCurrencyChanged();
        partial void OnPriceChanging(decimal? value);
        partial void OnPriceChanged();
        #endregion

        public Bookprice()
        {
            OnCreated();
        }

    
        /// <summary>
        /// There are no comments for ISBN in the schema.
        /// </summary>
        [Column(Storage = "_ISBN", CanBeNull = false, DbType = "VARCHAR(10) NOT NULL", IsPrimaryKey = true)]
        public string ISBN
        {
            get
            {
                return this._ISBN;
            }
            set
            {
                if (this._ISBN != value)
                {
                    this.OnISBNChanging(value);
                    this.SendPropertyChanging("ISBN");
                    this._ISBN = value;
                    this.SendPropertyChanged("ISBN");
                    this.OnISBNChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Currency in the schema.
        /// </summary>
        [Column(Storage = "_Currency", CanBeNull = false, DbType = "VARCHAR(3) NOT NULL", IsPrimaryKey = true)]
        public string Currency
        {
            get
            {
                return this._Currency;
            }
            set
            {
                if (this._Currency != value)
                {
                    this.OnCurrencyChanging(value);
                    this.SendPropertyChanging("Currency");
                    this._Currency = value;
                    this.SendPropertyChanged("Currency");
                    this.OnCurrencyChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Price in the schema.
        /// </summary>
        [Column(Storage = "_Price", DbType = "DECIMAL(5,2) NULL", UpdateCheck = UpdateCheck.Never)]
        public decimal? Price
        {
            get
            {
                return this._Price;
            }
            set
            {
                if (this._Price != value)
                {
                    this.OnPriceChanging(value);
                    this.SendPropertyChanging("Price");
                    this._Price = value;
                    this.SendPropertyChanged("Price");
                    this.OnPriceChanged();
                }
            }
        }
   
        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            var handler = this.PropertyChanging;
            if (handler != null)
                handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanging(System.String propertyName) 
        {
            var handler = this.PropertyChanging;
            if (handler != null)
                handler(this, new PropertyChangingEventArgs(propertyName));
        }

        protected virtual void SendPropertyChanged(System.String propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    /// <summary>
    /// There are no comments for BddediteurContext.User in the schema.
    /// </summary>
    [Table(Name = @"bddediteur.users")]
    public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(System.String.Empty);
        #pragma warning disable 0649

        private int _Id;

        private string _Nom;

        private string _Prenom;

        private string _Login;

        private string _Mdp;

        private bool _Autorisation;
        #pragma warning restore 0649

        #region Extensibility Method Definitions

        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
        partial void OnCreated();
        partial void OnIdChanging(int value);
        partial void OnIdChanged();
        partial void OnNomChanging(string value);
        partial void OnNomChanged();
        partial void OnPrenomChanging(string value);
        partial void OnPrenomChanged();
        partial void OnLoginChanging(string value);
        partial void OnLoginChanged();
        partial void OnMdpChanging(string value);
        partial void OnMdpChanged();
        partial void OnAutorisationChanging(bool value);
        partial void OnAutorisationChanged();
        #endregion

        public User()
        {
            OnCreated();
        }

    
        /// <summary>
        /// There are no comments for Id in the schema.
        /// </summary>
        [Column(Storage = "_Id", AutoSync = AutoSync.OnInsert, CanBeNull = false, DbType = "SMALLINT(5) UNSIGNED NOT NULL AUTO_INCREMENT", IsDbGenerated = true, IsPrimaryKey = true)]
        public int Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                if (this._Id != value)
                {
                    this.OnIdChanging(value);
                    this.SendPropertyChanging("Id");
                    this._Id = value;
                    this.SendPropertyChanged("Id");
                    this.OnIdChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Nom in the schema.
        /// </summary>
        [Column(Storage = "_Nom", CanBeNull = false, DbType = "VARCHAR(15) NOT NULL", UpdateCheck = UpdateCheck.Never)]
        public string Nom
        {
            get
            {
                return this._Nom;
            }
            set
            {
                if (this._Nom != value)
                {
                    this.OnNomChanging(value);
                    this.SendPropertyChanging("Nom");
                    this._Nom = value;
                    this.SendPropertyChanged("Nom");
                    this.OnNomChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Prenom in the schema.
        /// </summary>
        [Column(Storage = "_Prenom", CanBeNull = false, DbType = "VARCHAR(15) NOT NULL", UpdateCheck = UpdateCheck.Never)]
        public string Prenom
        {
            get
            {
                return this._Prenom;
            }
            set
            {
                if (this._Prenom != value)
                {
                    this.OnPrenomChanging(value);
                    this.SendPropertyChanging("Prenom");
                    this._Prenom = value;
                    this.SendPropertyChanged("Prenom");
                    this.OnPrenomChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Login in the schema.
        /// </summary>
        [Column(Storage = "_Login", CanBeNull = false, DbType = "VARCHAR(10) NOT NULL", UpdateCheck = UpdateCheck.Never)]
        public string Login
        {
            get
            {
                return this._Login;
            }
            set
            {
                if (this._Login != value)
                {
                    this.OnLoginChanging(value);
                    this.SendPropertyChanging("Login");
                    this._Login = value;
                    this.SendPropertyChanged("Login");
                    this.OnLoginChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Mdp in the schema.
        /// </summary>
        [Column(Storage = "_Mdp", CanBeNull = false, DbType = "VARCHAR(10) NOT NULL", UpdateCheck = UpdateCheck.Never)]
        public string Mdp
        {
            get
            {
                return this._Mdp;
            }
            set
            {
                if (this._Mdp != value)
                {
                    this.OnMdpChanging(value);
                    this.SendPropertyChanging("Mdp");
                    this._Mdp = value;
                    this.SendPropertyChanged("Mdp");
                    this.OnMdpChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Autorisation in the schema.
        /// </summary>
        [Column(Storage = "_Autorisation", CanBeNull = false, DbType = "TINYINT(1) NOT NULL", UpdateCheck = UpdateCheck.Never)]
        public bool Autorisation
        {
            get
            {
                return this._Autorisation;
            }
            set
            {
                if (this._Autorisation != value)
                {
                    this.OnAutorisationChanging(value);
                    this.SendPropertyChanging("Autorisation");
                    this._Autorisation = value;
                    this.SendPropertyChanged("Autorisation");
                    this.OnAutorisationChanged();
                }
            }
        }
   
        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            var handler = this.PropertyChanging;
            if (handler != null)
                handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanging(System.String propertyName) 
        {
            var handler = this.PropertyChanging;
            if (handler != null)
                handler(this, new PropertyChangingEventArgs(propertyName));
        }

        protected virtual void SendPropertyChanged(System.String propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
