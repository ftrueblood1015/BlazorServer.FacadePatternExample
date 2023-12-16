using BlazorServer.FacadePatternExample.Domain.Models;
using BlazorServer.FacadePatternExample.Repositories;
using BlazorServer.FacadePatternExample.Repositories.ShippingProviders;

namespace BlazorServer.FacadePatternExample.Services.ShippingProviders
{
    public class ShippingProviderService : ServiceBase<ShippingProvider, IShippingProviderRepository>, IShippingProviderService
    {
        public ShippingProviderService(IRepositoryBase<ShippingProvider> repo) : base(repo)
        {
        }
    }
}
