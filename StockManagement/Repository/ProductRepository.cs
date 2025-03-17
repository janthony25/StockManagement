using Microsoft.EntityFrameworkCore;
using StockManagement.Data;
using StockManagement.Models;
using StockManagement.Models.Dto;
using StockManagement.Repository.IRepository;

namespace StockManagement.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _data;
        private readonly ILogger<ProductRepository> _logger;

        public ProductRepository(DataContext data, ILogger<ProductRepository> logger)
        {
            _data = data;
            _logger = logger;
        }

        public ILogger<ProductRepository> Logger { get; }

        public async Task AddProductAsync(AddProductDto dto)
        {
            try
            {

                var categoryExists = await _data.Categories.AnyAsync(c => c.CategoryId == dto.CategoryId);
                if (!categoryExists)
                {
                    throw new Exception("Invalid Category");
                }

                var product = new Product
                {
                    Brand = dto.Brand,
                    ProductName = dto.ProductName,
                    QuantityStock = dto.QuantityStock,
                    GettingPrice = dto.GettingPrice,
                    SellingPrice = dto.SellingPrice,
                    Status = dto.Status,
                    CategoryId = dto.CategoryId
                };

                _data.Products.Add(product);
                await _data.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding new product.");
                throw;
            }
        }

        public async Task<List<ProductListDto>> GetProductsAsync()
        {
            try
            {
                var products = await _data.Products
                            .OrderByDescending(p => p.DateAdded)
                            .Select(p => new ProductListDto
                            {
                                ProductId = p.ProductId,
                                ProductName = p.ProductName,
                                QuantityStock = p.QuantityStock,
                                SellingPrice = p.SellingPrice,
                                Status = p.Status
                            }).ToListAsync();

                return products;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching products.");
                throw;
            }
        }
    }
}
