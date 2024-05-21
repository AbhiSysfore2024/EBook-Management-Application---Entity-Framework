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
        List<BookModel> GetAllBooks();
        BookModel AddBook(DTOBooks book);
        BookModel GetBookByID(Guid id);
        string UpdateBook(Guid bookID, UpdateBookModel book);
        string DeleteBook(Guid id);
        List<BookModel> GetBooksByTitle (string title);
    }
}
