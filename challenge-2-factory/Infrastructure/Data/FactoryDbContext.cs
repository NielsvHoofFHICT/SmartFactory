using challenge_2_factory.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace challenge_2_factory.Infrastructure.Data
{
    public class FactoryDbContext(DbContextOptions<FactoryDbContext> options) : DbContext(options)
    {
        public DbSet<MachineActivity> MachineActivities { get; set; }
        public DbSet<Metric> Metrics { get; set; }

        public DbSet<Machine> Machines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MachineActivity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.MachineName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.ActivityType).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Status).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Notes).HasMaxLength(500);
            });

            modelBuilder.Entity<Metric>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Unit).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Source).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Category).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Notes).HasMaxLength(500);
            });
        }
    }
}