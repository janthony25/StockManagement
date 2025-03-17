using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockManagement.Repository.IRepository;

namespace StockManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repository;

        public CategoryController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("categories")]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var categories = await _repository.GetCategoriesAsync();
                return Ok(categories);
            }
            catch(Exception)
            {
                return StatusCode(500, "Internal Server Error.");
            }
        }
    }
}
