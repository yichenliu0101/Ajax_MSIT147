namespace WebApi.Models.DTO
{
    public class ProductMinDto
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
    }
}
