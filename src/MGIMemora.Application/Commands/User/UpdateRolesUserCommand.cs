using FluentValidation;
using MGIMemora.Domain.Commands;

namespace MGIMemora.Application.Commands.User;


public class UpdateRolesUserCommand : ICommand
{
    public int Id { get; set; } = default!;
    public String[] Roles { get; set; } = default!;
}

public class UpdateRolesUserValidator : AbstractValidator<UpdateRolesUserCommand>
{
    public UpdateRolesUserValidator()
    {
        RuleFor(p => p.Id).NotEmpty().WithMessage("Id Obrigatorio");
        RuleFor(p => p.Roles).NotEmpty().WithMessage("Roles Obrigatorio");
    }
}