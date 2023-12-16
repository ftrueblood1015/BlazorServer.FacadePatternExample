using BlazorServer.FacadePatternExample.Domain.Models;
using BlazorServer.FacadePatternExample.Services.Books;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorServer.FacadePatternExample.Pages.Books
{
    public partial class BookSummary
    {
        private string Title = "Books";

        [Inject]
        private IBookService? Service { get; set; }

        [Inject]
        private NavigationManager? NavigationManager { get; set; }

        [Inject]
        private IDialogService? DialogService { get; set; }

        [Inject]
        private ISnackbar? SnackbarService { get; set; }

        public List<Book>? Entities { get; set; }

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
            Entities = Response != null ? Response.ToList() : new List<Book>();
            StateHasChanged();
        }

        private Func<Book, bool> QuickFilter => x =>
        {
            if (string.IsNullOrWhiteSpace(SearchString))
                return true;

            if (x.Name!.Contains(SearchString, StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        };

        public void Add()
        {
            if (NavigationManager == null)
            {
                throw new Exception($"{nameof(NavigationManager)}  is null!");
            }

            NavigationManager.NavigateTo("/bookdetail");
        }

        private async void OnDeleteClicked(Book Item)
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

        private bool Delete(Book Item)
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

        private void Edit(Book Item)
        {
            if (NavigationManager == null)
            {
                throw new ArgumentNullException(nameof(NavigationManager));
            }

            NavigationManager.NavigateTo($"/bookdetail/{Item.Id}");
        }
    }
}
