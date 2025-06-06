using WebMarket.DTOs;

namespace WebMarket.Services
{
    public interface IPurchaseService
    {
        public List<UserPurchasesDto>? GetPurchases();
        public ResultDto CreatePurchase(CreatePurchaseDto purchaseDto);
    }
}
