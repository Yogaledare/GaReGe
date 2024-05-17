using GaReGe.server.Data;
using GaReGe.server.Dto;
using GaReGe.server.Entity;
using LanguageExt.Common;
using Microsoft.EntityFrameworkCore;

namespace GaReGe.server.Repositories;

public interface IMemberRepository {
    Task<IEnumerable<MemberDto>> GetAllMembers();
    Task<Result<MemberDto>> CreateMember(CreateMemberDto dto);
    Task<bool> DeleteAllMembers();
    Task<Result<MemberDetailDto>> GetMember(int id);
}

public class MemberRepository : IMemberRepository {
    private readonly GaregeDbContext _context;

    public MemberRepository(GaregeDbContext context) {
        _context = context;
    }

    public async Task<IEnumerable<MemberDto>> GetAllMembers() {
        var list = await _context.Members.Select(m => MemberToMemberDto(m)).ToListAsync();
        return list;
    }

    public async Task<Result<MemberDetailDto>> GetMember(int id) {
        var member = await _context.Members.FirstOrDefaultAsync(m => m.MemberId == id);

        if (member == null) {
            var error = new ArgumentException($"cannot find member {id}");
            return new Result<MemberDetailDto>(error);
        }

        var memberDetailDto = MemberToMemberDetailDto(member);

        return memberDetailDto;
    }

    public async Task<Result<MemberDto>> CreateMember(CreateMemberDto dto) {
        var queryResult = await _context.Members.FirstOrDefaultAsync(m => m.Ssr == dto.Ssr);

        if (queryResult != null) {
            var error = new ArgumentException("Ssr already in database");
            return new Result<MemberDto>(error);
        }

        var newMember = CreateMemberDtoToMember(dto);
        _context.Members.Add(newMember);
        await _context.SaveChangesAsync();
        var memberDto = MemberToMemberDto(newMember);

        return new Result<MemberDto>(memberDto);
    }

    private static Member CreateMemberDtoToMember(CreateMemberDto dto) {
        return new Member {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Ssr = dto.Ssr, 
            Avatar = dto.Avatar
        };
    }

    private static MemberDto MemberToMemberDto(Member member) {
        return new MemberDto(member.MemberId, member.FirstName, member.LastName, member.Ssr);
    }

    private static MemberDetailDto MemberToMemberDetailDto(Member member) {
        return new MemberDetailDto(member.MemberId, member.FirstName, member.LastName, member.Ssr, member.Avatar);
    }

    public async Task<bool> DeleteAllMembers() {
        var members = await _context.Members.ToListAsync();

        if (!members.Any()) {
            return false;
        }

        _context.Members.RemoveRange(members);
        await _context.SaveChangesAsync();

        return true;
    }
}