﻿using GaReGe.server.Dto;
using GaReGe.server.Entity;
using GaReGe.server.Repositories;
using LanguageExt;
using Microsoft.AspNetCore.Http.HttpResults;

namespace GaReGe.server.Endpoints {
    public static class MemberEndpoints {

        public static void MapMemberEndpoints(this WebApplication app) {

            app.MapGet("/members",async (
                IMemberRepository repository
                ) => {
                var members = await repository.GetAllMembers();  
                // [
                    // new Member
                    // {
                        // FirstName = "Adam"
                    // }
                // ];

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
            ) => {
                var result = await repository.CreateMember(dto);

                return result.Match(
                    Succ: mem => Results.Ok(mem),
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
