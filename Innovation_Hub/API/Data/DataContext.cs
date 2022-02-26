using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<InterestArea> InterestAreas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>()
                .ToTable("Users");

            modelBuilder.Entity<InterestArea>()
                .ToTable("InterestAreas");

            modelBuilder.Entity<InterestArea>()
                .Property(c => c.InterestAreaName)
                .HasConversion<string>();

            base.OnModelCreating(modelBuilder);
        }
    }
}