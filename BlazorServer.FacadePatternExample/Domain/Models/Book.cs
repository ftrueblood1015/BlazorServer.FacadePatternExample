using System.ComponentModel.DataAnnotations;

namespace BlazorServer.FacadePatternExample.Domain.Models
{
    public class Book : ModelBase
    {
        [Required]
        public int? AuthorId { get; set; }

        [Required]
        public int? GenreId { get; set; }

        [Required]
        public int? PublishYear { get; set; }

        public int? Price { get; set; }

        public Author? Author { get; set; }

        public Genre? Genre { get; set;}
    }
}
