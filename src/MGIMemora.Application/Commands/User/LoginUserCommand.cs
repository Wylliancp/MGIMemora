using FluentValidation;
using MGIMemora.Domain.Commands;

namespace MGIMemora.Application.Commands.User
{

    public class LoginUserCommand : ICommand
    {
        public String Email { get; set; } = default!;
        public String Password { get; set; } = default!;
    }

    public class LoginUserValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserValidator()
        {
            RuleFor(p => p.Email).EmailAddress().WithMessage("Email invalido!");
            RuleFor(p => p.Password).NotEmpty().WithMessage("Password e Obrigatorio");
        }
    }


}

