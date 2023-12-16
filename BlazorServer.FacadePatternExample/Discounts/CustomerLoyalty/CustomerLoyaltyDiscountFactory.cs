using BlazorServer.FacadePatternExample.Domain.Models;

namespace BlazorServer.FacadePatternExample.Discounts.CustomerLoyalty
{
    public class CustomerLoyaltyDiscountFactory : ICustomerLoyaltyDiscountFactory
    {
        Customer Customer {  get; set; }

        public CustomerLoyaltyDiscountFactory(Customer customer)
        {
            Customer = customer;
        }

        public ILoyaltyDiscount CreateLoyaltyDiscountService()
        {
            int CustomerYears = DateTime.Now.Year - Customer.CustomerSince.Year;
            
            if (CustomerYears < 5)
            {
                return new BaseLoyaltyDiscount();
            }
            else
            {
                return new FiveYearLoyaltyDiscount();
            }
        }
    }
}
