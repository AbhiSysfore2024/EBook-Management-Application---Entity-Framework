using CustomExceptions;
using Ebook.Data;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Repositories.Interfaces;
using static System.Reflection.Metadata.BlobBuilder;

namespace Repositories
{
    public class BookService : IBookService
    {
        private readonly ApplicationDBContext _dbContext;

        public BookService(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Book> GetAllBooks()
        {
            return _dbContext.EFCBooks.Include(author => author.Author).Include(genre => genre.Genre).ToList();
        }

        public string AddBook(DTOBooks DTObook)
        {
            try
            {
                Book book = new Book(DTObook);
                var existingAuthors = _dbContext.EFCAuthor.Where(a => DTObook.AuthorID.Contains(a.AuthorID)).ToList();

                foreach(var author in existingAuthors)
                {
                    book.Author.Add(author);
                }

                _dbContext.EFCBooks.Add(book);
                _dbContext.SaveChanges();
                return "Added successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Book GetBookByID(Guid id)
        {
            return _dbContext.EFCBooks.Include(author => author.Author).Include(genre => genre.Genre).FirstOrDefault(book => book.BookID == id);
        }

        public string UpdateBook(Guid bookID, UpdateBookModel book)
        {
            try
            {
                var updateBook = _dbContext.EFCBooks.Include(b => b.Author).FirstOrDefault(b => b.BookID == bookID);

                if (updateBook == null)
                {
                    throw new BookNotFound("Book not found, please enter valid book ID");
                }

                updateBook.Title = book.Title;
                updateBook.Description = book.Description;
                updateBook.ISBN = book.ISBN;
                updateBook.Publication_Date = book.Publication_Date;
                updateBook.Price = book.Price;
                updateBook.Language = book.Language;
                updateBook.Publisher = book.Publisher;
                updateBook.PageCount = book.PageCount;
                updateBook.AvgRating = book.AvgRating;
                updateBook.BookGenre = book.BookGenre;
                updateBook.IsAvailable = book.IsAvailable;
                updateBook.UpdatedAt = DateTime.Now;

               updateBook.Author.Clear();

                var existingAuthors = _dbContext.EFCAuthor.Where(a=> book.AuthorID.Contains(a.AuthorID)).ToList();

                foreach (var author in existingAuthors)
                {
                    updateBook.Author.Add(author);
                }

                _dbContext.SaveChanges();
                return "Book updated successfully";
            }

            catch (BookNotFound bookNotFound)
            {
                return bookNotFound.Message;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string DeleteBook(Guid bookID)
        {
            try
            {
                var deleteBook = _dbContext.EFCBooks.Include(b => b.Author).FirstOrDefault(b => b.BookID == bookID);

                if (deleteBook == null)
                {
                    throw new BookNotFound("Book not found, please enter valid book ID");
                }

                _dbContext.EFCBooks.Remove(deleteBook);
                _dbContext.SaveChanges();

                return "Book successfully deleted";
            }
            catch (BookNotFound bookNotFound)
            {
                return bookNotFound.Message;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public List<Book> GetBooksByTitle(string title)
        {
            try
            {
                var books = _dbContext.EFCBooks.Include(b => b.Author).Where(b => b.Title == title).ToList();

                return books;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Book>();
            }
        }
    }
}
