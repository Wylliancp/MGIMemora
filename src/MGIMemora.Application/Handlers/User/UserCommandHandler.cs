using FluentValidation;
using MGIMemora.Application.Commands;
using MGIMemora.Application.Commands.User;
using MGIMemora.Application.Services;
using MGIMemora.Domain.Commands;
using MGIMemora.Domain.Handlers;
using MGIMemora.Domain.Repositories;

namespace MGIMemora.Application.Handlers.User
{

    public class UserCommandHandler(
        IUserRepository userRepository,
        IValidator<CreateUserCommand> validatorCreate,
        IValidator<UpdateEmailUserCommand> validatorUpdateEmail,
        IValidator<UpdateRolesUserCommand> validatorUpdateRoles,
        IValidator<DeleteUserCommand> validatorDelete,
        IValidator<LoginUserCommand> validatorLogin)
        : ICommandHandler<CreateUserCommand>,
            ICommandHandler<UpdateEmailUserCommand>,
            ICommandHandler<UpdateRolesUserCommand>,
            ICommandHandler<DeleteUserCommand>,
            ICommandHandler<LoginUserCommand>
    {
        public async Task<ICommandResult> Handle(CreateUserCommand command)
        {

            var result = await validatorCreate.ValidateAsync(command);

            if (result.IsValid)
            {

                if (command is null) return new GenericResultCommand(false, "Dados Invalidos!");

                var user = new MGIMemora.Domain.Entities.User(command.Email, command.Password.ComputeHash(), command.Roles);

                await userRepository.CreateAsync(user);

                return new GenericResultCommand(true, "Criado com Sucesso!");

            }

            return new GenericResultCommand(false, "Dados Invalidos!", result.Errors);
        }

        public async Task<ICommandResult> Handle(UpdateEmailUserCommand command)
        {

            var result = await validatorUpdateEmail.ValidateAsync(command);

            if (result.IsValid)
            {

                var user = await userRepository.GetByIdAsync(command.Id);

                user.UpdateEmail(command.Email);

                await userRepository.UpdateAsync(user);

                return new GenericResultCommand(true, "Email atualizado com Sucesso!");

            }

            return new GenericResultCommand(false, "Dados Invalidos!", result.Errors);

        }

        public async Task<ICommandResult> Handle(UpdateRolesUserCommand command)
        {

            var result = await validatorUpdateRoles.ValidateAsync(command);

            if (result.IsValid)
            {

                var user = await userRepository.GetByIdAsync(command.Id);

                user.UpdateRoles(command.Roles);

                await userRepository.UpdateAsync(user);

                return new GenericResultCommand(true, "Atualizado com Sucesso!");
            }

            return new GenericResultCommand(false, "Dados Invalidos!", result.Errors);
        }

        public async Task<ICommandResult> Handle(DeleteUserCommand command)
        {

            var result = await validatorDelete.ValidateAsync(command);

            if (result.IsValid)
            {

                await userRepository.DeleteAsync(command.Id);

                return new GenericResultCommand(true, "Deletado com Sucesso!");
            }

            return new GenericResultCommand(false, "Dados Invalidos!", result.Errors);
        }

        public async Task<ICommandResult> Handle(LoginUserCommand command)
        {
            var result = await validatorLogin.ValidateAsync(command);

            if (result.IsValid)
            {

                var user = await userRepository.LoginAsync(command.Email, command.Password.ComputeHash());

                if(user is null)
                    return new GenericResultCommand(true, "Usúario ou senha inválido");
            
                var token = TokenService.GenerateToken(user);

                var loginViewModel = new { email = user.Email, Role = user.Roles.First(), token = token};

                return new GenericResultCommand(true, "Login com Sucesso!", default!, loginViewModel);
            }

            return new GenericResultCommand(false, "Dados Invalidos!", result.Errors);        }
    }
}