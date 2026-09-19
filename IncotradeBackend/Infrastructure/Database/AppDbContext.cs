
using IncotradeBackend.Infrastructure.Database.Model;
using Microsoft.EntityFrameworkCore;

namespace IncotradeBackend.Infrastructure.Database
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}


        // Db Set
        public DbSet<User> Users { set; get; }



        // Table configurations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure User table
            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .HasConversion<string>();


        }
        
    }
}