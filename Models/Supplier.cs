using System.Collections.Generic;

namespace InventoryManagementApi.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Product> Products { get; set; } = new();
    }
}
