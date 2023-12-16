using BlazorServer.FacadePatternExample.Domain.Models;
using BlazorServer.FacadePatternExample.Services;
using BlazorServer.FacadePatternExample.Services.Customers;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorServer.FacadePatternExample.Pages.Customers
{
    public partial class CustomerSummary
    {
        private string Title = "Customers";

        [Inject]
        private ICustomerService? Service { get; set; }

        [Inject]
        private NavigationManager? NavigationManager { get; set; }

        [Inject]
        private IDialogService? DialogService { get; set; }

        [Inject]
        private ISnackbar? SnackbarService { get; set; }

        public List<Customer>? Entities { get; set; }

        private string? SearchString { get; set; }

        string state = "Message box hasn't been opened yet";

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
            Entities = Response != null ? Response.ToList() : new List<Customer>();
            StateHasChanged();
        }

        private Func<Customer, bool> QuickFilter => x =>
        {
            if (string.IsNullOrWhiteSpace(SearchString))
                return true;

            if (x.Address!.Contains(SearchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if (x.Name!.Contains(SearchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if (x.Country!.Contains(SearchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if ($"{x.CustomerSince}".Contains(SearchString, StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        };

        public void Add()
        {
            if (NavigationManager == null)
            {
                throw new Exception($"{nameof(NavigationManager)}  is null!");
            }

            NavigationManager.NavigateTo("/customerdetail");
        }

        private async void OnDeleteClicked(Customer Item)
        {
            if (DialogService == null)
            {
                throw new Exception($"{nameof(DialogService)}  is null!");
            }

            bool? result = await DialogService.ShowMessageBox(
                "Warning",
                "Deleting can not be undone!",
                yesText:"Delete!", cancelText:"Cancel"
            );

            state = result == null ? "Canceled" : "Deleted!";

            if (state == "Canceled")
            {
                StateHasChanged();
            }
            else
            {
                Delete(Item);
                GetData();
            }
        }

        private bool Delete(Customer Item)
        {
            if (Service == null)
            {
                throw new Exception($"{nameof(Service)} is null!");
            }

            try
            {
                var result = Service.Delete(Item);

                if (result)
                {
                    ShowSnackbarMessage($"Deleted {Title}", Color.Success);
                }
                else
                {
                    ShowSnackbarMessage($"Could Not Delete {Title}", Color.Error);
                }

                return result;
            }
            catch (Exception ex)
            {
                ShowSnackbarMessage($"Could Not Delete {Title}: {ex}", Color.Error);
                return false;
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

        private void Edit(Customer Item)
        {
            if (NavigationManager == null)
            {
                throw new ArgumentNullException(nameof(NavigationManager));
            }

            NavigationManager.NavigateTo($"/customerdetail/{Item.Id}");
        }
    }
}
