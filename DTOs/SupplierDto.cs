namespace InventoryManagementApi.DTOs
{
    public class SupplierDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // Add default to fix warning
    }
}
