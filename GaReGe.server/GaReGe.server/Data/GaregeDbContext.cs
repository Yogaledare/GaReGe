using GaReGe.server.Entity;
using Microsoft.EntityFrameworkCore;

namespace GaReGe.server.Data;

public class GaregeDbContext : DbContext {
    public GaregeDbContext(DbContextOptions<GaregeDbContext> options) : base(options) {
    }

    public DbSet<Member> Members { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<VehicleType> VehicleTypes { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Member>()
            .HasIndex(m => m.Ssr)
            .IsUnique();
        
        modelBuilder.Entity<Vehicle>()
            .HasIndex(v => v.LicensePlate)
            .IsUnique();
    }
}