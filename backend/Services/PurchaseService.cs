using AutoMapper;

using WebMarket.DTOs;
using WebMarket.Data;
using WebMarket.Models;
using Microsoft.EntityFrameworkCore;

namespace WebMarket.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public PurchaseService(AppDbContext context, IMapper mapper, IAuthService authService, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _authService = authService;
            _httpContextAccessor = httpContextAccessor;
        }
        public List<UserPurchasesDto>? GetPurchases()
        {
            var currentUserId = _httpContextAccessor.HttpContext?.Session?.GetInt32("UserId");
            var purchases = _context.Purchases
                .Include(p => p.Product)
                .Where(p => p.UserId == currentUserId)
                .ToList();
            List<UserPurchasesDto> purchaseResult = _mapper.Map<List<UserPurchasesDto>>(purchases);
            if (purchaseResult == null || purchaseResult.Count == 0)
            {
                return new List<UserPurchasesDto>(); 
            }
            return purchaseResult;
        }

        public ResultDto CreatePurchase(CreatePurchaseDto purchaseDto)
        {
            var currentUserId = _httpContextAccessor.HttpContext?.Session?.GetInt32("UserId");

            if (currentUserId == null || currentUserId <= 0)
            {
                return new ResultDto
                {
                    Success = false,
                    Message = "Користувач не авторизований!"
                };
            }

            if (purchaseDto == null || purchaseDto.Items == null || purchaseDto.Items.Count == 0)
            {
                return new ResultDto
                {
                    Success = false,
                    Message = "Невірні дані покупки!"
                };
            }

            var licenseKeys = new List<string>();

            foreach (var item in purchaseDto.Items)
            {
                var product = _context.Products.Find(item.ProductId);
                if (product == null)
                {
                    return new ResultDto
                    {
                        Success = false,
                        Message = $"Продукт із ID {item.ProductId} не знайдено"
                    };
                }

                for (int i = 0; i < item.Quantity; i++)
                {
                    var key = Guid.NewGuid().ToString();

                    var purchase = new Purchase
                    {
                        UserId = currentUserId.Value,
                        ProductId = item.ProductId,
                        Quantity = 1,
                        TotalPrice = item.Price,
                        PurchaseDate = DateTime.Now,
                        LicenseKey = key
                    };

                    _context.Purchases.Add(purchase);

                    licenseKeys.Add(purchase.LicenseKey);
                }
            }
            var lastKey = licenseKeys.LastOrDefault();

            
            _context.SaveChanges();

            return new ResultDto
            {
                Success = true,
                Message = $"Покупку завершено, ваш ключ продукту: {lastKey}"
            };
        }
    }
}
