using GaReGe.server.Dto;
using GaReGe.server.Repositories;
using GaReGe.server.Validation;

namespace GaReGe.server.Endpoints;

public static class VehicleEndpoints {
    public static void MapVehicleEndpoints(this WebApplication app) {
        app.MapGet("/vehicles", async (
            IVehicleRepository repository
        ) => {
            var list = await repository.GetAllVehicles();

            return Results.Ok(list);
        });


        app.MapGet("/vehicles/{id}", async (
            int id,
            IVehicleRepository repository
        ) => {
            var result = await repository.GetVehicle(id);

            return result.Match(
                veh => Results.Ok(veh),
                err => Results.Problem(err.Message, statusCode: StatusCodes.Status400BadRequest)
            );
        });

        app.MapPost("/vehicles", async (
            IVehicleRepository repository,
            VehicleCreateDto dto,
            VehicleCreateDtoValidator validator
        ) => {
            var validationResult = await validator.ValidateAsync(dto);

            if (!validationResult.IsValid) return Results.ValidationProblem(validationResult.ToDictionary());

            var result = await repository.CreateVehicle(dto);

            return result.Match(
                veh => Results.Created($"/members/{veh.VehicleId}", veh),
                err => Results.Problem(err.Message, statusCode: StatusCodes.Status400BadRequest)
            );
        });


        app.MapPut("/members/", async (
            IVehicleRepository repository,
            VehicleModifyDto dto,
            VehicleCreateDtoValidator validator
        ) => {
            var validationResult = await validator.ValidateAsync(dto);

            if (!validationResult.IsValid) return Results.ValidationProblem(validationResult.ToDictionary());

            var result = await repository.UpdateVehicle(dto);

            return result.Match(
                mem => Results.Ok(mem),
                err => Results.Problem(err.Message, statusCode: StatusCodes.Status400BadRequest)
            );
        });


        app.MapDelete("/members/{id}", async (
            int id,
            IMemberRepository repository
        ) => {
            var result = await repository.DeleteMember(id);

            return result.Match(
                mem => Results.Ok(mem),
                err => Results.Problem(err.Message, statusCode: StatusCodes.Status400BadRequest)
            );
        });
    }
}