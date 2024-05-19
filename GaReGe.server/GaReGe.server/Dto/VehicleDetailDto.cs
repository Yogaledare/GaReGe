namespace GaReGe.server.Dto;

public record VehicleDetailDto(
    int VehicleId,
    string LicensePlate,
    string Color,
    string Brand,
    string Model,
    int NumWheels,
    int MemberId,
    int VehicleTypeId,
    string VehicleTypeName,
    string MemberName
);