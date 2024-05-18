using GaReGe.server.Data;
using GaReGe.server.Endpoints;
using GaReGe.server.Repositories;
using GaReGe.server.Validation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<GaregeDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<IDataSeeder, DataSeeder>();
builder.Services.AddScoped<SetMemberDtoValidator>();

builder.Services.AddCors();


var app = builder.Build();


using (var scope = app.Services.CreateScope()) {
    var seedDataGenerator = scope.ServiceProvider.GetRequiredService<IDataSeeder>();
    seedDataGenerator.SeedData();
}


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