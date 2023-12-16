using BlazorServer.FacadePatternExample.Domain.Models;
using BlazorServer.FacadePatternExample.Repositories;
using BlazorServer.FacadePatternExample.Repositories.Books;

namespace BlazorServer.FacadePatternExample.Services.Books
{
    public class BookService : ServiceBase<Book, IBookRepository>, IBookService
    {
        public BookService(IRepositoryBase<Book> repo) : base(repo)
        {
        }
    }
}
