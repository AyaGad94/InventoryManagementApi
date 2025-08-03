using InventoryManagementApi.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryManagementApi.Interfaces
{
    public interface IStockTransactionService
    {
        Task<List<StockTransactionDto>> GetAllAsync();
        Task<StockTransactionDto?> GetByIdAsync(int id);
        Task<StockTransactionDto> CreateAsync(StockTransactionDto dto);
        Task<bool> UpdateAsync(int id, StockTransactionDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
