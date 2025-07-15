using Microsoft.EntityFrameworkCore;
using ChoreDashboard.Data.Models;

namespace ChoreDashboard.Data;

public class AppDbContext : DbContext
{
    public DbSet<Chore> Chores => Set<Chore>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Database/Database.db");
    }
}
