using System.ComponentModel.DataAnnotations;

namespace StockManagement.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string? ImageUrl { get; set; }

        public string? Brand { get; set; }   

        [Required(ErrorMessage = "Product Name is required")]
        public string ProductName { get; set; }
        public int QuantityStock { get; set; }

        [Required(ErrorMessage = "Getting price is required")]
        public decimal GettingPrice { get; set; }   

        [Required(ErrorMessage = "Selling price is required")]
        public decimal SellingPrice { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now;
        public DateTime? LastUpdated { get; set; }
        public string Status { get; set; }

        // Connection
        public int CategoryId { get; set; }
        public Category Category { get; set; }      
    }
}
