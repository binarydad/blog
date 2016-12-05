namespace BinaryDad.Data
{
    using Models;
    using System.Data.Entity;

    public class BlogContext : DbContext
    {
        // Your context has been configured to use a 'BlogContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'BinaryDad.Data.BlogContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'BlogContext' 
        // connection string in the application configuration file.
        public BlogContext() : base("name=BlogContext") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Content>().Ignore(c => c.Type);

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<BlogEntry> BlogEntries { get; set; }
        public virtual DbSet<Page> Pages { get; set; }
        public virtual DbSet<Content> Content { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}