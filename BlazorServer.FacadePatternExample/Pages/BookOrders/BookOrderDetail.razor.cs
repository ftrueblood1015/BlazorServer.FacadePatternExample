using BlazorServer.FacadePatternExample.Domain.Models;
using BlazorServer.FacadePatternExample.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorServer.FacadePatternExample.Pages.BookOrders
{
    public partial class BookOrderDetail
    {
        [Inject]
        private IServiceBase<BookOrder>? Service { get; set; }

        [Inject]
        private NavigationManager? NavigationManager { get; set; }

        [Inject]
        private ISnackbar? SnackbarService { get; set; }

        public string? Title = "Book Order Detail";

        private BookOrder? Entity { get; set; }

        private bool success;

        private string[] errors = { };

        private MudForm? Form;

        protected override async Task OnInitializedAsync()
        {
            SetEntity();
        }

        public void SetEntity()
        {
            Entity = new BookOrder() { };
        }

        private void CancelClick()
        {
            if (NavigationManager != null)
            {
                NavigationManager.NavigateTo("/bookordersummary");
            }
        }

        private async void Save()
        {
            success = false;
            await Form!.Validate();

            if (!Form!.IsValid)
            {
                ShowSnackbarMessage($"Form Is Invalid, see errors", Color.Error);
                return;
            }

            if (Service == null)
            {
                throw new ArgumentNullException(nameof(Service));
            }

            Add(Entity!);
        }

        private void Add(BookOrder Entity)
        {
            try
            {
                Entity.IsActive = true;
                Entity.Total = 0;
                Entity.DiscountTotal = 0;
                Entity.DiscountPercentage = 0;
                Entity = Service!.Add(Entity!);
                success = true;
                StateHasChanged();
                ShowSnackbarMessage($"Added New {Title}", Color.Success);
                CancelClick();
            }
            catch (Exception ex)
            {
                success = false;
                throw new Exception(ex.Message);
            }

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

        public async Task BookChange(int? Id)
        {
            Entity!.BookId = Id;
        }

        public async Task ShipperChange(int? Id)
        {
            Entity!.ShippingProviderId = Id;
        }

        public async Task CustomerChange(int? Id)
        {
            Entity!.CustomerId = Id;
        }
    }
}

