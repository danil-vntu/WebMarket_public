namespace WebMarket.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PasswordHash { get; set; } = default!;
        public string Role { get; set; } = "user"; // "Admin" or "user"
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public User()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

    }
}
