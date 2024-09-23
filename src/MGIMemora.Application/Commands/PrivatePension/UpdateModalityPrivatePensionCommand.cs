using FluentValidation;
using MGIMemora.Domain.Commands;

namespace MGIMemora.Application.Commands.PrivatePension;


    public class UpdateModalityPrivatePensionCommand : ICommand
    {
        public int Id { get; set; } = default!;
        public String Modality { get; set; } = default!;
    }

public class UpdateModalityPrivatePensionValidator : AbstractValidator<UpdateModalityPrivatePensionCommand>
{
    public UpdateModalityPrivatePensionValidator()
    {
        RuleFor(p => p.Id).NotEmpty().WithMessage("Id Obrigatorio");
        RuleFor(p => p.Modality).NotEmpty().WithMessage("Nome da modalidade e Obrigatorio");
    }
}


