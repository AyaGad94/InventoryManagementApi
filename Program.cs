﻿using InventoryManagementApi.Data;
using InventoryManagementApi.Interfaces;
using InventoryManagementApi.Services;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using InventoryManagementApi.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register services
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<IStockTransactionService, StockTransactionService>();

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile)); // Registers your mapping profile

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
