using GaReGe.server.Entity;
using Microsoft.EntityFrameworkCore;

namespace GaReGe.server.Data {
    public class GaregeDbContext : DbContext {

        public GaregeDbContext() {
        }

        DbSet<Member> Members { get; set; }
        DbSet<Vehicle> Vehicles{ get; set; }
        DbSet<VehicleType> VehicleTypes { get; set; }


    }
}
