namespace StockManagement.Models.Dto
{
    public class GetProductDto
    {
        public int ProductId { get; set; }
        public string? Brand { get; set; }
        public string ProductName { get; set; }
        public int QuantityStock { get; set; }
        public decimal GettingPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now;
        public DateTime? LastUpdated { get; set; }
        public string Status { get; set; }
        public string? CategoryName { get; set; }

    }
}
