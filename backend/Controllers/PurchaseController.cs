using Microsoft.AspNetCore.Mvc;
using WebMarket.Data;
using WebMarket.DTOs;
using WebMarket.Services;

namespace WebMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IPurchaseService _purchaseService;

        public PurchaseController(AppDbContext context, IPurchaseService purchaseService)
        {
            _context = context;
            _purchaseService = purchaseService;
        }

        [HttpGet]
        public ActionResult<List<UserPurchasesDto>> GetPurchases()
        {
            var purchases = _purchaseService.GetPurchases();
            if (purchases == null || purchases.Count == 0)
            {
                return NotFound();
            }
            return Ok(purchases);
        }

        [HttpPost]
        public IActionResult CreatePurchase([FromBody] CreatePurchaseDto purchaseDto)
        {

            var result = _purchaseService.CreatePurchase(purchaseDto);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }
    }
}
