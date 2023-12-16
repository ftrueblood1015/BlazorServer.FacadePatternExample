using BlazorServer.FacadePatternExample.Domain.Models;
using BlazorServer.FacadePatternExample.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorServer.FacadePatternExample.Pages.Books
{
    public partial class BookDetail
    {
        [Inject]
        private IServiceBase<Book>? Service { get; set; }

        [Inject]
        private NavigationManager? NavigationManager { get; set; }

        [Inject]
        private ISnackbar? SnackbarService { get; set; }

        public string? Title = "Book Detail";

        [Parameter]
        public int BookId { get; set; }

        private Book? Entity { get; set; }

        private bool success;

        private string[] errors = { };

        private MudForm? Form;

        protected override async Task OnInitializedAsync()
        {
            SetEntity();
        }

        public void SetEntity()
        {
            if (BookId == 0)
            {
                Entity = new Book() { };
            }
            else
            {
                Entity = GetEntity(BookId);
            }
        }

        private void CancelClick()
        {
            if (NavigationManager != null)
            {
                NavigationManager.NavigateTo("/booksummary");
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

            if (BookId == 0)
            {
                Add(Entity!);
            }
            else
            {
                Update(Entity!);
            }
        }

        private void Add(Book Entity)
        {
            try
            {
                Entity = Service!.Add(Entity!);
                success = true;
                StateHasChanged();
                ShowSnackbarMessage($"Added New {Title}", Color.Success);
                CancelClick();
            }
            catch(Exception ex)
            {
                success = false;
                throw new Exception(ex.Message);
            }

        }

        private void Update(Book Entity)
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

        public Book GetEntity(int Id)
        {
            if (Service == null)
            {
                throw new ArgumentNullException(nameof(Service));
            }

            return Service.GetById(Id) ?? new Book() { };
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

        public async Task GenreChange(int? Id)
        {
            Entity!.GenreId = Id;
        }

        public async Task AuthorChange(int? Id)
        {
            Entity!.AuthorId = Id;
        }
    }
}
