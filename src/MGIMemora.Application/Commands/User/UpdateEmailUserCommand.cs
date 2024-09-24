using FluentValidation;
using MGIMemora.Domain.Commands;

namespace MGIMemora.Application.Commands.User;


    public class UpdateEmailUserCommand : ICommand
    {
        public int Id { get; set; } = default!;
        public String Email { get; set; } = default!;
    }

public class UpdateEmailUserValidator : AbstractValidator<UpdateEmailUserCommand>
{
    public UpdateEmailUserValidator()
    {
        RuleFor(p => p.Id).NotEmpty().WithMessage("Id Obrigatorio");
        RuleFor(p => p.Email).EmailAddress().WithMessage("Email Invalido");
        RuleFor(p => p.Email).NotEmpty().WithMessage("Email e Obrigatorio");
    }
}


