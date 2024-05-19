namespace GaReGe.server.Dto;

public record VehicleCreateDto(
    string LicensePlate,
    string Color,
    string Brand,
    string Model,
    int? NumWheels,
    int? MemberId,
    int? VehicleTypeId
);