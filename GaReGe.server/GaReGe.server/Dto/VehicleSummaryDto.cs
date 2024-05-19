namespace GaReGe.server.Dto;

public record VehicleSummaryDto( 
    int VehicleId,
    string LicensePlate,
    string Brand,
    string Model,
    string VehicleTypeName,
    string MemberName
);