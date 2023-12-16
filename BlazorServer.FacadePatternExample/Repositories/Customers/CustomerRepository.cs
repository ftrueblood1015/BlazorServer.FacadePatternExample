using BlazorServer.FacadePatternExample.Domain.Models;
using BlazorServer.FacadePatternExample.Infrastructure;

namespace BlazorServer.FacadePatternExample.Repositories.Customers
{
    public class CustomerRepository : RepositoryBase<Customer, FacadePatternContext>, ICustomerRepository
    {
        public CustomerRepository(FacadePatternContext context) : base(context)
        {
        }
    }
}
