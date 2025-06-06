using System;

namespace WebMarket.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string LicenseKey { get; set; }

        // Навігаційна властивість для зв’язку з продуктом
        public Product Product { get; set; }
    }
}
