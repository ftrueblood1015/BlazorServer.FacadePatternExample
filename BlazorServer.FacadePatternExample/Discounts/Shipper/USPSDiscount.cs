namespace BlazorServer.FacadePatternExample.Discounts.Shipper
{
    public class USPSDiscount : IShippingProviderDiscount
    {
        public decimal DiscountPercentage => 0.01m;
    }
}
