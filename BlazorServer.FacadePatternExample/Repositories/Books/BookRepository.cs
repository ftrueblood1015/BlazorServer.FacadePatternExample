using BlazorServer.FacadePatternExample.Domain.Models;
using BlazorServer.FacadePatternExample.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer.FacadePatternExample.Repositories.Books
{
    public class BookRepository : RepositoryBase<Book, FacadePatternContext>, IBookRepository
    {
        public BookRepository(FacadePatternContext context) : base(context)
        {
        }

        public override IEnumerable<Book> GetAll()
        {
            return Context.Set<Book>().Include(a => a.Author).Include(g => g.Genre);
        }
    }
}
