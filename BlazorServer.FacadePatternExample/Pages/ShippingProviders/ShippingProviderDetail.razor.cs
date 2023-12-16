using Microsoft.AspNetCore.Components;

namespace BlazorServer.FacadePatternExample.Pages.ShippingProviders
{
    public partial class ShippingProviderDetail
    {
        [Parameter]
        public int ShippingProviderId { get; set; }
    }
}
