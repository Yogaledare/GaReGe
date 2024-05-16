using GaReGe.server.Dto;
using GaReGe.server.Entity;
using GaReGe.server.Repositories;
using LanguageExt;

namespace GaReGe.server.Endpoints {
    public static class MemberEndpoints {

        public static void MapMemberEndpoints(this WebApplication app) {

            app.MapGet("/members", () => {
                List<Member> members =
                [
                    new Member
                    {
                        FirstName = "Adam"
                    }
                ];

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
                CreateMemberDto dto
            ) =>
            {
                var result = await repository.CreateMember(dto);

                return result.Match(
                    Succ: mem => Results.Ok(mem), 
                    Fail: err => Results.Problem(err.Message, statusCode: StatusCodes.Status400BadRequest)
                ); 
            }); 
        }









    }
}
