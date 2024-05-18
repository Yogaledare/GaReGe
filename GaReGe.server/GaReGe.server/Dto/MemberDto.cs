namespace GaReGe.server.Dto;

public record MemberDto(
    int MemberId,
    string FirstName,
    string LastName,
    string Ssr,
    string Avatar
);