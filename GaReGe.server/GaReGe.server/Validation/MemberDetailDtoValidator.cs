using System.Globalization;
using System.Text.RegularExpressions;
using FluentValidation;
using GaReGe.server.Data;
using GaReGe.server.Dto;
using LanguageExt;
using Microsoft.EntityFrameworkCore;

namespace GaReGe.server.Validation;

public class MemberDetailDtoValidator : AbstractValidator<MemberDetailDto> {
    private readonly GaregeDbContext _context;


    public MemberDetailDtoValidator(GaregeDbContext context) {
        _context = context;
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("First name is required");
        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("Last name is required");
        RuleFor(x => x.Avatar)
            .NotEmpty()
            .WithMessage("Avatar is required");
        // RuleFor(x => x.Ssr)
        RuleFor(x => x.Ssr)
            .NotEmpty()
            .WithMessage("SSR is required")
            .MustAsync(async (dto, ssr, cancellation) => await SsrIsUnique(dto))
            .WithMessage("SSR must be unique")
            .Must(SsrIsValidFormat)
            .WithMessage("SSR must be in the format 'yyyyMMdd-xxxx'");
    }

    private bool SsrIsValidFormat(string ssr) {
        if (!Regex.IsMatch(ssr, @"^\d{8}-\d{4}$"))
            return false;

        var datePart = ssr.Split('-')[0];
        var parseResult = DateTime.TryParseExact(datePart, "yyyyMMdd", CultureInfo.InvariantCulture,
            DateTimeStyles.None, out var result);

        return parseResult;
    }

    
    
    private async Task<bool> SsrIsUnique(MemberDetailDto dto) {
        var searchResult = await _context.Members
            .FirstOrDefaultAsync(m => m.Ssr == dto.Ssr && m.MemberId != dto.MemberId);

        return searchResult == null;
    }
    
    //
    //
    // private bool SsrIsUnique(MemberDetailDto dto) {
    //     var searchResult = _context.Members
    //         .FirstOrDefault(m => m.Ssr == dto.Ssr && m.MemberId != dto.MemberId);
    //
    //     return searchResult.IsNull();
    // }
}