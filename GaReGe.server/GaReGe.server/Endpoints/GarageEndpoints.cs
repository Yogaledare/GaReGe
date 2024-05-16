using GaReGe.server.Entity;

namespace GaReGe.server.Endpoints {
    public static class MemberEndpoints {


        public static void MapMemberEndpoints(this WebApplication app) {

            app.MapGet("/members/all", () => {
                List<Member> members = [];
                members.Add(new Member {
                    FirstName = "Adam"
                });

                return Results.Ok(members);
            }); 
        }









    }
}
