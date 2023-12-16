using BlazorServer.FacadePatternExample.Domain.Models;
using BlazorServer.FacadePatternExample.Repositories;
using BlazorServer.FacadePatternExample.Repositories.Customers;

namespace BlazorServer.FacadePatternExample.Services.Customers
{
    public class CustomerService : ServiceBase<Customer, ICustomerRepository>, ICustomerService
    {
        public CustomerService(IRepositoryBase<Customer> repo) : base(repo)
        {
        }
    }
}
