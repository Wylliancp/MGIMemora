using FluentValidation;
using MGIMemora.Domain.Commands;

namespace MGIMemora.Application.Commands.PrivatePension;

public class DeletePrivatePensionCommand : ICommand
{
    public int Id { get; set; }

}

public class DeletePrivatePensionValidator : AbstractValidator<DeletePrivatePensionCommand>
{
    public DeletePrivatePensionValidator()
    {
        RuleFor(p => p.Id).NotEmpty().WithMessage("Id e Obrigatorio");
    }
}

