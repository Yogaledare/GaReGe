namespace GaReGe.server.Entity;

public class Member {
    public int MemberId { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Ssr { get; set; } = default!;
    public string Avatar { get; set; } = default!;
}