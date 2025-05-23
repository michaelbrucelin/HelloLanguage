//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.1378
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LinqInAction.LinqBooks.Common.CSharp.SampleClasses.Ch8
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.Linq;
    using System.Data.Linq.Mapping;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    [System.Data.Linq.Mapping.DatabaseAttribute(Name = "C:\\PROJECTS\\LINQ\\LINQINACTION\\ORCAS\\LINQBOOKS.COMMON\\CLASSLIBRARY1\\LIA.MDF")]
    public partial class Ch8DataContext : System.Data.Linq.DataContext
    {
        private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();

        #region Extensibility Method Definitions
        partial void OnCreated();
        partial void InsertAuthor(Author instance);
        partial void UpdateAuthor(Author instance);
        partial void DeleteAuthor(Author instance);
        partial void InsertBook(Book instance);
        partial void UpdateBook(Book instance);
        partial void DeleteBook(Book instance);
        partial void InsertPublisher(Publisher instance);
        partial void UpdatePublisher(Publisher instance);
        partial void DeletePublisher(Publisher instance);
        #endregion

        static Ch8DataContext()
        {
        }

        public Ch8DataContext(string connection) : base(connection, mappingSource)
        {
            OnCreated();
        }

        public Ch8DataContext(System.Data.IDbConnection connection) : base(connection, mappingSource)
        {
            OnCreated();
        }

        public Ch8DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : base(connection, mappingSource)
        {
            OnCreated();
        }

        public Ch8DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : base(connection, mappingSource)
        {
            OnCreated();
        }

        public System.Data.Linq.Table<Author> Authors
        {
            get
            {
                return this.GetTable<Author>();
            }
        }

        public System.Data.Linq.Table<Book> Books
        {
            get
            {
                return this.GetTable<Book>();
            }
        }

        public System.Data.Linq.Table<Publisher> Publishers
        {
            get
            {
                return this.GetTable<Publisher>();
            }
        }

        [Function(Name = "dbo.GetBook")]
        public ISingleResult<Book> GetBook([Parameter(Name = "BookId", DbType = "UniqueIdentifier")] System.Nullable<System.Guid> bookId, [Parameter(Name = "UserName", DbType = "NVarChar(50)")] string userName)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), bookId, userName);
            return ((ISingleResult<Book>)(result.ReturnValue));
        }

        [Function(Name = "dbo.fnBookCountForPublisher", IsComposable = true)]
        public System.Nullable<int> fnBookCountForPublisher([Parameter(Name = "PublisherId", DbType = "UniqueIdentifier")] System.Nullable<System.Guid> publisherId)
        {
            return ((System.Nullable<int>)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), publisherId).ReturnValue));
        }

        [Function(Name = "dbo.BookCountForPublisher")]
        public int BookCountForPublisher([Parameter(Name = "PublisherId", DbType = "UniqueIdentifier")] System.Nullable<System.Guid> publisherId)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), publisherId);
            return ((int)(result.ReturnValue));
        }

        [Function(Name = "dbo.fnGetPublishersBooks", IsComposable = true)]
        public IQueryable<Book> fnGetPublishersBooks([Parameter(Name = "Publisher", DbType = "UniqueIdentifier")] System.Nullable<System.Guid> publisher)
        {
            return this.CreateMethodCallQuery<Book>(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), publisher);
        }
    }

    [Table(Name = "dbo.Author")]
    public partial class Author : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private System.Guid _ID;

        private string _LastName;

        private string _FirstName;

        private string _WebSite;

        private byte[] _TimeStamp;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate();
        partial void OnCreated();
        partial void OnIDChanging(System.Guid value);
        partial void OnIDChanged();
        partial void OnLastNameChanging(string value);
        partial void OnLastNameChanged();
        partial void OnFirstNameChanging(string value);
        partial void OnFirstNameChanged();
        partial void OnWebSiteChanging(string value);
        partial void OnWebSiteChanged();
        partial void OnTimeStampChanging(byte[] value);
        partial void OnTimeStampChanged();
        #endregion

        public Author()
        {
            OnCreated();
        }

        [Column(Storage = "_ID", DbType = "UniqueIdentifier NOT NULL", IsPrimaryKey = true, UpdateCheck = UpdateCheck.Never)]
        public System.Guid ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                if ((this._ID != value))
                {
                    this.OnIDChanging(value);
                    this.SendPropertyChanging();
                    this._ID = value;
                    this.SendPropertyChanged("ID");
                    this.OnIDChanged();
                }
            }
        }

        [Column(Storage = "_LastName", DbType = "VarChar(50) NOT NULL", CanBeNull = false, UpdateCheck = UpdateCheck.Never)]
        public string LastName
        {
            get
            {
                return this._LastName;
            }
            set
            {
                if ((this._LastName != value))
                {
                    this.OnLastNameChanging(value);
                    this.SendPropertyChanging();
                    this._LastName = value;
                    this.SendPropertyChanged("LastName");
                    this.OnLastNameChanged();
                }
            }
        }

        [Column(Storage = "_FirstName", DbType = "VarChar(30) NOT NULL", CanBeNull = false, UpdateCheck = UpdateCheck.Never)]
        public string FirstName
        {
            get
            {
                return this._FirstName;
            }
            set
            {
                if ((this._FirstName != value))
                {
                    this.OnFirstNameChanging(value);
                    this.SendPropertyChanging();
                    this._FirstName = value;
                    this.SendPropertyChanged("FirstName");
                    this.OnFirstNameChanged();
                }
            }
        }

        [Column(Storage = "_WebSite", DbType = "VarChar(200)", UpdateCheck = UpdateCheck.Never)]
        public string WebSite
        {
            get
            {
                return this._WebSite;
            }
            set
            {
                if ((this._WebSite != value))
                {
                    this.OnWebSiteChanging(value);
                    this.SendPropertyChanging();
                    this._WebSite = value;
                    this.SendPropertyChanged("WebSite");
                    this.OnWebSiteChanged();
                }
            }
        }

        [Column(Storage = "_TimeStamp", AutoSync = AutoSync.Always, DbType = "rowversion NOT NULL", CanBeNull = false, IsDbGenerated = true, IsVersion = true, UpdateCheck = UpdateCheck.Never)]
        public byte[] TimeStamp
        {
            get
            {
                return this._TimeStamp;
            }
            set
            {
                if ((this._TimeStamp != value))
                {
                    this.OnTimeStampChanging(value);
                    this.SendPropertyChanging();
                    this._TimeStamp = value;
                    this.SendPropertyChanged("TimeStamp");
                    this.OnTimeStampChanged();
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [Table(Name = "dbo.Book")]
    public partial class Book : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private System.Guid _ID;

        private string _Isbn;

        private string _Notes;

        private int _PageCount;

        private System.Nullable<decimal> _Price;

        private System.Nullable<System.DateTime> _PubDate;

        private System.Guid _Publisher;

        private System.Guid _Subject;

        private string _Summary;

        private string _Title;

        private EntityRef<Publisher> _Publisher1;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate();
        partial void OnCreated();
        partial void OnIDChanging(System.Guid value);
        partial void OnIDChanged();
        partial void OnIsbnChanging(string value);
        partial void OnIsbnChanged();
        partial void OnNotesChanging(string value);
        partial void OnNotesChanged();
        partial void OnPageCountChanging(int value);
        partial void OnPageCountChanged();
        partial void OnPriceChanging(System.Nullable<decimal> value);
        partial void OnPriceChanged();
        partial void OnPubDateChanging(System.Nullable<System.DateTime> value);
        partial void OnPubDateChanged();
        partial void OnPublisherChanging(System.Guid value);
        partial void OnPublisherChanged();
        partial void OnSubjectChanging(System.Guid value);
        partial void OnSubjectChanged();
        partial void OnSummaryChanging(string value);
        partial void OnSummaryChanged();
        partial void OnTitleChanging(string value);
        partial void OnTitleChanged();
        #endregion

        public Book()
        {
            OnCreated();
            this._Publisher1 = default(EntityRef<Publisher>);
        }

        [Column(Storage = "_ID", DbType = "UniqueIdentifier NOT NULL", IsPrimaryKey = true)]
        public System.Guid ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                if ((this._ID != value))
                {
                    this.OnIDChanging(value);
                    this.SendPropertyChanging();
                    this._ID = value;
                    this.SendPropertyChanged("ID");
                    this.OnIDChanged();
                }
            }
        }

        [Column(Storage = "_Isbn", DbType = "NChar(13)")]
        public string Isbn
        {
            get
            {
                return this._Isbn;
            }
            set
            {
                if ((this._Isbn != value))
                {
                    this.OnIsbnChanging(value);
                    this.SendPropertyChanging();
                    this._Isbn = value;
                    this.SendPropertyChanged("Isbn");
                    this.OnIsbnChanged();
                }
            }
        }

        [Column(Storage = "_Notes", DbType = "VarChar(2000)")]
        public string Notes
        {
            get
            {
                return this._Notes;
            }
            set
            {
                if ((this._Notes != value))
                {
                    this.OnNotesChanging(value);
                    this.SendPropertyChanging();
                    this._Notes = value;
                    this.SendPropertyChanged("Notes");
                    this.OnNotesChanged();
                }
            }
        }

        [Column(Storage = "_PageCount", DbType = "Int NOT NULL")]
        public int PageCount
        {
            get
            {
                return this._PageCount;
            }
            set
            {
                if ((this._PageCount != value))
                {
                    this.OnPageCountChanging(value);
                    this.SendPropertyChanging();
                    this._PageCount = value;
                    this.SendPropertyChanged("PageCount");
                    this.OnPageCountChanged();
                }
            }
        }

        [Column(Storage = "_Price", DbType = "Money")]
        public System.Nullable<decimal> Price
        {
            get
            {
                return this._Price;
            }
            set
            {
                if ((this._Price != value))
                {
                    this.OnPriceChanging(value);
                    this.SendPropertyChanging();
                    this._Price = value;
                    this.SendPropertyChanged("Price");
                    this.OnPriceChanged();
                }
            }
        }

        [Column(Storage = "_PubDate", DbType = "DateTime")]
        public System.Nullable<System.DateTime> PubDate
        {
            get
            {
                return this._PubDate;
            }
            set
            {
                if ((this._PubDate != value))
                {
                    this.OnPubDateChanging(value);
                    this.SendPropertyChanging();
                    this._PubDate = value;
                    this.SendPropertyChanged("PubDate");
                    this.OnPubDateChanged();
                }
            }
        }

        [Column(Storage = "_Publisher", DbType = "UniqueIdentifier NOT NULL")]
        public System.Guid Publisher
        {
            get
            {
                return this._Publisher;
            }
            set
            {
                if ((this._Publisher != value))
                {
                    if (this._Publisher1.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnPublisherChanging(value);
                    this.SendPropertyChanging();
                    this._Publisher = value;
                    this.SendPropertyChanged("Publisher");
                    this.OnPublisherChanged();
                }
            }
        }

        [Column(Storage = "_Subject", DbType = "UniqueIdentifier NOT NULL")]
        public System.Guid Subject
        {
            get
            {
                return this._Subject;
            }
            set
            {
                if ((this._Subject != value))
                {
                    this.OnSubjectChanging(value);
                    this.SendPropertyChanging();
                    this._Subject = value;
                    this.SendPropertyChanged("Subject");
                    this.OnSubjectChanged();
                }
            }
        }

        [Column(Storage = "_Summary", DbType = "VarChar(2000)")]
        public string Summary
        {
            get
            {
                return this._Summary;
            }
            set
            {
                if ((this._Summary != value))
                {
                    this.OnSummaryChanging(value);
                    this.SendPropertyChanging();
                    this._Summary = value;
                    this.SendPropertyChanged("Summary");
                    this.OnSummaryChanged();
                }
            }
        }

        [Column(Storage = "_Title", DbType = "VarChar(100) NOT NULL", CanBeNull = false)]
        public string Title
        {
            get
            {
                return this._Title;
            }
            set
            {
                if ((this._Title != value))
                {
                    this.OnTitleChanging(value);
                    this.SendPropertyChanging();
                    this._Title = value;
                    this.SendPropertyChanged("Title");
                    this.OnTitleChanged();
                }
            }
        }

        [Association(Name = "Publisher_Book", Storage = "_Publisher1", ThisKey = "Publisher", IsForeignKey = true)]
        public Publisher Publisher1
        {
            get
            {
                return this._Publisher1.Entity;
            }
            set
            {
                Publisher previousValue = this._Publisher1.Entity;
                if (((previousValue != value)
                            || (this._Publisher1.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Publisher1.Entity = null;
                        previousValue.Books.Remove(this);
                    }
                    this._Publisher1.Entity = value;
                    if ((value != null))
                    {
                        value.Books.Add(this);
                        this._Publisher = value.ID;
                    }
                    else
                    {
                        this._Publisher = default(System.Guid);
                    }
                    this.SendPropertyChanged("Publisher1");
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [Table(Name = "dbo.Publisher")]
    public partial class Publisher : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private System.Guid _ID;

        private string _Name;

        private byte[] _Logo;

        private string _WebSite;

        private EntitySet<Book> _Books;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate();
        partial void OnCreated();
        partial void OnIDChanging(System.Guid value);
        partial void OnIDChanged();
        partial void OnNameChanging(string value);
        partial void OnNameChanged();
        partial void OnLogoChanging(byte[] value);
        partial void OnLogoChanged();
        partial void OnWebSiteChanging(string value);
        partial void OnWebSiteChanged();
        #endregion

        public Publisher()
        {
            OnCreated();
            this._Books = new EntitySet<Book>(new Action<Book>(this.attach_Books), new Action<Book>(this.detach_Books));
        }

        [Column(Storage = "_ID", DbType = "UniqueIdentifier NOT NULL", IsPrimaryKey = true)]
        public System.Guid ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                if ((this._ID != value))
                {
                    this.OnIDChanging(value);
                    this.SendPropertyChanging();
                    this._ID = value;
                    this.SendPropertyChanged("ID");
                    this.OnIDChanged();
                }
            }
        }

        [Column(Storage = "_Name", DbType = "VarChar(50) NOT NULL", CanBeNull = false)]
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                if ((this._Name != value))
                {
                    this.OnNameChanging(value);
                    this.SendPropertyChanging();
                    this._Name = value;
                    this.SendPropertyChanged("Name");
                    this.OnNameChanged();
                }
            }
        }

        [Column(Storage = "_Logo", DbType = "Image", UpdateCheck = UpdateCheck.Never)]
        public byte[] Logo
        {
            get
            {
                return this._Logo;
            }
            set
            {
                if ((this._Logo != value))
                {
                    this.OnLogoChanging(value);
                    this.SendPropertyChanging();
                    this._Logo = value;
                    this.SendPropertyChanged("Logo");
                    this.OnLogoChanged();
                }
            }
        }

        [Column(Storage = "_WebSite", DbType = "VarChar(200)", CanBeNull = false)]
        public string WebSite
        {
            get
            {
                return this._WebSite;
            }
            set
            {
                if ((this._WebSite != value))
                {
                    this.OnWebSiteChanging(value);
                    this.SendPropertyChanging();
                    this._WebSite = value;
                    this.SendPropertyChanged("WebSite");
                    this.OnWebSiteChanged();
                }
            }
        }

        [Association(Name = "Publisher_Book", Storage = "_Books", OtherKey = "Publisher")]
        public EntitySet<Book> Books
        {
            get
            {
                return this._Books;
            }
            set
            {
                this._Books.Assign(value);
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void attach_Books(Book entity)
        {
            this.SendPropertyChanging();
            entity.Publisher1 = this;
            this.SendPropertyChanged("Books");
        }

        private void detach_Books(Book entity)
        {
            this.SendPropertyChanging();
            entity.Publisher1 = null;
            this.SendPropertyChanged("Books");
        }
    }
}
