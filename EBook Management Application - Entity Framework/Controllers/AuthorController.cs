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
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        [Route("GetAllAuthors")]
        public ActionResult GetAllAuthors()
        {
            var allAuthors = _authorService.GetAllAuthors();
            return Ok(allAuthors);
        }

        [HttpGet]
        [Route("GetAuthorByID")]
        public ActionResult GetAuthorsByID(Guid id)
        {
            var author = _authorService.GetAuthorByID(id);
            return Ok(author);
        }

        [HttpPost]
        [Route("AddAuthor")]
        public ActionResult AddNewAuthor([FromBody] DTOAuthor DTOauthor)
        {
            return Ok(_authorService.AddAuthor(DTOauthor));
        }
    }
}
