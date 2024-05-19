using FluentValidation;
using GaReGe.server.Dto;

namespace GaReGe.server.Validation;

public class VehicleCreateDtoValidator : AbstractValidator<VehicleCreateDto> {
    public VehicleCreateDtoValidator() {
        RuleFor(x => x.LicensePlate)
            .NotEmpty()
            .WithMessage("LicensePlate is required.");
        RuleFor(x => x.Color)
            .NotEmpty()
            .WithMessage("Color is required.");
        RuleFor(x => x.Brand)
            .NotEmpty()
            .WithMessage("Brand is required.");
        RuleFor(x => x.Model)
            .NotEmpty()
            .WithMessage("Model is required.");
        RuleFor(x => x.NumWheels)
            .NotEmpty()
            .WithMessage("NumWheels is required.");
        RuleFor(x => x.MemberId)
            .NotEmpty()
            .WithMessage("MemberId is required.");
        RuleFor(x => x.VehicleTypeId)
            .NotEmpty()
            .WithMessage("VehicleTypeId is required.");
    }
}