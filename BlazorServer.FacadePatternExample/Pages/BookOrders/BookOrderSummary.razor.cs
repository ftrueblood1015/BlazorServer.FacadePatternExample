using BlazorServer.FacadePatternExample.Domain.Models;
using BlazorServer.FacadePatternExample.Services.BookOrders;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorServer.FacadePatternExample.Pages.BookOrders
{
    public partial class BookOrderSummary
    {
        private string Title = "Orders";

        [Inject]
        private IBookOrderService? Service { get; set; }

        [Inject]
        private NavigationManager? NavigationManager { get; set; }

        [Inject]
        private ISnackbar? SnackbarService { get; set; }

        public List<BookOrder>? Entities { get; set; }

        private string? SearchString { get; set; }

        protected override async Task OnInitializedAsync()
        {
            GetData();
        }

        public void GetData()
        {
            if (Service == null)
            {
                throw new Exception($"{nameof(Service)}  is null!");
            }
            var Response = Service.GetAll();
            Entities = Response != null ? Response.ToList() : new List<BookOrder>();
            StateHasChanged();
        }

        private Func<BookOrder, bool> QuickFilter => x =>
        {
            if (string.IsNullOrWhiteSpace(SearchString))
                return true;

            if (x.Name!.Contains(SearchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if (x.Customer!.Name!.Contains(SearchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if (x.ShippingProvider!.Name!.Contains(SearchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if (x.Book!.Name!.Contains(SearchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if ($"{x.DiscountPercentage}".Contains(SearchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if ($"{x.DiscountTotal}".Contains(SearchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if ($"{x.Total}".Contains(SearchString, StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        };

        public void Add()
        {
            if (NavigationManager == null)
            {
                throw new Exception($"{nameof(NavigationManager)}  is null!");
            }

            NavigationManager.NavigateTo("/bookorderdetail");
        }

        public void ShowSnackbarMessage(string Message, MudBlazor.Color Color)
        {
            if (SnackbarService == null)
            {
                throw new ArgumentNullException(nameof(SnackbarService));
            }

            SnackbarService.Add<MudChip>(new Dictionary<string, object>() {
                { "Text", $"{Message}" },
                { "Color", Color }
            });
        }
    }
}
