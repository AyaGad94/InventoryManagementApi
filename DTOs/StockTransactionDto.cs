namespace InventoryManagementApi.DTOs
{
    public class StockTransactionDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }  // Not nullable
        public int Quantity { get; set; }   // Not nullable
        public string Type { get; set; } = string.Empty; // Add default to fix warning
    }
}
