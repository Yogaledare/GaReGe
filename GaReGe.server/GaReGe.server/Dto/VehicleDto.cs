namespace GaReGe.server.Dto;

public record VehicleDto(
    int VehicleId,
    string LicensePlate,
    string Color,
    string Brand,
    string Model,
    int NumWheels,
    int MemberId,
    int VehicleTypeId,
    string VehicleTypeName
);