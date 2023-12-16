namespace BlazorServer.FacadePatternExample.Discounts.Shipper
{
    public class FedexDiscount : IShippingProviderDiscount
    {
        public decimal DiscountPercentage => 0.03m;
    }
}
