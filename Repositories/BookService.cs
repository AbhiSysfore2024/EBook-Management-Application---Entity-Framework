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
            return _dbContext.EFCBooks.ToList();
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
            return _dbContext.EFCBooks.FirstOrDefault(book => book.BookID == id);
        }

        public string UpdateBook(Guid bookID, UpdateBookModel book)
        {
            try
            {
                var updateBook = _dbContext.EFCBooks.Find(bookID);

                if (updateBook != null)
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

               // updateBook.BookAuthor.Clear();

                foreach (var authorID in book.AuthorID)
                {
                    var author = _dbContext.EFCBooks.Find(authorID);
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
                var deleteBook = _dbContext.EFCBooks.Find(bookID);

                if (deleteBook != null)
                {
                    throw new BookNotFound("Book not found, please enter valid author ID");
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
                var books = _dbContext.EFCBooks.Where(book => book.Title.Contains(title)).ToList();

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
