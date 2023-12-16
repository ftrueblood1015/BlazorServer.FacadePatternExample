namespace BlazorServer.FacadePatternExample.Discounts.CustomerLoyalty
{
    public class FiveYearLoyaltyDiscount : ILoyaltyDiscount
    {
        public decimal DiscountPercentage => 0.05m;
    }
}
