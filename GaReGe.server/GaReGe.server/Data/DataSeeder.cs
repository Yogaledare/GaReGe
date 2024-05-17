using Bogus;
using GaReGe.server.Entity;
using Microsoft.IdentityModel.Tokens;

namespace GaReGe.server.Data;

public class DataSeeder : IDataSeeder
{

    private readonly GaregeDbContext _context;

    public DataSeeder(GaregeDbContext context) {
        _context = context;
    }

    public void SeedData() {
        Console.WriteLine("hello MUM!!!!!!!!!!!!!!!!!");
        if (!_context.Members.Any()) {
            SeedMembers();
        }

        if (!_context.VehicleTypes.Any()) {
            SeedVehicleTypes();
        }

        if (!_context.Vehicles.Any()) {
            SeedVehicles();
        }
    }
    
    private void SeedMembers() {
        var faker = new Faker<Member>()
            .RuleFor(o => o.FirstName, f => f.Name.FirstName())
            .RuleFor(o => o.LastName, f => f.Name.LastName())
            .RuleFor(o => o.Ssr, f => {
                var randomDate = f.Date.Past(30);
                var dateString = randomDate.ToString("yyyymmdd");
                var randomDigits = f.Random.Int(1000, 9999).ToString();

                return $"{dateString}-{randomDigits}";
            });

        var members = faker.Generate(10);
        _context.Members.AddRange(members);
        _context.SaveChanges();
    }


    private void SeedVehicleTypes()
    {
        var faker = new Faker<VehicleType>()
            .RuleFor(o => o.Name, f => f.Vehicle.Type())
            .RuleFor(o => o.ParkingSpaceRequirement, f => f.Random.Int(1, 5));

        var vehicleTypes = faker.Generate(5); 
        _context.VehicleTypes.AddRange(vehicleTypes);
        _context.SaveChanges();
    }


    private void SeedVehicles()
    {
        var faker = new Faker<Vehicle>()
            .RuleFor(v => v.LicensePlate, f => f.Vehicle.Vin())
            .RuleFor(v => v.Color, f => f.Commerce.Color())
            .RuleFor(v => v.Brand, f => f.Vehicle.Manufacturer())
            .RuleFor(v => v.Model, f => f.Vehicle.Model())
            .RuleFor(v => v.NumWheels, f => f.Random.Even(2, 8))
            .RuleFor(v => v.MemberId, f => f.PickRandom(_context.Members.ToList()).MemberId)
            .RuleFor(v => v.VehicleTypeId, f => f.PickRandom(_context.VehicleTypes.ToList()).VehicleTypeId);

        var vehicles = faker.Generate(20); 
        _context.Vehicles.AddRange(vehicles);
        _context.SaveChanges();
    }
}