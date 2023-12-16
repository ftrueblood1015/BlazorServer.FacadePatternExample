using System.ComponentModel.DataAnnotations;

namespace BlazorServer.FacadePatternExample.Domain.Models
{
    public class ModelBase
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Description { get; set; }

        [Required]
        public Boolean? IsActive { get; set; }
    }
}
