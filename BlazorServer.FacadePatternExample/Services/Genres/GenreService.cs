using BlazorServer.FacadePatternExample.Domain.Models;
using BlazorServer.FacadePatternExample.Repositories;
using BlazorServer.FacadePatternExample.Repositories.Genres;

namespace BlazorServer.FacadePatternExample.Services.Genres
{
    public class GenreService : ServiceBase<Genre, IGenreRepository>, IGenreService
    {
        public GenreService(IRepositoryBase<Genre> repo) : base(repo)
        {
        }
    }
}
