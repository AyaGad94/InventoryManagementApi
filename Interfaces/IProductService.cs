using InventoryManagementApi.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using InventoryManagementApi.Models;

namespace InventoryManagementApi.Interfaces
{
    public interface IProductService
    {
        Task<Product> CreateAsync(ProductCreateDto dto);
        Task<Product?> UpdateAsync(int id, ProductUpdateDto dto);
        Task<Product?> GetByIdAsync(int id);
    }
}
