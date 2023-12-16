using Microsoft.AspNetCore.Components;

namespace BlazorServer.FacadePatternExample.Pages.Authors
{
    public partial class AuthorDetail
    {
        [Parameter]
        public int AuthorId { get; set; }
    }
}
