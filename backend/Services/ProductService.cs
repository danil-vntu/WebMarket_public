using AutoMapper;
using WebMarket.Data;
using WebMarket.DTOs;

namespace WebMarket.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ProductService (AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ProductDto>? GetAll()
        {
            var products = _context.Products.ToList();
            if (products == null)
            {
                return null;
            }
            List<ProductDto> productDtos = _mapper.Map<List<ProductDto>>(products);
            return productDtos;
        }

        public ProductDto? GetById(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return null;
            }
            var productDto = _mapper.Map<ProductDto>(product);
            return productDto;
        }



        public ResultDto Promote(int id)
        {
            if (id <= 0)
            {
                return new ResultDto
                {
                    Success = false,
                    Message = "Invalid product ID."
                };
            }

            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return new ResultDto
                {
                    Success = false,
                    Message = "Product not found."
                };
            }
            if (product.IsPromoted)
            {
                return new ResultDto
                {
                    Success = false,
                    Message = "Product is already promoted."
                };
            }
            product.IsPromoted = true;
            _context.SaveChanges();

            return new ResultDto
            {
                Success = true,
                Message = "Product promoted successfully."
            };
        }

        public ResultDto UpdatePrice(UpdatePriceDto updatePriceDto)
        {
            var id = updatePriceDto.Id;
            var price = updatePriceDto.Price;
            if (id <= 0)
            {
                return new ResultDto
                {
                    Success = false,
                    Message = "Invalid product ID."
                };
            }
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return new ResultDto
                {
                    Success = false,
                    Message = "Product not found."
                };
            }
            product.Price = price;
            _context.SaveChanges();
            return new ResultDto
            {
                Success = true,
                Message = "Product price updated successfully."
            };
        }

        public List<ProductDto>? GetPromoted()
        {
            var product = _context.Products.Where(p => p.IsPromoted).ToList();
            if (product == null)
            {
                return null;
            }
            List<ProductDto> productDto = _mapper.Map<List<ProductDto>>(product);
            return productDto;
        }

        public ResultDto Unpromote(int id)
        {
            if (id <= 0)
            {
                return new ResultDto
                {
                    Success = false,
                    Message = "Invalid product ID."
                };
            }
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            
            if (product == null)
            {
                return new ResultDto
                {
                    Success = false,
                    Message = "Product not found."
                };
            }
            if (!product.IsPromoted)
            {
                return new ResultDto
                {
                    Success = false,
                    Message = "Product is not promoted."
                };
            }
            product.IsPromoted = false;
            _context.SaveChanges();
            return new ResultDto
            {
                Success = true,
                Message = "Product unpromoted successfully."
            };
        }

    }
}
