using Microsoft.EntityFrameworkCore;
using StockManagement.Data;
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

        public async Task<List<ProductListDto>> GetProductsAsync()
        {
            try
            {
                var products = await _data.Products
                            .Select(p => new ProductListDto
                            {
                                ProductId = p.ProductId,
                                ImageUrl = p.ImageUrl,
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
