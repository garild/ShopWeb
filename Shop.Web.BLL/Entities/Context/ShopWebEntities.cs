namespace DataLayer
{
    using global::Shop.Web.BLL.Data.Models;
    using System.Configuration;
    using System.Data.Entity;
    public partial class ShopWebEntities : DbContext
    {
        private readonly string BaseConnection = ConfigurationManager.ConnectionStrings["ShopWebEntities"].ConnectionString;
        public ShopWebEntities()
            : base()
        {
            this.Database.Connection.ConnectionString = BaseConnection;
            // Wy³¹czenie lasy loading
            this.Configuration.LazyLoadingEnabled = false;
            // Zale¿ne od lasy loading - pobiera modele okreœlone w referencji encji bazowej
            this.Configuration.ProxyCreationEnabled = false;
            // Validacja zbêdna - optymalizacja
            this.Configuration.ValidateOnSaveEnabled = false;
            // Autoœledzenie zmian,zbêdne - optymalizacja
            this.Configuration.AutoDetectChangesEnabled = false;
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Books_D_BookType> Books_D_BookType { get; set; }
        public DbSet<Cover> Covers { get; set; }
        public DbSet<Edition> Editions { get; set; }
        public DbSet<Medium> Mediums { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.Author)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.Publisher)
                .IsUnicode(false);

            modelBuilder.Entity<Books_D_BookType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Books_D_BookType>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Books_D_BookType>()
                .HasMany(e => e.Books)
                .WithRequired(e => e.Books_D_BookType)
                .HasForeignKey(e => e.BookType_Id)
                .WillCascadeOnDelete(false);
           
            modelBuilder.Entity<Cover>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Edition>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Medium>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Publisher>()
                .Property(e => e.Name)
                .IsUnicode(false);

        
        }
    }
}
