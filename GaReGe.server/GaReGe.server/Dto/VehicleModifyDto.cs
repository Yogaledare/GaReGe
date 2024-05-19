namespace GaReGe.server.Dto;

public record VehicleModifyDto(
    int VehicleId,
    string LicensePlate,
    string Color,
    string Brand,
    string Model,
    int? NumWheels,
    int? MemberId,
    int? VehicleTypeId
) : VehicleCreateDto(LicensePlate,
    Color,
    Brand,
    Model,
    NumWheels,
    MemberId,
    VehicleTypeId
);