using GaReGe.server.Dto;
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

        //
        // app.MapPost("/vehicles", async (
        //     IMemberRepository repository,
        //     VehicleDto dto,
        //     MemberDetailDtoValidator validator,
        //     // Faker faker
        // ) => {
        //     
        //     // if (string.IsNullOrEmpty(dto.Avatar)) {
        //     //     dto = dto with {Avatar = faker.Internet.Avatar()};
        //     // }
        //     //
        //     // var validationResult = await validator.ValidateAsync(dto);
        //     //
        //     // if (!validationResult.IsValid) return Results.ValidationProblem(validationResult.ToDictionary());
        //     //
        //     // var result = await repository.CreateMember(dto);
        //     //
        //     // return result.Match(
        //     //     mem => Results.Created($"/members/{mem.MemberId}", mem),
        //     //     err => Results.Problem(err.Message, statusCode: StatusCodes.Status400BadRequest)
        //     // );
        // });
        //
        // app.MapPut("/members/", async (
        //     IMemberRepository repository,
        //     MemberDetailDto dto,
        //     MemberDetailDtoValidator validator,
        //     Faker faker
        // ) => {
        //     
        //     if (string.IsNullOrEmpty(dto.Avatar)) {
        //         dto = dto with {Avatar = faker.Internet.Avatar()};
        //     }
        //
        //     var validationResult = await validator.ValidateAsync(dto);
        //
        //     if (!validationResult.IsValid) return Results.ValidationProblem(validationResult.ToDictionary());
        //
        //     var result = await repository.UpdateMember(dto);
        //
        //     return result.Match(
        //         mem => Results.Ok(mem),
        //         err => Results.Problem(err.Message, statusCode: StatusCodes.Status400BadRequest)
        //     );
        // });
        //
        // app.MapDelete("/members/{id}", async (
        //     int id,
        //     IMemberRepository repository
        // ) => {
        //     var result = await repository.DeleteMember(id);
        //
        //     return result.Match(
        //         mem => Results.Ok(mem),
        //         err => Results.Problem(err.Message, statusCode: StatusCodes.Status400BadRequest)
        //     );
        // });

        
        
    }
    
    
}