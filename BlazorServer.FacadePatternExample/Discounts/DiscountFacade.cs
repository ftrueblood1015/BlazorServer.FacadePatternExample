using BlazorServer.FacadePatternExample.Discounts.Bulk;
using BlazorServer.FacadePatternExample.Discounts.CustomerLoyalty;
using BlazorServer.FacadePatternExample.Discounts.NewlyPublished;
using BlazorServer.FacadePatternExample.Discounts.Shipper;
using BlazorServer.FacadePatternExample.Domain.Models;
using BlazorServer.FacadePatternExample.Services.Books;
using BlazorServer.FacadePatternExample.Services.Customers;
using BlazorServer.FacadePatternExample.Services.ShippingProviders;

namespace BlazorServer.FacadePatternExample.Discounts
{
    public class DiscountFacade
    {
        private readonly IBookService BookService;
        private readonly ICustomerService CustomerService;
        private readonly IShippingProviderService ShippingProviderService;

        public DiscountFacade(IBookService bookService, ICustomerService customerService, IShippingProviderService shippingProviderService)
        {
            BookService = bookService;
            CustomerService = customerService;
            ShippingProviderService = shippingProviderService;
        }

        public decimal CalculateDiscount(BookOrder order)
        {
            return GetBulkDiscount(order) + GetLoyaltyDiscount(order) + GetShipperDiscount(order) + GetNewBookDiscount(order);
        }

        private decimal GetBulkDiscount(BookOrder order)
        {
            return new BulkDiscountFactory(order).CreateBulkDiscountService().DiscountPercentage;
        }

        private decimal GetLoyaltyDiscount(BookOrder order)
        {
            Customer Customer = CustomerService.GetById((int)order.CustomerId!) ?? throw new Exception("Customer was null!");
            return new CustomerLoyaltyDiscountFactory(Customer).CreateLoyaltyDiscountService().DiscountPercentage;
        }

        private decimal GetShipperDiscount(BookOrder order)
        {
            ShippingProvider Shipper = ShippingProviderService.GetById((int)order.ShippingProviderId!) ?? throw new Exception("Shipper was null!");
            return new ShippingProviderDiscountFactory(Shipper).CreateShippingProviderDiscountService().DiscountPercentage;
        }

        private decimal GetNewBookDiscount(BookOrder order)
        {
            Book Book = BookService.GetById((int)order.BookId!) ?? throw new Exception("Book was null!");
            return new NewlyPublishedDiscountFactory(Book).CreateNewlyPublishedDiscountService().DiscountPercentage;
        }
    }
}
