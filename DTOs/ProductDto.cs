//////////////for returning product data/////////////


namespace InventoryManagementApi.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; } //  Keep this for GET, responses
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}