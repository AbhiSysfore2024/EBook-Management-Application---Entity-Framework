using Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IBookService
    {
        List<Book> GetAllBooks();
        string AddBook(DTOBooks book);
        Book GetBookByID(Guid id);
        string UpdateBook(Guid bookID, UpdateBookModel book);
        string DeleteBook(Guid id);
        List<Book> GetBooksByTitle (string title);
    }
}
