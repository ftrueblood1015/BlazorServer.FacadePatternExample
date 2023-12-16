using BlazorServer.FacadePatternExample.Domain.Models;
using BlazorServer.FacadePatternExample.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer.FacadePatternExample.Repositories.BookOrders
{
    public class BookOrderRepository : RepositoryBase<BookOrder, FacadePatternContext>, IBookOrderRepository
    {
        public BookOrderRepository(FacadePatternContext context) : base(context)
        {
        }

        public override IEnumerable<BookOrder> GetAll()
        {
            return Context.Set<BookOrder>().Include(b => b.Book).Include(c => c.Customer).Include(s => s.ShippingProvider);
        }
    }
}
