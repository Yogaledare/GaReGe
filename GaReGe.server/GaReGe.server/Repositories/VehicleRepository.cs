using GaReGe.server.Data;
using GaReGe.server.Dto;
using GaReGe.server.Entity;
using LanguageExt.Common;
using Microsoft.EntityFrameworkCore;

namespace GaReGe.server.Repositories;

public interface IVehicleRepository {
    Task<ICollection<VehicleSummaryDto>> GetAllVehicles();
    Task<Result<VehicleDto>> GetVehicle(int id);
    Task<Result<VehicleDto>> CreateVehicle(VehicleDto dto);
    Task<Result<VehicleDto>> UpdateVehicle(VehicleDto dto);
    Task<Result<VehicleDto>> DeleteMember(int id);
}

public class VehicleRepository : IVehicleRepository {
    private readonly GaregeDbContext _context;

    public VehicleRepository(GaregeDbContext context) {
        _context = context;
    }


    public async Task<ICollection<VehicleSummaryDto>> GetAllVehicles() {
        return await _context.Vehicles
            .Include(v => v.Member)
            .Include(v => v.VehicleType)
            .Select(v => EntityToSummaryDto(v))
            .ToListAsync();
    }


    public async Task<Result<VehicleDto>> GetVehicle(int id) {
        var vehicle = await _context.Vehicles.FirstOrDefaultAsync(v => v.VehicleId == id);

        if (vehicle == null) {
            var error = new ArgumentException($"cannot find vehicle {id}");
            return new Result<VehicleDto>(error);
        }

        var memberDetailDto = EntityToDto(vehicle);

        return memberDetailDto;
    }


    public async Task<Result<VehicleDto>> CreateVehicle(VehicleDto dto) {
        var vehicle = new Vehicle {
            LicensePlate = dto.LicensePlate,
            Color = dto.Color,
            Brand = dto.Brand,
            Model = dto.Model,
            NumWheels = dto.NumWheels,
            VehicleTypeId = dto.VehicleTypeId,
            MemberId = dto.MemberId,
        };

        _context.Vehicles.Add(vehicle);
        await _context.SaveChangesAsync();

        return new Result<VehicleDto>(dto);
    }

    public async Task<Result<VehicleDto>> UpdateVehicle(VehicleDto dto) {
        var vehicle = await _context.Vehicles.FirstOrDefaultAsync(v => v.VehicleId == dto.VehicleId);

        if (vehicle == null) {
            var error = new ArgumentException($"Cannot find vehicle {dto.VehicleId}");
            return new Result<VehicleDto>(error);
        }

        vehicle.LicensePlate = dto.LicensePlate;
        vehicle.Color = dto.Color;
        vehicle.Brand = dto.Brand;
        vehicle.Model = dto.Model;
        vehicle.NumWheels = dto.NumWheels;
        vehicle.VehicleTypeId = dto.VehicleTypeId;
        vehicle.MemberId = dto.MemberId;

        var updatedDto = EntityToDto(vehicle);
        await _context.SaveChangesAsync();

        return updatedDto;
    }

    public async Task<Result<VehicleDto>> DeleteMember(int id) {
        var vehicle = await _context.Vehicles.FirstOrDefaultAsync(v => v.VehicleId == id);

        if (vehicle == null) {
            var error = new ArgumentException($"Cannot find vehicle {id}");
            return new Result<VehicleDto>(error);
        }

        _context.Vehicles.Remove(vehicle);
        await _context.SaveChangesAsync();

        return EntityToDto(vehicle);
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

    private static VehicleSummaryDto EntityToSummaryDto(Vehicle vehicle) {
        return new VehicleSummaryDto(
            vehicle.LicensePlate,
            vehicle.Brand,
            vehicle.Model,
            vehicle.VehicleType.Name,
            $"{vehicle.Member.FirstName} {vehicle.Member.LastName}"
        );
    }
}


// private static async Task<Result<Vehicle>> DtoToEntity(VehicleDto dto, GaregeDbContext context) {
//     var vehicleType = await context.VehicleTypes.FirstOrDefaultAsync(vt => vt.VehicleTypeId == dto.VehicleTypeId);
//
//     if (vehicleType == null) {
//         var error = new ArgumentException($"Cannot find vehicle type id {dto.VehicleTypeId}");
//         return new Result<Vehicle>(error);
//     }
//
//     var member = await context.Members.FirstOrDefaultAsync(m => m.MemberId == dto.MemberId);
//
//     if (member == null) {
//         var error = new ArgumentException($"Cannot find member id {dto.MemberId}");
//         return new Result<Vehicle>(error);
//     }
//
//     return new Vehicle {
//         LicensePlate = dto.LicensePlate,
//         Color = dto.Color,
//         Brand = dto.Brand,
//         Model = dto.Model,
//         NumWheels = dto.NumWheels,
//         VehicleType = vehicleType,
//         Member = member,
//     };
// }


// var queryResult = await _context.Vehicles.FirstOrDefaultAsync(v => v.LicensePlate == dto.LicensePlate);
//
// if (queryResult != null) {
//     var error = new ArgumentException("Licence plate already in database");
//     return new Result<VehicleDto>(error);
// }
//
// var vehicleType = await _context.VehicleTypes.FirstOrDefaultAsync(vt => vt.VehicleTypeId == dto.VehicleTypeId);
//
// if (vehicleType == null) {
//     var error = new ArgumentException($"Cannot find vehicle type id {dto.VehicleTypeId}");
//     return new Result<VehicleDto>(error);
// }
//
// var member = await _context.Members.FirstOrDefaultAsync(m => m.MemberId == dto.MemberId);
//
// if (member == null) {
//     var error = new ArgumentException($"Cannot find member id {dto.MemberId}");
//     return new Result<Vehicle>(error);
// }


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