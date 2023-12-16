namespace BlazorServer.FacadePatternExample.Discounts.Bulk
{
    public class BaseBulkDiscount : IBulkDiscount
    {
        decimal IBulkDiscount.DiscountPercentage => 0;
    }
}
