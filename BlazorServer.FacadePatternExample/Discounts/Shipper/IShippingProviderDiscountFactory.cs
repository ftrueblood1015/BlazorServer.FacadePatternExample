namespace BlazorServer.FacadePatternExample.Discounts.Shipper
{
    public interface IShippingProviderDiscountFactory
    {
        IShippingProviderDiscount CreateShippingProviderDiscountService();
    }
}
