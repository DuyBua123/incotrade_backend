
using IncotradeBackend.Infrastructure.Database.Model;
using Microsoft.EntityFrameworkCore;

namespace IncotradeBackend.Infrastructure.Database
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}


        // Db Set
        public DbSet<User> Users { set; get; }
        public DbSet<LoginSession> LoginSessions { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<WorkSchedule> WorkSchedules { get; set; }



        // Table configurations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure User table
            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .HasConversion<string>();

            // Configure LoginSession table
            modelBuilder.Entity<LoginSession>()
                .Property(ls => ls.RevokedReason)
                .HasConversion<string>();

            // Configure Staff table
            modelBuilder.Entity<Staff>()
                .HasIndex(s => s.Email)
                .IsUnique();

            modelBuilder.Entity<Staff>()
                .Property(s => s.IsLocked)
                .HasDefaultValue(true);

        }
        
    }
}
