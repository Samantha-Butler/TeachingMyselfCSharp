using Microsoft.EntityFrameworkCore;
using ParentDashboard.Data.Models;

namespace ParentDashboard.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Chore> Chores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // This is your SQLite connection string
            optionsBuilder.UseSqlite("Data Source=Database/Database.db");
        }
    }
}
