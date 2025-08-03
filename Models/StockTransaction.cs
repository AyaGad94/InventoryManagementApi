namespace InventoryManagementApi.Models
{
    public class StockTransaction
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public int Quantity { get; set; }
        public string Type { get; set; } = string.Empty;
    }
}
