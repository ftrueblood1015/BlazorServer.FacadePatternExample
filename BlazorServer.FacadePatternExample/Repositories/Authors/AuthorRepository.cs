using BlazorServer.FacadePatternExample.Domain.Models;
using BlazorServer.FacadePatternExample.Infrastructure;

namespace BlazorServer.FacadePatternExample.Repositories.Authors
{
    public class AuthorRepository : RepositoryBase<Author, FacadePatternContext>, IAuthorRepository
    {
        public AuthorRepository(FacadePatternContext context) : base(context)
        {
        }
    }
}
