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
    public class SupplierService : ISupplierService
    {
        private readonly AppDbContext _context;

        public SupplierService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<SupplierDto>> GetAllAsync()
        {
            return await _context.Suppliers
                .Select(s => new SupplierDto { Name = s.Name })
                .ToListAsync();
        }

        public async Task<SupplierDto?> GetByIdAsync(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            return supplier == null ? null : new SupplierDto { Name = supplier.Name };
        }

        public async Task<SupplierDto> CreateAsync(SupplierDto dto)
        {
            var supplier = new Supplier { Name = dto.Name };
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, SupplierDto dto)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null) return false;

            supplier.Name = dto.Name;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null) return false;

            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
