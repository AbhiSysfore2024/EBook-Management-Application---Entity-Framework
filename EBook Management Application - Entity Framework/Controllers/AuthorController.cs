using Ebook.Data;
using Microsoft.AspNetCore.Mvc;

namespace EBook_Management_Application___Entity_Framework.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;

        public AuthorController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("GetAllAuthors")]
        public ActionResult GetAllAuthors()
        {
            var allAuthors = _dbContext.EFCAuthor.ToList();
            return Ok(allAuthors);
        }
    }
}
