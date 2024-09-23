using FluentValidation;
using MGIMemora.Domain.Commands;

namespace MGIMemora.Application.Commands.PrivatePension;


public class UpdatePrivatePensionCommand : ICommand
{
    public int Id { get; set; } = default!;
    public String Name { get; set; } = default!;
    public String BenefitName { get; set; } = default!;
    public String Modality { get; set; } = default!;
    public Decimal ValueMillions { get; set; } = default!;
    public String SponsorshipCompany { get; set; } = default!;
}

public class UpdatePrivatePensionValidator : AbstractValidator<UpdatePrivatePensionCommand>
{
    public UpdatePrivatePensionValidator()
    {
        RuleFor(p => p.Id).NotEmpty().WithMessage("Id Obrigatorio");
    }
}