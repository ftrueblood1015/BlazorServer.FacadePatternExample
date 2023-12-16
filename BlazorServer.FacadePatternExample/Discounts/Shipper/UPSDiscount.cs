namespace BlazorServer.FacadePatternExample.Discounts.Shipper
{
    public class UPSDiscount : IShippingProviderDiscount
    {
        public decimal DiscountPercentage => 0.05m;
    }
}
