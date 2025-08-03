using InventoryManagementApi.Data;
using InventoryManagementApi.DTOs;
using InventoryManagementApi.Interfaces;
using InventoryManagementApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class StockTransactionService : IStockTransactionService
{
    private readonly AppDbContext _context;

    public StockTransactionService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<StockTransactionDto>> GetAllAsync()
    {
        return await _context.StockTransactions
            .Include(s => s.Product)
            .Select(s => new StockTransactionDto
            {
                Id = s.Id,
                ProductId = s.ProductId,
                Quantity = s.Quantity,
                Type = s.Type
            })
            .ToListAsync();
    }

    public async Task<StockTransactionDto?> GetByIdAsync(int id)
    {
        var st = await _context.StockTransactions.FindAsync(id);
        if (st == null) return null;

        return new StockTransactionDto
        {
            Id = st.Id,
            ProductId = st.ProductId,
            Quantity = st.Quantity,
            Type = st.Type
        };
    }

    public async Task<StockTransactionDto> CreateAsync(StockTransactionDto dto)
    {
        var st = new StockTransaction
        {
            ProductId = dto.ProductId,
            Quantity = dto.Quantity,
            Type = dto.Type
        };

        _context.StockTransactions.Add(st);
        await _context.SaveChangesAsync();

        dto.Id = st.Id;
        return dto;
    }

    public async Task<bool> UpdateAsync(int id, StockTransactionDto dto)
    {
        var st = await _context.StockTransactions.FindAsync(id);
        if (st == null) return false;

        st.ProductId = dto.ProductId;
        st.Quantity = dto.Quantity;
        st.Type = dto.Type;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var st = await _context.StockTransactions.FindAsync(id);
        if (st == null) return false;

        _context.StockTransactions.Remove(st);
        await _context.SaveChangesAsync();
        return true;
    }
}
