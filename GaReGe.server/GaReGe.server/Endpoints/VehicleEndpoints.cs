using GaReGe.server.Repositories;

namespace GaReGe.server.Endpoints;

public static class VehicleEndpoints {
    public static void MapVehicleEndpoints(this WebApplication app) {
        app.MapGet("/vehicles", async (
            IVehicleRepository repository
        ) => {
            var list = await repository.GetAllVehicles();

            return Results.Ok(list);
        });
    }
}