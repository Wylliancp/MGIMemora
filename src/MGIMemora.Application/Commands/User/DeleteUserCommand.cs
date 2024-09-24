using FluentValidation;
using MGIMemora.Domain.Commands;

namespace MGIMemora.Application.Commands.User;

public class DeleteUserCommand : ICommand
{
    public int Id { get; set; }

}

public class DeleteUserValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserValidator()
    {
        RuleFor(p => p.Id).NotEmpty().WithMessage("Id e Obrigatorio");
    }
}

