using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Repositories.Interfaces;
using System.Globalization;

namespace EBook_Management_Application___Entity_Framework.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [Authorize(Roles = "Admin,User")]
        [HttpGet]
        [Route("GetAllGenres")]
        public ActionResult GetAllGenres()
        {
            var allGenres = _genreService.GetAllGenres();
            return Ok(allGenres);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("AddGenre")]
        public ActionResult AddGenre(string genreName)
        {
            return Ok(_genreService.AddGenre(genreName));
        }
    }
}