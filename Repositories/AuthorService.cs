using CustomExceptions;
using Ebook.Data;
using Entities;
using Repositories.Interfaces;

namespace Repositories
{
    public class AuthorService : IAuthorService
    {
        private readonly ApplicationDBContext _dbContext;

        public AuthorService(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<AuthorModel> GetAllAuthors()
        {
            return _dbContext.EFCAuthor.ToList();
        }

        public AuthorModel AddAuthor(DTOAuthor DTOauthor)
        {
            AuthorModel author = new AuthorModel(DTOauthor);
            var addAuthor = _dbContext.EFCAuthor.Add(author);
            _dbContext.SaveChanges();
            return addAuthor.Entity;
        }

        public AuthorModel GetAuthorByID(Guid id)
        {
            return _dbContext.EFCAuthor.FirstOrDefault(author => author.AuthorID == id);
        }

        public string UpdateAuthor(UpdateAuthorModel author)
        {
            try
            {
                var updateAuthor = _dbContext.EFCAuthor.Find(author.AuthorID);

                if (updateAuthor != null)
                {
                    throw new AuthorNotFound("Author not found, please enter valid author ID");
                }
                updateAuthor.Name.FirstName = author.Name.FirstName;
                updateAuthor.Name.LastName = author.Name.LastName;
                updateAuthor.Biography = author.Biography;
                updateAuthor.BirthDate = author.BirthDate;
                updateAuthor.Country = author.Country;
                updateAuthor.UpdatedAt = DateTime.Now;

                _dbContext.SaveChanges();
                return "Author updated successfully";
            }

            catch (AuthorNotFound authorNotFound)
            {
                return authorNotFound.Message;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string DeleteAuthor(Guid authorID)
        {
            try
            {
                var deleteAuthor = _dbContext.EFCAuthor.Find(authorID);

                if (deleteAuthor != null)
                {
                    throw new AuthorNotFound("Author not found, please enter valid author ID");
                }

                _dbContext.EFCAuthor.Remove(deleteAuthor);
                _dbContext.SaveChanges();

                return "Author successfully deleted";
            }
            catch (AuthorNotFound authorNotFound)
            {
                return authorNotFound.Message;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
