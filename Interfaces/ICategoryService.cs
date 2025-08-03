using InventoryManagementApi.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryManagementApi.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllAsync();
        Task<CategoryDto?> GetByIdAsync(int id);
        Task<CategoryDto> CreateAsync(CategoryDto categoryDto);
        Task<bool> UpdateAsync(int id, CategoryDto categoryDto);
        Task<bool> DeleteAsync(int id);
    }
}
