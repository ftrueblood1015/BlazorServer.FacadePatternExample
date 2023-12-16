using BlazorServer.FacadePatternExample.Domain.Models;
using BlazorServer.FacadePatternExample.Repositories;
using BlazorServer.FacadePatternExample.Repositories.Authors;

namespace BlazorServer.FacadePatternExample.Services.Authors
{
    public class AuthorService : ServiceBase<Author, IAuthorRepository>, IAuthorService
    {
        public AuthorService(IRepositoryBase<Author> repo) : base(repo)
        {
        }
    }
}
