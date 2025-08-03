using InventoryManagementApi.DTOs;
using InventoryManagementApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService _service;

        public SuppliersController(ISupplierService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<SupplierDto>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SupplierDto>> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<SupplierDto>> Create(SupplierDto dto)
        {
            var newItem = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = newItem.Name }, newItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SupplierDto dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
