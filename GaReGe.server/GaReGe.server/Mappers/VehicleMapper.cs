using GaReGe.server.Dto;
using GaReGe.server.Entity;
using LanguageExt;

namespace GaReGe.server.Mappers;

public interface IVehicleMapper {
    VehicleSummaryDto Vehicle_VehicleSummaryDto(Vehicle vehicle);
    VehicleDetailDto Vehicle_VehicleDetailDto(Vehicle vehicle);
    Vehicle ModifyVehicle(Vehicle vehicle, VehicleModifyDto dto);
    Vehicle CreateVehicle(VehicleCreateDto dto);
}

public class VehicleMapper : IVehicleMapper {
    public VehicleSummaryDto Vehicle_VehicleSummaryDto(Vehicle vehicle) {
        return new VehicleSummaryDto(
            vehicle.VehicleId,
            vehicle.LicensePlate,
            vehicle.Brand,
            vehicle.Model,
            vehicle.VehicleType.Name,
            $"{vehicle.Member.FirstName} {vehicle.Member.LastName}"
        );
    }


    public VehicleDetailDto Vehicle_VehicleDetailDto(Vehicle vehicle) {
        return new VehicleDetailDto(
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

    
    public Vehicle ModifyVehicle(Vehicle vehicle, VehicleModifyDto dto) {
        vehicle.LicensePlate = dto.LicensePlate;   
        vehicle.Color = dto.Color;   
        vehicle.Brand = dto.Brand;   
        vehicle.Model = dto.Model;

        if (dto.NumWheels.IsNull() || dto.VehicleTypeId.IsNull() || dto.MemberId.IsNull()) {
            throw new ArgumentException("Nulls in the Dto"); 
        }
        
        vehicle.NumWheels = dto.NumWheels!.Value;   
        vehicle.VehicleTypeId = dto.VehicleTypeId!.Value;   
        vehicle.MemberId = dto.MemberId!.Value;   

        return vehicle;
    }


    public Vehicle CreateVehicle(VehicleCreateDto dto) {
        if (dto.NumWheels.IsNull() || dto.VehicleTypeId.IsNull() || dto.MemberId.IsNull()) {
            throw new ArgumentException("Nulls in the Dto"); 
        }
        
        var vehicle = new Vehicle {
            LicensePlate = dto.LicensePlate,
            Color = dto.Color,
            Brand = dto.Brand,
            Model = dto.Model,
            NumWheels = dto.NumWheels!.Value,
            VehicleTypeId = dto.VehicleTypeId!.Value,
            MemberId = dto.MemberId!.Value,
        };

        return vehicle; 
    }
}