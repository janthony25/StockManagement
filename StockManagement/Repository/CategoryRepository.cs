using Microsoft.EntityFrameworkCore;
using StockManagement.Data;
using StockManagement.Models.Dto;
using StockManagement.Repository.IRepository;

namespace StockManagement.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _data;
        private readonly ILogger<CategoryRepository> _logger;
        public CategoryRepository(DataContext data, ILogger<CategoryRepository> logger)
        {
            _data = data;
            _logger = logger;
        }


        public async Task<List<CategoryDto>> GetCategoriesAsync()
        {
            try
            {
                var categories = await _data.Categories
                            .Select(c => new CategoryDto
                            {
                                CategoryId = c.CategoryId,
                                CategoryName = c.CategoryName
                            }).ToListAsync();

                return categories;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching categories.");
                throw;
            }
        }
    }
}
