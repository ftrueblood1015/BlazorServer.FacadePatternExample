using System.ComponentModel.DataAnnotations;

namespace BlazorServer.FacadePatternExample.Domain.Models
{
    public class BookOrder : ModelBase
    {
        [Required]
        public int? BookId { get; set; }

        [Required]
        public int? ShippingProviderId { get; set; }

        [Required]
        public int? CustomerId { get; set; }

        [Required]
        public decimal? DiscountTotal { get; set; }

        [Required]
        public decimal? DiscountPercentage { get; set; }

        [Required]
        public decimal? Total { get; set; }

        [Required]
        public int? Quantity { get; set; }

        public Book? Book { get; set; }

        public Customer? Customer { get; set; }

        public ShippingProvider? ShippingProvider { get; set; }
    }
}
