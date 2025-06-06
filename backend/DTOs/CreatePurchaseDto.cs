namespace WebMarket.DTOs
{
    public class CreatePurchaseDto
    {        
        public List<PurchaseItemDto> Items { get; set; }
    }

    public class PurchaseItemDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
