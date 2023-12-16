using Microsoft.AspNetCore.Components;

namespace BlazorServer.FacadePatternExample.Pages.Genres
{
    public partial class GenreDetail
    {
        [Parameter]
        public int GenreId { get; set; }
    }
}
