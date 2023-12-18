using BlazorServer.FacadePatternExample.Discounts.NewlyPublished;
using BlazorServer.FacadePatternExample.Domain.Models;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServer.FacadePatternExample.UnitTests.FactoryTests
{
    public class NewlyPublishedDiscountFactoryTests
    {
        int CurrentYear {  get; set; }

        public NewlyPublishedDiscountFactoryTests()
        {
            CurrentYear = DateTime.Now.Year;
        }

        [TestCase(-1)]
        [TestCase(1)]
        public void NewlyPublishedDiscountFactory_No_Discount(int YearModifier)
        {
            // Arrange
            Book book = new Book() { Id = 1, PublishYear = CurrentYear + YearModifier};

            // Act
            var result = new NewlyPublishedDiscountFactory(book).CreateNewlyPublishedDiscountService().DiscountPercentage;

            // Assert
            result.ShouldBe(0);
        }

        [Test]
        public void NewlyPublishedDiscountFactory_Current_Year_Discount()
        {
            // Arrange
            Book book = new Book() { Id = 1, PublishYear = CurrentYear };

            // Act
            var result = new NewlyPublishedDiscountFactory(book).CreateNewlyPublishedDiscountService().DiscountPercentage;

            // Assert
            result.ShouldBe(0.10m);
        }
    }
}
