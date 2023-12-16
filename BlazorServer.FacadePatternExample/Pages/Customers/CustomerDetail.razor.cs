using BlazorServer.FacadePatternExample.Domain.Models;
using BlazorServer.FacadePatternExample.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorServer.FacadePatternExample.Pages.Customers
{
    public partial class CustomerDetail
    {
        [Inject]
        private IServiceBase<Customer>? Service { get; set; }

        [Inject]
        private NavigationManager? NavigationManager { get; set; }

        [Inject]
        private ISnackbar? SnackbarService { get; set; }

        public string? Title = "Customer Detail";

        [Parameter]
        public int CustomerId { get; set; }

        private Customer? Entity { get; set; }

        private bool success;

        private string[] errors = { };

        private MudForm? Form;

        protected override async Task OnInitializedAsync()
        {
            SetEntity();
        }

        public void SetEntity()
        {
            if (CustomerId == 0)
            {
                Entity = new Customer() { };
            }
            else
            {
                Entity = GetEntity(CustomerId);
            }
        }

        private void CancelClick()
        {
            if (NavigationManager != null)
            {
                NavigationManager.NavigateTo("/customersummary");
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

            if (CustomerId == 0)
            {
                Add(Entity!);
            }
            else
            {
                Update(Entity!);
            }
        }

        private void Add(Customer Entity)
        {
            try
            {
                Entity.CustomerSince = DateTime.Now;
                Entity = Service!.Add(Entity!);
                success = true;
                StateHasChanged();
                ShowSnackbarMessage($"Added New {Title}", Color.Success);
                CancelClick();
            }
            catch
            {
                success = false;
                ShowSnackbarMessage($"Could Not Add {Title}", Color.Error);
            }

        }

        private void Update(Customer Entity)
        {
            try
            {
                Entity = Service!.Update(Entity!);
                success = true;
                StateHasChanged();
                ShowSnackbarMessage($"Updated New {Title}", Color.Success);
                CancelClick();
            }
            catch
            {
                success = false;
                ShowSnackbarMessage($"Could Not Update {Title}", Color.Error);
            }

        }

        public Customer GetEntity(int Id)
        {
            if (Service == null)
            {
                throw new ArgumentNullException(nameof(Service));
            }

            return Service.GetById(Id) ?? new Customer() { };
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
