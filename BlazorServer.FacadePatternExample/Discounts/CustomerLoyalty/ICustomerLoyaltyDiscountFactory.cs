namespace BlazorServer.FacadePatternExample.Discounts.CustomerLoyalty
{
    public interface ICustomerLoyaltyDiscountFactory
    {
        ILoyaltyDiscount CreateLoyaltyDiscountService();
    }
}
