using Entities;
using Microsoft.EntityFrameworkCore;

namespace Ebook.Data
{
    public class ApplicationDBContext : DbContext 
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<LoginRequest> EFCCredentials { get; set; }
        public DbSet<Author> EFCAuthor { get; set; }
        public DbSet<Book> EFCBooks { get; set; }
        public DbSet<Genre> EFCGenre { get; set; }

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

            modelBuilder.Entity<Book>()
            .HasOne(book => book.Genre)
            .WithMany(g => g.Book)
            .HasForeignKey(b => b.BookGenre);

            modelBuilder.Entity<Genre>().HasKey(genre => genre.GenreId);
            modelBuilder.Entity<LoginRequest>().HasKey(user => user.UserId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
