namespace GaReGe.server.Dto;

public record MemberDetailDto(
    int MemberId,
    string FirstName,
    string LastName,
    string Ssr,
    string Avatar
);