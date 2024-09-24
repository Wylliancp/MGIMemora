using FluentValidation;
using MGIMemora.Application.Commands;
using MGIMemora.Application.Commands.User;
using MGIMemora.Domain.Commands;
using MGIMemora.Domain.Handlers;
using MGIMemora.Domain.Repositories;

namespace MGIMemora.Application.Handlers.User
{

    public class UserCommandHandler : ICommandHandler<CreateUserCommand>,
                                                ICommandHandler<UpdateEmailUserCommand>,
                                                ICommandHandler<UpdateRolesUserCommand>,
                                                ICommandHandler<DeleteUserCommand>
    {

        private readonly IUserRepository _userRepository;
        private IValidator<CreateUserCommand> _validatorCreate;
        private IValidator<UpdateEmailUserCommand> _validatorUpdateEmail;
        private IValidator<UpdateRolesUserCommand> _validatorUpdateRoles;
        private IValidator<DeleteUserCommand> _validatorDelete;

        public UserCommandHandler(IUserRepository userRepository,
            IValidator<CreateUserCommand> validatorCreate,
            IValidator<UpdateEmailUserCommand> validatorUpdateEmail,
            IValidator<UpdateRolesUserCommand> validatorUpdateRoles,
            IValidator<DeleteUserCommand> validatorDelete
            )
        {
            _userRepository = userRepository;
            _validatorCreate = validatorCreate;
            _validatorUpdateEmail = validatorUpdateEmail;
            _validatorUpdateRoles = validatorUpdateRoles;
            _validatorDelete = validatorDelete;
        }

        public async Task<ICommandResult> Handle(CreateUserCommand command)
        {

            var result = await _validatorCreate.ValidateAsync(command);

            if (result.IsValid)
            {

                if (command is null) return new GenericResultCommand(false, "Dados Invalidos!");

                var user = new MGIMemora.Domain.Entities.User(command.Email, command.Password, command.Roles);

                await _userRepository.CreateAsync(user);

                return new GenericResultCommand(true, "Criado com Sucesso!");

            }

            return new GenericResultCommand(false, "Dados Invalidos!", result.Errors);
        }

        public async Task<ICommandResult> Handle(UpdateEmailUserCommand command)
        {

            var result = await _validatorUpdateEmail.ValidateAsync(command);

            if (result.IsValid)
            {

                var user = await _userRepository.GetByIdAsync(command.Id);

                user.UpdateEmail(command.Email);

                await _userRepository.UpdateAsync(user);

                return new GenericResultCommand(true, "Email atualizado com Sucesso!");

            }

            return new GenericResultCommand(false, "Dados Invalidos!", result.Errors);

        }

        public async Task<ICommandResult> Handle(UpdateRolesUserCommand command)
        {

            var result = await _validatorUpdateRoles.ValidateAsync(command);

            if (result.IsValid)
            {

                var user = await _userRepository.GetByIdAsync(command.Id);

                user.UpdateRoles(command.Roles);

                await _userRepository.UpdateAsync(user);

                return new GenericResultCommand(true, "Atualizado com Sucesso!");
            }

            return new GenericResultCommand(false, "Dados Invalidos!", result.Errors);
        }

        public async Task<ICommandResult> Handle(DeleteUserCommand command)
        {

            var result = await _validatorDelete.ValidateAsync(command);

            if (result.IsValid)
            {

                await _userRepository.DeleteAsync(command.Id);

                return new GenericResultCommand(true, "Deletado com Sucesso!");
            }

            return new GenericResultCommand(false, "Dados Invalidos!", result.Errors);
        }
    }
}