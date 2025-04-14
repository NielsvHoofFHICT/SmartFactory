using challenge_2_factory.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace challenge_2_factory.Infrastructure.Data
{
    public class FactoryDbContext(DbContextOptions<FactoryDbContext> options) : DbContext(options)
    {
        public DbSet<MachineActivity> MachineActivities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure MachineActivity entity
            modelBuilder.Entity<MachineActivity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.MachineName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.ActivityType).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Status).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Notes).HasMaxLength(500);
            });
        }
    }
} 