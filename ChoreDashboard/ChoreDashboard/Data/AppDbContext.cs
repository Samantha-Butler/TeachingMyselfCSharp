using Microsoft.EntityFrameworkCore;
using ChoreDashboard.Data.Models;

namespace ChoreDashboard.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Chore> Chores { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Fallback constructor for the console app
        public AppDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=Database/Database.db");
            }
        }
    }
}
