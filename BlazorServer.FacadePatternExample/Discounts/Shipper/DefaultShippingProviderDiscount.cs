namespace BlazorServer.FacadePatternExample.Discounts.Shipper
{
    public class DefaultShippingProviderDiscount : IShippingProviderDiscount
    {
        public decimal DiscountPercentage => 0;
    }
}
