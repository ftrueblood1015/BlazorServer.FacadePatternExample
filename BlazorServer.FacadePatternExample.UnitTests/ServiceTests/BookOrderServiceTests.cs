using BlazorServer.FacadePatternExample.Domain.Models;
using BlazorServer.FacadePatternExample.Repositories.BookOrders;
using BlazorServer.FacadePatternExample.Repositories.Books;
using BlazorServer.FacadePatternExample.Repositories.Customers;
using BlazorServer.FacadePatternExample.Repositories.ShippingProviders;
using BlazorServer.FacadePatternExample.Services.BookOrders;
using BlazorServer.FacadePatternExample.Services.Books;
using BlazorServer.FacadePatternExample.Services.Customers;
using BlazorServer.FacadePatternExample.Services.ShippingProviders;
using BlazorServer.FacadePatternExample.UnitTests.MockBases;
using Shouldly;

namespace BlazorServer.FacadePatternExample.UnitTests.ServiceTests
{
    public class BookOrderServiceTests
    {
        private readonly IBookService BookService;
        private readonly IBookOrderService BookOrderService;
        private readonly ICustomerService CustomerService;
        private readonly IShippingProviderService ShippingProviderService;

        public BookOrderServiceTests()
        {
            var BookRepo = MockRepoBase.MockRepo<IBookRepository, Book>(new List<Book>()
            {
                new Book { Id = 1, AuthorId = 1, Description = "Current Year", GenreId = 1, IsActive = true, Name = "Test Book 1", Price = 100, PublishYear = DateTime.Now.Year  },
                new Book { Id = 2, AuthorId = 1, Description = "Not Current Year", GenreId = 1, IsActive = true, Name = "Test Book 2", Price = 100, PublishYear = DateTime.Now.Year - 1  }
            });

            var CustomerRepo = MockRepoBase.MockRepo<ICustomerRepository, Customer>(new List<Customer>()
            { 
                new Customer { Id = 1, Address = "1234 Fake Street", Country = "USA", CustomerSince = DateTime.Now, Description = "New Customer", IsActive = true, Name = "New Customer" },
                new Customer { Id = 2, Address = "4567 Fake Street", Country = "USA", CustomerSince = DateTime.Now.AddYears(-6), Description = "Old Customer", IsActive = true, Name = "Old Customer" }
            });

            var ShippingRepo = MockRepoBase.MockRepo<IShippingProviderRepository, ShippingProvider>(new List<ShippingProvider>()
            {
                new ShippingProvider { Id = 1, Description = "United States Postal Service", IsActive = true, Name = "USPS"},
                new ShippingProvider { Id = 2, Description = "United Postal Service", IsActive = true, Name = "UPS"},
                new ShippingProvider { Id = 3, Description = "Fedex", IsActive = true, Name = "FEDEX"},
                new ShippingProvider { Id = 4, Description = "LOCAL", IsActive = true, Name = "LOCAL"}
            });

            var OrderRepo = MockRepoBase.MockRepo<IBookOrderRepository, BookOrder>(new List<BookOrder>());

            BookService = new BookService(BookRepo.Object);
            CustomerService = new CustomerService(CustomerRepo.Object);
            ShippingProviderService = new ShippingProviderService(ShippingRepo.Object);
            BookOrderService = new BookOrderService(OrderRepo.Object, CustomerService, ShippingProviderService, BookService);
        }

