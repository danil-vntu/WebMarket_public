using WebMarket.DTOs;
namespace WebMarket.Services
{
    public interface IProductService
    {
        public List<ProductDto>? GetAll();
        public ProductDto? GetById(int id);
        public ResultDto Promote(int id);
        public ResultDto UpdatePrice(UpdatePriceDto updatePriceDto);
        public List<ProductDto>? GetPromoted();
        public ResultDto Unpromote(int id);
    }
}
