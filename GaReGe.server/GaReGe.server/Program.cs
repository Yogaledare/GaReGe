using GaReGe.server.Data;
using GaReGe.server.Endpoints;
using GaReGe.server.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<GaregeDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<IDataSeeder, DataSeeder>();


var app = builder.Build();

//using (var scope = app.Services.CreateScope()) {
//    var services = scope.ServiceProvider;
//    try {
//        var dataSeeder = services.GetRequiredService<DataSeeder>();
//        dataSeeder.SeedData(); // Ensure this is within the using block
//    }
//    catch (Exception ex) {
//        var logger = services.GetRequiredService<ILogger<Program>>();
//        logger.LogError(ex, "An error occurred while seeding the database.");
//    }
//}

using (var scope = app.Services.CreateScope()) {
    var seedDataGenerator = scope.ServiceProvider.GetRequiredService<IDataSeeder>();
    seedDataGenerator.SeedData();
}


// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.MapMemberEndpoints();
app.MapVehicleEndpoints();

app.Run();
