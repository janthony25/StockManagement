using StockManagement.Models.Dto;

namespace StockManagement.Repository.IRepository
{
    public interface IProductRepository
    {
        Task<List<ProductListDto>> GetProductsAsync();
        Task AddProductAsync(AddProductDto dto);
        Task<GetProductDto> GetProductByIdAsync(int id);
    }
}
