using GaReGe.server.Data;
using GaReGe.server.Dto;
using GaReGe.server.Entity;
using Microsoft.EntityFrameworkCore;

namespace GaReGe.server.Repositories;

public interface IVehicleRepository {
    Task<ICollection<VehicleDto>> GetAllVehicles();
}

public class VehicleRepository : IVehicleRepository {
    private readonly GaregeDbContext _context;

    public VehicleRepository(GaregeDbContext context) {
        _context = context;
    }


    public async Task<ICollection<VehicleDto>> GetAllVehicles() {
        return await _context.Vehicles.Select(v => VehicleToVehicleDto(v)).ToListAsync();
    }


    private static VehicleDto VehicleToVehicleDto(Vehicle vehicle) {
        return new VehicleDto(
            vehicle.VehicleId,
            vehicle.LicensePlate,
            vehicle.Color,
            vehicle.Brand,
            vehicle.Model,
            vehicle.NumWheels,
            vehicle.MemberId,
            vehicle.VehicleTypeId,
            vehicle.VehicleType.Name
        );
    }
}