using Entities;
using Microsoft.EntityFrameworkCore;

namespace Ebook.Data
{
    public class ApplicationDBContext : DbContext 
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .OwnsOne(author => author.Name);

            modelBuilder.Entity<Book>()
                .HasMany(book => book.Author)
                .WithMany(author => author.Book)
                .UsingEntity(
                    "EFCBookAuthor",
                    r => r.HasOne(typeof(Author)).WithMany().HasForeignKey("AuthorID").HasPrincipalKey(nameof(Author.AuthorID)),
                    l => l.HasOne(typeof(Book)).WithMany().HasForeignKey("BookID").HasPrincipalKey(nameof(Book.BookID)),
                    j => j.HasKey("AuthorID", "BookID"));

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<LoginRequest> EFCCredentials { get; set; }
        public DbSet<Author> EFCAuthor { get; set; }
        public DbSet<Book> EFCBooks { get; set; }
    }
}
