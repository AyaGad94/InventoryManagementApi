# InventoryManagementApi

A RESTful ASP.NET Core Web API that provides full inventory management functionality, including handling products, categories, suppliers, and stock transactions.  
Built with a clean service-layer architecture, Entity Framework Core, and SQL Server.

## 📦 Features

- Manage **Products**, **Categories**, **Suppliers**, and **Stock Transactions**
- Add, update, retrieve, and delete records
- Automatically update stock levels via stock-in and stock-out transactions
- Service-layer abstraction for business logic
- Connected to SQL Server using EF Core
- Uses DTOs and AutoMapper for data transformation

## 🧱 Project Structure

- **Controllers/** – Handle HTTP requests and route them to services
- **Models/** – Define core domain entities (Product, Category, Supplier, StockTransaction)
- **DTOs/** – Define input and output data shapes
- **Services/** – Contain business logic separated from controllers
- **Interfaces/** – Contain service abstractions
- **Data/** – Contains `AppDbContext` and database configuration
- **Profiles/** – AutoMapper profile setup

## 🧠 Key Concepts Implemented

- **Service Layer Pattern**
- **DTO usage with AutoMapper**
- **Entity Framework Core with Code First**
- **SQL Server database**
- **Clean separation of concerns**

## 🛠️ Tech Stack

- ASP.NET Core Web API (.NET 6+)
- Entity Framework Core
- SQL Server (SSMS)
- AutoMapper
- Visual Studio 2022

## 🚀 Getting Started

### 1. Clone the Repository
```bash
git clone https://github.com/YourUsername/InventoryManagementApi.git
cd InventoryManagementApi
