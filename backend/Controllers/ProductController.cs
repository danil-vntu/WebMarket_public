using Microsoft.AspNetCore.Mvc;
using WebMarket.Data;
using WebMarket.DTOs;
using WebMarket.Services;

namespace WebMarket.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IProductService _productService;
        private readonly IAuthService _authService;

        public ProductController(AppDbContext context, IProductService productService, IAuthService authService)
        {
            _context = context;
            _productService = productService;
            _authService = authService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            if (_productService.GetAll() == null)
            {
                return NotFound();
            }

            return Ok(_productService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var byId = _productService.GetById(id);
            if (byId == null) return NotFound();
            return Ok(byId);
        }

        
        [HttpPost("promote/{id}")]
        public IActionResult Promote(int id)
        {
            if (!_authService.IsAdmin())
            {
                return StatusCode(403, new { message = "Access denied" });
            }

            var promoteResult = _productService.Promote(id);
            if (!promoteResult.Success)
            {
                return BadRequest(new { message = promoteResult.Message });
            }

            return Ok(new { message = promoteResult.Message });
        }

        
        [HttpPut]
        public IActionResult UpdatePrice([FromBody] UpdatePriceDto updatePriceDto)
        {
            if (!_authService.IsAdmin())
            {
                return StatusCode(403, new { message = "Access denied" });
            }


            var updatePriceResult = _productService.UpdatePrice(updatePriceDto);
            if (!updatePriceResult.Success)
            {
                return BadRequest(new { message = updatePriceResult.Message });
            }
            return Ok(new { message = updatePriceResult.Message });
        }


        [HttpGet("promoted")]
        public ActionResult GetPromoted()
        {
            var promotedProducts = _productService.GetPromoted();
            if (promotedProducts == null)
            {
                return NotFound();
            }
            return Ok(promotedProducts);
        }

        
        [HttpPost("unpromote/{id}")]
        public IActionResult Unpromote(int id)
        {
            if (!_authService.IsAdmin())
            {
                return StatusCode(403, new { message = "Access denied" });
            }

            var unpromoteResult = _productService.Unpromote(id);
            if (!unpromoteResult.Success)
            {
                return BadRequest(new { message = unpromoteResult.Message });
            }
            return Ok(new { message = unpromoteResult.Message });
        }
    }
}