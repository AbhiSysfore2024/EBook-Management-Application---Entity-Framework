using Ebook.Data;
using Entities;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        [Route("GetAllBooks")]
        public ActionResult GetAllBooks()
        {
            var allBooks = _bookService.GetAllBooks();
            return Ok(allBooks);
        }

        [HttpGet]
        [Route("GetBookByID")]
        public ActionResult GetBooksByID(Guid id)
        {
            var book = _bookService.GetBookByID(id);
            return Ok(book);
        }

        [HttpPost]
        [Route("AddBook")]
        public ActionResult AddNewBook([FromBody] DTOBooks DTObook)
        {
            return Ok(_bookService.AddBook(DTObook));
        }

        [HttpGet]
        [Route("GetBooksByTitle")]
        public ActionResult GetBooksByTitle(string title)
        {
            return Ok(_bookService.GetBooksByTitle(title));
        }
    }
}
