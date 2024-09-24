using FluentValidation;
using MGIMemora.Domain.Commands;

namespace MGIMemora.Application.Commands.User
{

    public class CreateUserCommand : ICommand
    {
        public String Email { get; set; } = default!;
        public String Password { get; set; } = default!;
        public String[] Roles { get; set; } = default!;
    }

    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(p => p.Email).EmailAddress().WithMessage("Email invalido!");
            RuleFor(p => p.Password).NotEmpty().WithMessage("Password e Obrigatorio");
        }
    }


}

