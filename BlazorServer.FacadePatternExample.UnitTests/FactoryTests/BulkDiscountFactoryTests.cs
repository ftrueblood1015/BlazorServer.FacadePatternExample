using BlazorServer.FacadePatternExample.Discounts.Bulk;
using BlazorServer.FacadePatternExample.Domain.Models;
using Shouldly;

namespace BlazorServer.FacadePatternExample.UnitTests.FactoryTests
{
    public class BulkDiscountFactoryTests
    {

        public BulkDiscountFactoryTests()
        {
            
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void BulkDiscountFactoryTest_No_Discount(int quantity)
        {
            // Arrange
            var BookOrder = new BookOrder { Id = 1, Quantity = quantity };

            // Act
            var result = new BulkDiscountFactory(BookOrder).CreateBulkDiscountService().DiscountPercentage;

            // Assert
            result.ShouldBe(0);
        }

        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        public void BulkDiscountFactoryTest_5_to_9_Discount(int quantity)
        {
            // Arrange
            var BookOrder = new BookOrder { Id = 1, Quantity = quantity };

            // Act
            var result = new BulkDiscountFactory(BookOrder).CreateBulkDiscountService().DiscountPercentage;

            // Assert
            result.ShouldBe(0.01m);
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
        public void BulkDiscountFactoryTest_10_to_19_Discount(int quantity)
        {
            // Arrange
            var BookOrder = new BookOrder { Id = 1, Quantity = quantity };

            // Act
            var result = new BulkDiscountFactory(BookOrder).CreateBulkDiscountService().DiscountPercentage;

            // Assert
            result.ShouldBe(0.05m);
        }

        [TestCase(20)]
        [TestCase(30)]
        [TestCase(40)]
        public void BulkDiscountFactoryTest_20_Plus_Discount(int quantity)
        {
            // Arrange
            var BookOrder = new BookOrder { Id = 1, Quantity = quantity };

            // Act
            var result = new BulkDiscountFactory(BookOrder).CreateBulkDiscountService().DiscountPercentage;

            // Assert
            result.ShouldBe(0.10m);
        }
    }
}