        [Test]
        public void BookOrderService_Add_No_Discount()
        {
            // Arrange
            var BookOrder = new BookOrder() { Id = 1, BookId = 2, CustomerId = 1, ShippingProviderId = 4, Description = "None", IsActive = true, Name = "0 Discount", Quantity = 1 };

            // Act
            var result = BookOrderService.Add(BookOrder);

            // Assert
            result.DiscountPercentage.ShouldBe(0);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void BookOrderService_Add_No_Bulk_Discount(int quantity)
        {
            // Arrange
            var BookOrder = new BookOrder() { Id = 1, BookId = 2, CustomerId = 1, ShippingProviderId = 4, Description = "None", IsActive = true, Name = "0 Discount", Quantity = quantity };

            // Act
            var result = BookOrderService.Add(BookOrder);

            // Assert
            result.DiscountPercentage.ShouldBe(0);
        }

        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        public void BookOrderService_Add_5_to_9_Discount(int quantity)
        {
            // Arrange
            var BookOrder = new BookOrder() { Id = 1, BookId = 2, CustomerId = 1, ShippingProviderId = 4, Description = "None", IsActive = true, Name = "0 Discount", Quantity = quantity };

            // Act
            var result = BookOrderService.Add(BookOrder);

            // Assert
            result.DiscountPercentage.ShouldBe(0.01m);
        }

        [TestCase(10)]
        [TestCase(11)]
        [TestCase(12)]
        [TestCase(13)]
        [TestCase(14)]
        [TestCase(15)]
        [TestCase(16)]
        [TestCase(17)]
        [TestCase(18)]
        [TestCase(19)]
        public void BookOrderService_Add_10_to_19_Discount(int quantity)
        {
            // Arrange
            var BookOrder = new BookOrder() { Id = 1, BookId = 2, CustomerId = 1, ShippingProviderId = 4, Description = "None", IsActive = true, Name = "0 Discount", Quantity = quantity };

            // Act
            var result = BookOrderService.Add(BookOrder);

            // Assert
            result.DiscountPercentage.ShouldBe(0.05m);
        }

        [TestCase(20)]
        [TestCase(30)]
        [TestCase(40)]
        public void BookOrderService_Add_20_Plus_Discount(int quantity)
        {
            // Arrange
            var BookOrder = new BookOrder() { Id = 1, BookId = 2, CustomerId = 1, ShippingProviderId = 4, Description = "None", IsActive = true, Name = "0 Discount", Quantity = quantity };

            // Act
            var result = BookOrderService.Add(BookOrder);

            // Assert
            result.DiscountPercentage.ShouldBe(0.10m);
        }

        [Test]
        public void BookOrderService_Add_No_Loyalty_Discount()
        {
            // Arrange
            var BookOrder = new BookOrder() { Id = 1, BookId = 2, CustomerId = 1, ShippingProviderId = 4, Description = "None", IsActive = true, Name = "0 Discount", Quantity = 1 };

            // Act
            var result = BookOrderService.Add(BookOrder);

            // Assert
            result.DiscountPercentage.ShouldBe(0);
        }

        [Test]
        public void BookOrderService_Add_Loyalty_Discount()
        {
            // Arrange
            var BookOrder = new BookOrder() { Id = 1, BookId = 2, CustomerId = 2, ShippingProviderId = 4, Description = "None", IsActive = true, Name = "0 Discount", Quantity = 1 };

            // Act
            var result = BookOrderService.Add(BookOrder);

            // Assert
            result.DiscountPercentage.ShouldBe(0.05m);
        }

        [Test]
        public void BookOrderService_Add_No_Newly_Published_Discount()
        {
            // Arrange
            var BookOrder = new BookOrder() { Id = 1, BookId = 2, CustomerId = 1, ShippingProviderId = 4, Description = "None", IsActive = true, Name = "0 Discount", Quantity = 1 };

            // Act
            var result = BookOrderService.Add(BookOrder);

            // Assert
            result.DiscountPercentage.ShouldBe(0);
        }

        [Test]
        public void BookOrderService_Add_Newly_Published_Discount()
        {
            // Arrange
            var BookOrder = new BookOrder() { Id = 1, BookId = 1, CustomerId = 1, ShippingProviderId = 4, Description = "None", IsActive = true, Name = "0 Discount", Quantity = 1 };

            // Act
            var result = BookOrderService.Add(BookOrder);

            // Assert
            result.DiscountPercentage.ShouldBe(0.10m);
        }

        [Test]
        public void BookOrderService_Add_No_Shipping_Provider_Discount()
        {
            // Arrange
            var BookOrder = new BookOrder() { Id = 1, BookId = 2, CustomerId = 1, ShippingProviderId = 4, Description = "None", IsActive = true, Name = "0 Discount", Quantity = 1 };

            // Act
            var result = BookOrderService.Add(BookOrder);

            // Assert
            result.DiscountPercentage.ShouldBe(0);
        }

        [Test]
        public void BookOrderService_Add_UPS_Discount()
        {
            // Arrange
            var BookOrder = new BookOrder() { Id = 1, BookId = 2, CustomerId = 1, ShippingProviderId = 2, Description = "None", IsActive = true, Name = "0 Discount", Quantity = 1 };

            // Act
            var result = BookOrderService.Add(BookOrder);

            // Assert
            result.DiscountPercentage.ShouldBe(0.05m);
        }

        [Test]
        public void BookOrderService_Add_USPS_Discount()
        {
            // Arrange
            var BookOrder = new BookOrder() { Id = 1, BookId = 2, CustomerId = 1, ShippingProviderId = 1, Description = "None", IsActive = true, Name = "0 Discount", Quantity = 1 };

            // Act
            var result = BookOrderService.Add(BookOrder);

            // Assert
            result.DiscountPercentage.ShouldBe(0.01m);
        }

        [Test]
        public void BookOrderService_Add_Fedex_Discount()
        {
            // Arrange
            var BookOrder = new BookOrder() { Id = 1, BookId = 2, CustomerId = 1, ShippingProviderId = 3, Description = "None", IsActive = true, Name = "0 Discount", Quantity = 1 };

            // Act
            var result = BookOrderService.Add(BookOrder);

            // Assert
            result.DiscountPercentage.ShouldBe(0.03m);
        }
    }
}
