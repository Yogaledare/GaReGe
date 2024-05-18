using GaReGe.server.Dto;
using GaReGe.server.Entity;
using GaReGe.server.Repositories;
using GaReGe.server.Validation;
using LanguageExt;
using Microsoft.AspNetCore.Http.HttpResults;

namespace GaReGe.server.Endpoints {
    public static class MemberEndpoints {

        public static void MapMemberEndpoints(this WebApplication app) {

            app.MapGet("/members",async (
                IMemberRepository repository
                ) => {
                var members = await repository.GetAllMembers();  

                return Results.Ok(members);
            });


            app.MapGet("/members/{id}", async (
                int id,
                IMemberRepository repository
            ) => {
                var result = await repository.GetMember(id);

                return result.Match(
                    Succ: mem => Results.Ok(mem),
                    Fail: err => Results.Problem(err.Message, statusCode: StatusCodes.Status400BadRequest)
                    );
            });


            app.MapPost("/members", async (
                IMemberRepository repository,
                CreateMemberDto dto,
                CreateMemberDtoValidator validator
            ) => {

                var validationResult = await validator.ValidateAsync(dto);

                if (!validationResult.IsValid) {
                    return Results.ValidationProblem(validationResult.ToDictionary()); 
                }
                
                
                
                var result = await repository.CreateMember(dto);

                return result.Match(
                    Succ: mem => Results.Created($"/members/{mem.MemberId}", mem),
                    Fail: err => Results.Problem(err.Message, statusCode: StatusCodes.Status400BadRequest)
                );
            });


            app.MapDelete("/members", async (
                IMemberRepository repository
            ) => {
                var succeeded = await repository.DeleteAllMembers();

                if (!succeeded) {
                    return Results.Problem("No members found to delete.", statusCode: StatusCodes.Status400BadRequest);
                }

                return Results.Ok();
            });
        }
    }
}
