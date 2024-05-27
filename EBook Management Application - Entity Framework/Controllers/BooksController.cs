using Ebook.Data;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Repositories.Interfaces;

namespace EBook_Management_Application___Entity_Framework.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("GetAllBooks")]
        public ActionResult GetAllBooks()
        {
            var allBooks = _bookService.GetAllBooks();
            return Ok(allBooks);
        }

        [Authorize(Roles = "Admin,User")]
        [HttpGet]
        [Route("GetBookByID")]
        public ActionResult GetBooksByID(Guid id)
        {
            var book = _bookService.GetBookByID(id);
            return Ok(book);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("AddBook")]
        public ActionResult AddNewBook([FromBody] DTOBooks DTObook)
        {
            return Ok(_bookService.AddBook(DTObook));
        }

        [Authorize(Roles = "Admin,User")]
        [HttpGet]
        [Route("GetBooksByTitle")]
        public ActionResult GetBooksByTitle(string title)
        {
            return Ok(_bookService.GetBooksByTitle(title));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("Update Book")]
        public ActionResult UpdateBook(Guid bookID, [FromBody] UpdateBookModel book)
        {
            try
            {
                var updateBook = _bookService.UpdateBook(bookID, book);

                if (updateBook == "Book updated successfully")
                {
                    return Ok(updateBook);
                }
                else
                {
                    return BadRequest(updateBook);
                }
            }
            catch
            {
                return BadRequest("An error occurred while trying to update author");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("Delete Book")]
        public ActionResult DeleteBook(Guid bookID)
        {
            try
            {
                var deleteBook = _bookService.DeleteBook(bookID);

                if (deleteBook == "Book successfully deleted")
                {
                    return Ok(deleteBook);
                }
                else
                {
                    return BadRequest(deleteBook);
                }
            }
            catch
            {
                return BadRequest("An error occurred while trying to update book");
            }
        }
    }
}
