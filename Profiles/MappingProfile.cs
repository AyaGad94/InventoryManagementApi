using AutoMapper;
using InventoryManagementApi.DTOs;
using InventoryManagementApi.Models;

namespace InventoryManagementApi.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductCreateDto, Product>();
            CreateMap<Product, ProductDto>(); // Map from Product entity to ProductDto (for reading/displaying data)
            CreateMap<ProductCreateDto, Product>(); // Map from ProductCreateDto to Product entity (for creating or updating products)

            CreateMap<Category, CategoryDto>();// Map from Category entity to CategoryDto (used when returning category data)
            CreateMap<Supplier, SupplierDto>(); // Map from Supplier entity to SupplierDto (used when returning supplier data)

            CreateMap<StockTransaction, StockTransactionDto>();// Map from StockTransaction entity to StockTransactionDto (for displaying stock transaction data)
            CreateMap<StockTransactionDto, StockTransaction>(); // Map from StockTransactionDto to StockTransaction entity (for creating or updating stock transactions)
        }
    }
}
