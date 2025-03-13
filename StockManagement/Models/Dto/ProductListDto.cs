namespace StockManagement.Models.Dto
{
    public class ProductListDto
    {
        public int ProductId { get; set; }
        public string? ImageUrl { get; set; }
        public string ProductName { get; set; }
        public int QuantityStock { get; set; }
        public decimal SellingPrice { get; set; }
        public string Status { get; set; }
    }
}
