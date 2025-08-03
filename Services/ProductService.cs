///////bktb hnaaa l logic badel ma aktboh fil controller//////////
using AutoMapper;
using InventoryManagementApi.DTOs;
using InventoryManagementApi.Interfaces;
using InventoryManagementApi.Models;
using InventoryManagementApi.Data; // <-- Added this line for AppDbContext
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryManagementApi.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProductService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            var products = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(products);
        }

       
        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.Category)////Eager Load >>>3amlt kda 3shan l data  kolha tzhar 
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

       
        public async Task<Product> CreateAsync(ProductCreateDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            _context.Products.Add(product);///////hena b3ml   save to DB//////////////
            await _context.SaveChangesAsync();
            return product;////// hena be return mapped DTO/////
        }
       
        public async Task<Product?> UpdateAsync(int id, ProductUpdateDto dto)
        {
            var existingProduct = await _context.Products.FindAsync(id);
            if (existingProduct == null) return null;

            _mapper.Map(dto, existingProduct);
            await _context.SaveChangesAsync();
            return existingProduct;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
