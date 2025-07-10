using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using JobTrackr.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace JobTrackr.Api.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Application> Applications { get; set; } = null!;
    }
}
