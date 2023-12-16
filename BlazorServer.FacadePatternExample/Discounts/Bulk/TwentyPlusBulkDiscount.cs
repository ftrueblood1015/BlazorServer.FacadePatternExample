namespace BlazorServer.FacadePatternExample.Discounts.Bulk
{
    public class TwentyPlusBulkDiscount : IBulkDiscount
    {
        decimal IBulkDiscount.DiscountPercentage => 0.10m;
    }
}
