namespace StockManagement.Models.Dto
{
    public class AddProductDto
    {
        public string? Brand { get; set; }
        public string ProductName { get; set; }
        public int QuantityStock { get; set; }
        public decimal GettingPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public string Status { get; set; }
        public int CategoryId { get; set; }
    }
}
