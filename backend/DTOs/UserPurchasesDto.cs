namespace WebMarket.DTOs
{
    public class UserPurchasesDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public decimal? OldPrice { get; set; }
    }
}
