using InventoryManagementApi.DTOs;
using InventoryManagementApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockTransactionsController : ControllerBase
    {
        private readonly IStockTransactionService _service;

        public StockTransactionsController(IStockTransactionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<StockTransactionDto>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StockTransactionDto>> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<StockTransactionDto>> Create(StockTransactionDto dto)
        {
            var newItem = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = newItem.ProductId }, newItem);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
