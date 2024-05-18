using GaReGe.server.Data;
using GaReGe.server.Dto;
using GaReGe.server.Entity;
using LanguageExt.Common;
using Microsoft.EntityFrameworkCore;

namespace GaReGe.server.Repositories;

public interface IMemberRepository {
    Task<IEnumerable<MemberDto>> GetAllMembers();
    Task<Result<MemberDetailDto>> CreateMember(MemberDetailDto dto);
    Task<bool> DeleteAllMembers();
    Task<Result<MemberDetailDto>> GetMember(int id);
    Task<Result<MemberDetailDto>> UpdateMember(MemberDetailDto dto);
    Task<Result<MemberDetailDto>> DeleteMember(int id);
}

public class MemberRepository : IMemberRepository {
    private readonly GaregeDbContext _context;

    public MemberRepository(GaregeDbContext context) {
        _context = context;
    }

    public async Task<IEnumerable<MemberDto>> GetAllMembers() {
        var list = await _context.Members.Select(m => EntityToDto(m)).ToListAsync();
        return list;
    }

    public async Task<Result<MemberDetailDto>> GetMember(int id) {
        var member = await _context.Members.FirstOrDefaultAsync(m => m.MemberId == id);

        if (member == null) {
            var error = new ArgumentException($"cannot find member {id}");
            return new Result<MemberDetailDto>(error);
        }

        var memberDetailDto = EntityToDetailDto(member);

        return memberDetailDto;
    }

    public async Task<Result<MemberDetailDto>> CreateMember(MemberDetailDto dto) {
        var queryResult = await _context.Members.FirstOrDefaultAsync(m => m.Ssr == dto.Ssr);

        if (queryResult != null) {
            var error = new ArgumentException("Ssr already in database");
            return new Result<MemberDetailDto>(error);
        }

        var newMember = DetailDtoToEntity(dto);
        _context.Members.Add(newMember);
        await _context.SaveChangesAsync();
        var memberDto = EntityToDetailDto(newMember);

        return new Result<MemberDetailDto>(memberDto);
    }

    public async Task<Result<MemberDetailDto>> UpdateMember(MemberDetailDto dto) {
        var member = await _context.Members.FirstOrDefaultAsync(m => m.MemberId == dto.MemberId);

        if (member == null) {
            var error = new ArgumentException($"Cannot find member {dto.MemberId}");
            return new Result<MemberDetailDto>(error);
        }

        member = DetailDtoToEntity(dto);
        await _context.SaveChangesAsync();

        return EntityToDetailDto(member);
    }

    public async Task<Result<MemberDetailDto>> DeleteMember(int id) {
        var member = await _context.Members.FirstOrDefaultAsync(m => m.MemberId == id);

        if (member == null) {
            var error = new ArgumentException($"Cannot find member {id}");
            return new Result<MemberDetailDto>(error);
        }

        _context.Members.Remove(member);
        await _context.SaveChangesAsync();
        
        return EntityToDetailDto(member);
    }

    public async Task<bool> DeleteAllMembers() {
        var members = await _context.Members.ToListAsync();

        if (!members.Any()) return false;

        _context.Members.RemoveRange(members);
        await _context.SaveChangesAsync();

        return true;
    }

    private static Member DetailDtoToEntity(MemberDetailDto dto) {
        return new Member {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Ssr = dto.Ssr,
            Avatar = dto.Avatar,
            Description = dto.Description
        };
    }

    private static MemberDto EntityToDto(Member member) {
        return new MemberDto(member.MemberId, member.FirstName, member.LastName, member.Ssr, member.Avatar);
    }

    private static MemberDetailDto EntityToDetailDto(Member member) {
        return new MemberDetailDto(member.MemberId, member.FirstName, member.LastName, member.Ssr, member.Avatar,
            member.Description);
    }
}