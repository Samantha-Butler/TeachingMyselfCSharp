# 🧹 Parent Dashboard – SQLite Setup Guide

This project uses [SQLite](https://www.sqlite.org/index.html) with Entity Framework Core for local data storage. Follow these steps to install SQLite, configure your connection string, and apply the initial data model (`Chore`).

---

## ✅ Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/en-us/download) installed
- EF Core CLI tools installed (if not already):

```bash
dotnet tool install --global dotnet-ef
```
---
## Setup SQLite and Entity Framework Core

#### 1. Install Required NuGet Packages

Run these commands in your project directory to add EF Core SQLite support:

```bash
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Design
```

#### 2. Update your AppDbContext to use SQLite by editing the OnConfiguring method:
```
protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=parent_dashboard.db");
        }
```

#### 3. Create the Initial Migration
```bash
dotnet ef migrations add InitialCreate
```
#### 4. Apply the Migration
```bash
dotnet ef database update
```