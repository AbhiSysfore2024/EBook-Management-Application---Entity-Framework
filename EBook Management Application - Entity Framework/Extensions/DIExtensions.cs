using Repositories;
using Repositories.Interfaces;

namespace EBook_Management_Application___Entity_Framework.Extensions
{
    public static class DIExtensions
    {
        public static void SingletonService(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticateAndAuthorize, AuthenticateAndAuthorize>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IGenreService, GenreService>();
        }
    }
}
