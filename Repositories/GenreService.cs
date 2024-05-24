using Ebook.Data;
using Entities;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class GenreService : IGenreService
    {
        private readonly ApplicationDBContext _dbContext;

        public GenreService(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Genre> GetAllGenres()
        {
            return _dbContext.EFCGenre.ToList();
        }

        public string AddGenre(string genreName)
        {
            try
            {
                var addGenre = new Genre
                {
                    GenreName = genreName,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                };

                _dbContext.Add(addGenre);
                _dbContext.SaveChanges();
                return "Genre added successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
