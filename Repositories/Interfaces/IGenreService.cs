using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IGenreService
    {
        List<Genre> GetAllGenres();
        string AddGenre (string genreName);
        //string UpdateGenre (int genreID, Genre genre);
    }
}
