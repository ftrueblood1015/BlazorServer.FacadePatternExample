namespace BlazorServer.FacadePatternExample.Discounts.NewlyPublished
{
    public class PublishedCurrentYearDiscount : INewlyPublishedDiscount
    {
        public decimal DiscountPercentage => 0.10m;
    }
}
