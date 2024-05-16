using GaReGe.server.Dto;
using GaReGe.server.Entity;
using LanguageExt.Common;

namespace GaReGe.server.Repositories;

public interface IMemberRepository {
    Task<IEnumerable<MemberDto>> GetAllMembers();
    Task<Result<MemberDto>> GetMember(int id);
    Task<Result<MemberDto>> CreateMember(CreateMemberDto dto);
    Task<bool> DeleteAllMembers(); 
}