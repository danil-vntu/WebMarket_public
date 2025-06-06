using System.ComponentModel.DataAnnotations;

namespace WebMarket.DTOs
{
    public class UpdatePriceDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
