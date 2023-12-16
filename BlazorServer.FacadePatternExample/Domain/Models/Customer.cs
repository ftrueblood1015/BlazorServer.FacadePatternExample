using System.ComponentModel.DataAnnotations;

namespace BlazorServer.FacadePatternExample.Domain.Models
{
    public class Customer : ModelBase
    {
        [Required]
        public DateTime CustomerSince { get; set; }

        [Required]
        public string? Country { get; set; }

        [Required]
        public string? Address { get; set; }
    }
}
