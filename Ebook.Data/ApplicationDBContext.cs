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
            modelBuilder.Entity<AuthorModel>()
                .OwnsOne(author => author.Name);


            modelBuilder.Entity<BookAuthor>()
                .HasOne(book => book.Book)
                .WithMany(bookauthor => bookauthor.BookAuthor)
                .HasForeignKey(bookid => bookid.BookId);

            modelBuilder.Entity<BookAuthor>()
                .HasOne(author => author.Author)
                .WithMany(bookauthor => bookauthor.BookAuthor)
                .HasForeignKey(authorid => authorid.AuthorId);

            modelBuilder.Entity<BookAuthor>()
                .HasKey(m => new { m.BookId, m.AuthorId });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<LoginRequest> EFCCredentials { get; set; }
        public DbSet<AuthorModel> EFCAuthor { get; set; }
        public DbSet<BookModel> EFCBooks { get; set; }
        public DbSet<BookAuthor> EFCBookAuthor { get; set; }
    }
}
