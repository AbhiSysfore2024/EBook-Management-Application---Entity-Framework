using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IAuthorService
    {
        List<Author> GetAllAuthors();
        Author AddAuthor(DTOAuthor author);
        Author GetAuthorByID(Guid id);
        string UpdateAuthor(Guid authorID, UpdateAuthorModel author);
        string DeleteAuthor(Guid id);
    }
}
