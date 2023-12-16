using BlazorServer.FacadePatternExample.Domain.Models;

namespace BlazorServer.FacadePatternExample.Discounts.Bulk
{
    public class BulkDiscountFactory : IBulkDiscountFactory
    {
        BookOrder Order { get; set; }
        public BulkDiscountFactory(BookOrder order)
        {
            Order = order;
        }

        public IBulkDiscount CreateBulkDiscountService()
        {
            switch (Order.Quantity)
            {
                default:
                    return new BaseBulkDiscount();
                case int x when (5 <= x && x <= 9):
                    return new FiveToNineBulkDiscount();
                case int x when (10 <= x && x <= 19):
                    return new TenToNineteenBulkDiscount();
                case int x when (x >= 20):
                    return new TwentyPlusBulkDiscount();
            }
        }
    }
}
