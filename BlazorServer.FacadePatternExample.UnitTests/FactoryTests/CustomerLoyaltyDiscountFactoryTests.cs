using BlazorServer.FacadePatternExample.Discounts.CustomerLoyalty;
using BlazorServer.FacadePatternExample.Domain.Models;
using Shouldly;

namespace BlazorServer.FacadePatternExample.UnitTests.FactoryTests
{
    public class CustomerLoyaltyDiscountFactoryTests
    {
        DateTime Today { get; set; }


        public CustomerLoyaltyDiscountFactoryTests()
        {
            Today = DateTime.Now;
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void CustomerLoyaltyDiscount_No_Discount(int years)
        {
            // Arrange
            var Customer = new Customer() { Id = 1, CustomerSince = Today.AddYears(years * -1) };

            // Act 
            var result = new CustomerLoyaltyDiscountFactory(Customer).CreateLoyaltyDiscountService().DiscountPercentage;

            // Assert
            result.ShouldBe(0);
        }

        [TestCase(5)]
        [TestCase(6)]
        [TestCase(10)]
        [TestCase(15)]
        public void CustomerLoyaltyDiscount_5_Year_Discount(int years)
        {
            // Arrange
            var Customer = new Customer() { Id = 1, CustomerSince = Today.AddYears(years * -1) };

            // Act 
            var result = new CustomerLoyaltyDiscountFactory(Customer).CreateLoyaltyDiscountService().DiscountPercentage;

            // Assert
            result.ShouldBe(0.05m);
        }
    }
}
