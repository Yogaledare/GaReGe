using GaReGe.server.Data;
using GaReGe.server.Dto;
using GaReGe.server.Entity;
using LanguageExt;
using LanguageExt.Common;
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
        return await _context.Vehicles
            .Include(v => v.Member)
            .Include(v => v.VehicleType)
            .Select(v => EntityToDto(v))
            .ToListAsync();
    }

    
    

    private static VehicleDto EntityToDto(Vehicle vehicle) {
        return new VehicleDto(
            vehicle.VehicleId,
            vehicle.LicensePlate,
            vehicle.Color,
            vehicle.Brand,
            vehicle.Model,
            vehicle.NumWheels,
            vehicle.MemberId,
            vehicle.VehicleTypeId,
            vehicle.VehicleType.Name, 
            $"{vehicle.Member.FirstName} {vehicle.Member.LastName}"
        );
    }
}


// public async Task<Result<VehicleDto>> GetVehicle(int id) {
//
//     var vehicle = _context.Vehicles.First(v => v.VehicleId == id);
//
//     if (vehicle.IsNull()) {
//         var error = new ArgumentException($"cannot find vehicle {id}");
//         return new Result<VehicleDto>(error);
//
//     }
//     
//     if (member == null) {
//         var error = new ArgumentException($"cannot find member {id}");
//     }
//
//     var memberDetailDto = EntityToDetailDto(member);
//
//     return memberDetailDto;

// }



