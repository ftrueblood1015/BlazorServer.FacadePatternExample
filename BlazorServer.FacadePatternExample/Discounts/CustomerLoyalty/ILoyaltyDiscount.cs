namespace BlazorServer.FacadePatternExample.Discounts.CustomerLoyalty
{
    public interface ILoyaltyDiscount
    {
        decimal DiscountPercentage { get; }
    }
}
