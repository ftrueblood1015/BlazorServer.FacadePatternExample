using BlazorServer.FacadePatternExample.Discounts.Shipper;
using BlazorServer.FacadePatternExample.Domain.Models;
using Shouldly;

namespace BlazorServer.FacadePatternExample.UnitTests.FactoryTests
{
    public class ShippingProviderDiscountFactoryTests
    {
        public ShippingProviderDiscountFactoryTests()
        {
            
        }

        [Test]
        public void ShippingProviderDiscount_No_Discount() 
        { 
            // Arrange
            ShippingProvider Shipper = new ShippingProvider() { Id = 1, Name = "LOCALPROVIDER"};

            // Act
            var result = new ShippingProviderDiscountFactory(Shipper).CreateShippingProviderDiscountService().DiscountPercentage;

            // Assert
            result.ShouldBe(0);
        }

        [Test]
        public void ShippingProviderDiscount_FEDEX_Discount()
        {
            // Arrange
            ShippingProvider Shipper = new ShippingProvider() { Id = 1, Name = "FEDEX"};

            // Act
            var result = new ShippingProviderDiscountFactory(Shipper).CreateShippingProviderDiscountService().DiscountPercentage;

            // Assert
            result.ShouldBe(0.03m);
        }

        [Test]
        public void ShippingProviderDiscount_UPS_Discount()
        {
            // Arrange
            ShippingProvider Shipper = new ShippingProvider() { Id = 1, Name = "UPS"};

            // Act
            var result = new ShippingProviderDiscountFactory(Shipper).CreateShippingProviderDiscountService().DiscountPercentage;

            // Assert
            result.ShouldBe(0.05m);
        }

        [Test]
        public void ShippingProviderDiscount_USPS_Discount()
        {
            // Arrange
            ShippingProvider Shipper = new ShippingProvider() { Id = 1, Name = "USPS"};

            // Act
            var result = new ShippingProviderDiscountFactory(Shipper).CreateShippingProviderDiscountService().DiscountPercentage;

            // Assert
            result.ShouldBe(0.01m);
        }
    }
}
