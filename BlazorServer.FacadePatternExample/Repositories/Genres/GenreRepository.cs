using BlazorServer.FacadePatternExample.Domain.Models;
using BlazorServer.FacadePatternExample.Infrastructure;

namespace BlazorServer.FacadePatternExample.Repositories.Genres
{
    public class GenreRepository : RepositoryBase<Genre, FacadePatternContext>, IGenreRepository
    {
        public GenreRepository(FacadePatternContext context) : base(context)
        {
        }
    }
}
