using FluentValidation;
using GaReGe.server.Dto;

namespace GaReGe.server.Validation;

public class CreateMemberDtoValidator : AbstractValidator<CreateMemberDto> {

    public CreateMemberDtoValidator() {



        RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required."); 
        RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required."); 
        
    }
    
}