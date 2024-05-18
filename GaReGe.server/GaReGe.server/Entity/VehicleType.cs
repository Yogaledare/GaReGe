namespace GaReGe.server.Entity;

public class VehicleType {
    public int VehicleTypeId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int VehicleTypeEntityId { get; set; }
    public int ParkingSpaceRequirement { get; set; }
    public ICollection<Vehicle> Vehicles { get; set; } = [];
}