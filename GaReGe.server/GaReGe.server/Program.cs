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

// Configure CORS
// builder.Services.AddCors(); 

// builder.Services.AddCors(options => {
//     options.AddPolicy("AllowAll", policy => {
//         policy.AllowAnyOrigin() 
//             .AllowAnyMethod()
//             .AllowAnyHeader()
//             ;
//     });
// });


// builder.Services.AddCors(options => {
//     options.AddPolicy("AllowSpecificOrigin", policy => {
//         policy.WithOrigins("http://localhost:4000")
//             .AllowAnyMethod()
//             .AllowAnyHeader()
//             ;
//     });
// });


builder.Services.AddCors();


// (options =>
// {
// options.AddPolicy("AllowSpecificOrigin",
// builder => builder.WithOrigins("http://localhost:4000")
// .AllowAnyHeader()
// .AllowAnyMethod()
// .AllowCredentials());
// });


var app = builder.Build();


// app.UseCors(p =>
// p.WithOrigins("http://localhost:4000").AllowAnyHeader().AllowAnyMethod().AllowCredentials());


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

// app.UseCors("AllowSpecificOrigin");

// app.UseCors("AllowAll");
// app.UseCors("AllowSpecificOrigin");

app.UseCors(p =>
    p.WithOrigins("http://localhost:4000")
        .AllowAnyHeader()
        .AllowAnyMethod()
);


// Configure the HTTP request pipeline.
// app.UseHttpsRedirection();

app.MapMemberEndpoints();
app.MapVehicleEndpoints();

app.Run();