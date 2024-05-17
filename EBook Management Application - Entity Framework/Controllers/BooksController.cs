using Ebook.Data;
using Microsoft.AspNetCore.Mvc;

namespace EBook_Management_Application___Entity_Framework.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;

        public BookController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("GetAllBooks")]
        public ActionResult GetAllBooks()
        {
            var allAuthors = _dbContext.EFCBooks.ToList();
            return Ok(allAuthors);
        }
    }
}
