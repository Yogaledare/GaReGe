using System.Globalization;
using FluentValidation;
using GaReGe.server.Data;
using GaReGe.server.Dto;
using LanguageExt;
using Microsoft.EntityFrameworkCore;

namespace GaReGe.server.Validation;

public class SetMemberDtoValidator : AbstractValidator<SetMemberDto> {

    private readonly GaregeDbContext _context;

    
    public SetMemberDtoValidator(GaregeDbContext context) {
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
        RuleFor(x => x.Ssr)
            .NotEmpty()
            .WithMessage("SSR is required")
            .Must(SsrIsUnique)
            .WithMessage("SSR must be unique")
            .Must(SsrIsValidFormat)
            .WithMessage("SSR must be in the format 'yyyyMMdd-xxxx'")
            ;
    }

    private bool SsrIsValidFormat(string ssr) {
        if (!System.Text.RegularExpressions.Regex.IsMatch(ssr, @"^\d{8}-\d{4}$"))
            return false;

        var datePart = ssr.Split('-')[0];
        var parseResult = DateTime.TryParseExact(datePart, "yyyyMMdd", CultureInfo.InvariantCulture,
            DateTimeStyles.None, out var result);

        return parseResult;
    }


    private bool SsrIsUnique(string ssr) {
        var searchResult = _context.Members.FirstOrDefaultAsync(m => m.Ssr == ssr);

        return searchResult.IsNull(); 
    }
}