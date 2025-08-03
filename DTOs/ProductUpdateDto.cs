namespace InventoryManagementApi.DTOs
{
    public class ProductUpdateDto
    {
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
    }
}
