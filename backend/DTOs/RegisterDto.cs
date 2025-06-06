using System.ComponentModel.DataAnnotations;

namespace WebMarket.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string Name {  get; set; }
        [Required]
        public string Email { get; set; }
        [Required]        
        public string Password { get; set; }
    }
}
