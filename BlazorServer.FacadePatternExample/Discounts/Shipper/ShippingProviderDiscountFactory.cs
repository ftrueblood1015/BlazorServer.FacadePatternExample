using BlazorServer.FacadePatternExample.Domain.Models;

namespace BlazorServer.FacadePatternExample.Discounts.Shipper
{
    public class ShippingProviderDiscountFactory : IShippingProviderDiscountFactory
    {
        private ShippingProvider Shipper { get; set; }

        public ShippingProviderDiscountFactory(ShippingProvider shipper)
        {
            Shipper = shipper;
        }

        public IShippingProviderDiscount CreateShippingProviderDiscountService()
        {
            switch (Shipper.Name)
            {
                default:
                    return new DefaultShippingProviderDiscount();
                case "UPS":
                    return new UPSDiscount();
                case "USPS":
                    return new USPSDiscount();
                case "FEDEX":
                    return new FedexDiscount();
            }
        }
    }
}
