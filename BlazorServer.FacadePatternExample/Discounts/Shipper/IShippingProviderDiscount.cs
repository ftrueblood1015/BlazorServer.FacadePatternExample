namespace BlazorServer.FacadePatternExample.Discounts.Shipper
{
    public interface IShippingProviderDiscount
    {
        decimal DiscountPercentage { get; }
    }
}
