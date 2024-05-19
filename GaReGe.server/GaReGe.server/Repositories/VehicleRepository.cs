using GaReGe.server.Data;
using GaReGe.server.Dto;
using GaReGe.server.Entity;
using GaReGe.server.Mappers;
using LanguageExt.Common;
using Microsoft.EntityFrameworkCore;

namespace GaReGe.server.Repositories;

public interface IVehicleRepository {
    Task<ICollection<VehicleSummaryDto>> GetAllVehicles();
    Task<Result<VehicleDetailDto>> GetVehicle(int id);
    Task<Result<VehicleDetailDto>> CreateVehicle(VehicleCreateDto detailDto);
    Task<Result<VehicleDetailDto>> UpdateVehicle(VehicleModifyDto detailDto);
    Task<Result<VehicleDetailDto>> DeleteMember(int id);
}

public class VehicleRepository : IVehicleRepository {
    private readonly GaregeDbContext _context;
    private readonly IVehicleMapper _mapper;

    public VehicleRepository(GaregeDbContext context, IVehicleMapper mapper) {
        _context = context;
        _mapper = mapper;
    }


    public async Task<ICollection<VehicleSummaryDto>> GetAllVehicles() {
        return await _context.Vehicles
            .Include(v => v.Member)
            .Include(v => v.VehicleType)
            .Select(v => _mapper.Vehicle_VehicleSummaryDto(v))
            .ToListAsync();
    }


    public async Task<Result<VehicleDetailDto>> GetVehicle(int id) {
        var vehicle = await _context.Vehicles.FirstOrDefaultAsync(v => v.VehicleId == id);

        if (vehicle == null) {
            var error = new ArgumentException($"cannot find vehicle {id}");
            return new Result<VehicleDetailDto>(error);
        }

        var memberDetailDto = _mapper.Vehicle_VehicleDetailDto(vehicle);

        return memberDetailDto;
    }


    public async Task<Result<VehicleDetailDto>> CreateVehicle(VehicleCreateDto detailDto) {
        var vehicle = _mapper.CreateVehicle(detailDto);

        _context.Vehicles.Add(vehicle);
        await _context.SaveChangesAsync();

        return new Result<VehicleDetailDto>(_mapper.Vehicle_VehicleDetailDto(vehicle));
    }


    public async Task<Result<VehicleDetailDto>> UpdateVehicle(VehicleModifyDto detailDto) {
        var vehicle = await _context.Vehicles.FirstOrDefaultAsync(v => v.VehicleId == detailDto.VehicleId);

        if (vehicle == null) {
            var error = new ArgumentException($"Cannot find vehicle {detailDto.VehicleId}");
            return new Result<VehicleDetailDto>(error);
        }

        vehicle = _mapper.ModifyVehicle(vehicle, detailDto);
        await _context.SaveChangesAsync();

        var updatedDto = _mapper.Vehicle_VehicleDetailDto(vehicle);
        return updatedDto;
    }


    public async Task<Result<VehicleDetailDto>> DeleteMember(int id) {
        var vehicle = await _context.Vehicles.FirstOrDefaultAsync(v => v.VehicleId == id);

        if (vehicle == null) {
            var error = new ArgumentException($"Cannot find vehicle {id}");
            return new Result<VehicleDetailDto>(error);
        }

        _context.Vehicles.Remove(vehicle);
        await _context.SaveChangesAsync();

        return _mapper.Vehicle_VehicleDetailDto(vehicle);
    }
}


// private static VehicleDetailDto EntityToDto(Vehicle vehicle) {
//     return new VehicleDetailDto(
//         vehicle.VehicleId,
//         vehicle.LicensePlate,
//         vehicle.Color,
//         vehicle.Brand,
//         vehicle.Model,
//         vehicle.NumWheels,
//         vehicle.MemberId,
//         vehicle.VehicleTypeId,
//         vehicle.VehicleType.Name,
//         $"{vehicle.Member.FirstName} {vehicle.Member.LastName}"
//     );
// }

// private static VehicleSummaryDto EntityToSummaryDto(Vehicle vehicle) {
//     return new VehicleSummaryDto(
//         vehicle.LicensePlate,
//         vehicle.Brand,
//         vehicle.Model,
//         vehicle.VehicleType.Name,
//         $"{vehicle.Member.FirstName} {vehicle.Member.LastName}"
//     );
// }


// vehicle.LicensePlate = detailDto.LicensePlate;
// vehicle.Color = detailDto.Color;
// vehicle.Brand = detailDto.Brand;
// vehicle.Model = detailDto.Model;
// vehicle.NumWheels = detailDto.NumWheels;
// vehicle.VehicleTypeId = detailDto.VehicleTypeId;
// vehicle.MemberId = detailDto.MemberId;


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