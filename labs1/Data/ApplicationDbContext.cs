using labs1.Models;
using Microsoft.EntityFrameworkCore;

namespace labs1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        // Add DbSet for other entities like Tasks in the future
    }
}