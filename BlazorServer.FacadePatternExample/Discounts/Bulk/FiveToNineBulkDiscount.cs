namespace BlazorServer.FacadePatternExample.Discounts.Bulk
{
    public class FiveToNineBulkDiscount : IBulkDiscount
    {
        decimal IBulkDiscount.DiscountPercentage => 0.01m;
    }
}
