using StockManagement.Models.Dto;

namespace StockManagement.Repository.IRepository
{
    public interface ICategoryRepository
    {
        Task<List<CategoryDto>> GetCategoriesAsync();
    }
}
