using BlazorServer.FacadePatternExample.Domain.Models;

namespace BlazorServer.FacadePatternExample.Discounts.NewlyPublished
{
    public class NewlyPublishedDiscountFactory : INewlyPublishedDiscountFactory
    {
        private Book Book { get; set; }

        public NewlyPublishedDiscountFactory(Book book)
        {
            Book = book;
        }
        public INewlyPublishedDiscount CreateNewlyPublishedDiscountService()
        {
            int YearsSincePublish = DateTime.Now.Year - (int)Book.PublishYear!;

            switch (YearsSincePublish)
            {
                default:
                    return new DefualtNewlyPublishedDiscount();
                case 0:
                    return new PublishedCurrentYearDiscount();
            }
        }
    }
}
