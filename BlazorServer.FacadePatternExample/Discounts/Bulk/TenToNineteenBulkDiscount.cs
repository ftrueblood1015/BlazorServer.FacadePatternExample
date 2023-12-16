namespace BlazorServer.FacadePatternExample.Discounts.Bulk
{
    public class TenToNineteenBulkDiscount : IBulkDiscount
    {
        decimal IBulkDiscount.DiscountPercentage => 0.05m;
    }
}
