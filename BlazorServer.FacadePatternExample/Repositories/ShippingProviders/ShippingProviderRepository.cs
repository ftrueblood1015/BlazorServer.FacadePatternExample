using BlazorServer.FacadePatternExample.Domain.Models;
using BlazorServer.FacadePatternExample.Infrastructure;

namespace BlazorServer.FacadePatternExample.Repositories.ShippingProviders
{
    public class ShippingProviderRepository : RepositoryBase<ShippingProvider, FacadePatternContext>, IShippingProviderRepository
    {
        public ShippingProviderRepository(FacadePatternContext context) : base(context)
        {
        }
    }
}
