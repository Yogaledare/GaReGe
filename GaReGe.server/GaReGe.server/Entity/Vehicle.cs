namespace GaReGe.server.Entity {
    public class Vehicle {
        public int VehicleId { get; set; }
        public string LicensePlate { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int NumWheels { get; set; }

        // FK
        public int VehicleTypeId { get; set; }
        public int MemberId { get; set; }

        // nav props
        public VehicleType MyProperty { get; set; }
        public Member Member { get; set; }

    }
}
