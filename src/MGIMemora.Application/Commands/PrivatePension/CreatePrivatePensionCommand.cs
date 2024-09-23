using FluentValidation;
using MGIMemora.Domain.Commands;

namespace MGIMemora.Application.Commands.PrivatePension
{

    public class CreatePrivatePensionCommand : ICommand
    {
        public String Name { get; set; } = default!;
        public String BenefitName { get; set; } = default!;
        public String Modality { get; set; } = default!;
        public Decimal ValueMillions { get; set; } = default!;
        public String SponsorshipCompany { get; set; } = default!;  
    }

    public class CreatePrivatePensionValidator : AbstractValidator<CreatePrivatePensionCommand>
    {
        public CreatePrivatePensionValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Nome e Obrigatorio");
            RuleFor(p => p.BenefitName).NotEmpty().WithMessage("Nome do Beneficiario e Obrigatorio");
            RuleFor(p => p.Modality).NotEmpty().WithMessage("Nome da modalidade e Obrigatorio");
            RuleFor(p => p.ValueMillions).Equal(0).WithMessage("Valor invalido");
        }
    }


}

