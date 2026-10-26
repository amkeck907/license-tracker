using CCED_Sample_App.Models;
using Microsoft.EntityFrameworkCore;

namespace CCED_Sample_App.Data_Access
{
    public class LicenseDbContext : DbContext
    {
        public LicenseDbContext(DbContextOptions<LicenseDbContext> options)
            : base(options)
        {
        }
        public DbSet<License> License { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<License>()
                .HasIndex(x => x.LicenseNumber)
                .IsUnique();
        }
    }

}
