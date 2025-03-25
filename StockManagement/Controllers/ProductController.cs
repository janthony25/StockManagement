using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using StockManagement.Models.Dto;
using StockManagement.Repository.IRepository;

namespace StockManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductRepository repository, ILogger<ProductController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("products")]
        public async Task<IActionResult> GetProductList()
        {
            try
            {
                var products = await _repository.GetProductsAsync();

                return Ok(products);    
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching products.");
                return StatusCode(500, "Internal Server Error.");
            }
        }

        [HttpPost("add-item")]
        public async Task<IActionResult> AddItem(AddProductDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _repository.AddProductAsync(dto);
                return Ok("Item successfuly added.");

            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding new item.");
                return StatusCode(500, "An error occurred while adding new item.");
            }
        }

        [HttpGet("item/{id}")]
        public async Task<IActionResult> GetItemById(int id)
        {
            try
            {
                var product = await _repository.GetProductByIdAsync(id);

                return Ok(product);
            }
            catch(KeyNotFoundException)
            {
                // test if github working already
                return NotFound("Product not found.");
            }
            catch(Exception)
            {
                return StatusCode(500, "An error occurred while fetcing item details.");
            }
        }
    }
}
