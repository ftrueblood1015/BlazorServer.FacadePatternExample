using BlazorServer.FacadePatternExample.Discounts;
using BlazorServer.FacadePatternExample.Discounts.Bulk;
using BlazorServer.FacadePatternExample.Discounts.CustomerLoyalty;
using BlazorServer.FacadePatternExample.Discounts.NewlyPublished;
using BlazorServer.FacadePatternExample.Discounts.Shipper;
using BlazorServer.FacadePatternExample.Domain.Models;
using BlazorServer.FacadePatternExample.Repositories;
using BlazorServer.FacadePatternExample.Repositories.BookOrders;
using BlazorServer.FacadePatternExample.Repositories.Customers;
using BlazorServer.FacadePatternExample.Services.Books;
using BlazorServer.FacadePatternExample.Services.Customers;
using BlazorServer.FacadePatternExample.Services.ShippingProviders;

namespace BlazorServer.FacadePatternExample.Services.BookOrders
{
    public class BookOrderService : ServiceBase<BookOrder, IBookOrderRepository>, IBookOrderService
    {
        private readonly ICustomerService CustomerService;
        private readonly IShippingProviderService ShippingProviderService;
        private readonly IBookService BookService;
        public BookOrderService(
            IRepositoryBase<BookOrder> repo, 
            ICustomerService customerService, 
            IShippingProviderService shippingProviderService,
            IBookService bookService) : base(repo)
        {
            CustomerService = customerService;
            ShippingProviderService = shippingProviderService;
            BookService = bookService;
        }

        public override BookOrder Add(BookOrder entity)
        {
            Book Book = BookService.GetById((int)entity.BookId!) ?? throw new Exception("Book was null!");

            entity.DiscountPercentage = new DiscountFacade(BookService, CustomerService, ShippingProviderService).CalculateDiscount(entity);
            entity.DiscountTotal = (entity.Quantity * Book.Price) * entity.DiscountPercentage;
            entity.Total = (entity.Quantity * Book.Price) - entity.DiscountTotal;
            return Repo.Add(entity);
        }
    }
}
