using InventoryManagementApi.Data;
using InventoryManagementApi.DTOs;
using InventoryManagementApi.Interfaces;
using InventoryManagementApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementApi.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            return await _context.Categories
                .Select(c => new CategoryDto { Name = c.Name })
                .ToListAsync();
        }

        public async Task<CategoryDto?> GetByIdAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            return category == null ? null : new CategoryDto { Name = category.Name };
        }

        public async Task<CategoryDto> CreateAsync(CategoryDto categoryDto)
        {
            var category = new Category { Name = categoryDto.Name };
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return categoryDto;
        }

        public async Task<bool> UpdateAsync(int id, CategoryDto categoryDto)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return false;

            category.Name = categoryDto.Name;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return false;

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
