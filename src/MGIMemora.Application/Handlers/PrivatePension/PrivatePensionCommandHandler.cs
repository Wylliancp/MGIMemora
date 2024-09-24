using FluentValidation;
using MGIMemora.Application.Commands;
using MGIMemora.Application.Commands.PrivatePension;
using MGIMemora.Domain.Commands;
using MGIMemora.Domain.Handlers;
using MGIMemora.Domain.Repositories;

namespace MGIMemora.Application.Handlers.PrivatePension
{

    public class PrivatePensionCommandHandler : ICommandHandler<CreatePrivatePensionCommand>,
                                                ICommandHandler<UpdateModalityPrivatePensionCommand>,
                                                ICommandHandler<UpdatePrivatePensionCommand>,
                                                ICommandHandler<DeletePrivatePensionCommand>
    {

        private readonly IPrivatePensionRepository _privatePensionRepository;
        private IValidator<CreatePrivatePensionCommand> _validatorCreate;
        private IValidator<UpdatePrivatePensionCommand> _validatorUpdate;
        private IValidator<UpdateModalityPrivatePensionCommand> _validatorUpdateModality;
        private IValidator<DeletePrivatePensionCommand> _validatorDelete;

        public PrivatePensionCommandHandler(IPrivatePensionRepository privatePensionRepository,
            IValidator<CreatePrivatePensionCommand> validatorCreate,
            IValidator<UpdatePrivatePensionCommand> validatorUpdate,
            IValidator<UpdateModalityPrivatePensionCommand> validatorUpdateModality,
            IValidator<DeletePrivatePensionCommand> validatorDelete
            )
        {
            _privatePensionRepository = privatePensionRepository;
            _validatorCreate = validatorCreate;
            _validatorUpdate = validatorUpdate;
            _validatorUpdateModality = validatorUpdateModality;
            _validatorDelete = validatorDelete;
        }

        public async Task<ICommandResult> Handle(CreatePrivatePensionCommand command)
        {

            var result = await _validatorCreate.ValidateAsync(command);

            if (result.IsValid)
            {

                if (command is null) return new GenericResultCommand(false, "Dados Invalidos!");

                var privatePension = new MGIMemora.Domain.Entities.PrivatePension(command.Name, command.BenefitName, command.Modality, command.ValueMillions, command.SponsorshipCompany);

                await _privatePensionRepository.CreateAsync(privatePension);

                return new GenericResultCommand(true, "Criado com Sucesso!");

            }

            return new GenericResultCommand(false, "Dados Invalidos!", result.Errors);
        }

        public async Task<ICommandResult> Handle(UpdateModalityPrivatePensionCommand command)
        {

            var result = await _validatorUpdateModality.ValidateAsync(command);

            if (result.IsValid)
            {

                var privatePension = await _privatePensionRepository.GetByIdAsync(command.Id);

                privatePension.UpdateModality(command.Modality);

                await _privatePensionRepository.UpdateAsync(privatePension);

                return new GenericResultCommand(true, "Modalidade atualizado com Sucesso!");

            }

            return new GenericResultCommand(false, "Dados Invalidos!", result.Errors);

        }

        public async Task<ICommandResult> Handle(UpdatePrivatePensionCommand command)
        {

            var result = await _validatorUpdate.ValidateAsync(command);

            if (result.IsValid)
            {

                var privatePension = await _privatePensionRepository.GetByIdAsync(command.Id);

                privatePension.Update(command.Name, command.BenefitName, command.ValueMillions, command.SponsorshipCompany);

                await _privatePensionRepository.UpdateAsync(privatePension);

                return new GenericResultCommand(true, "Atualizado com Sucesso!");
            }

            return new GenericResultCommand(false, "Dados Invalidos!", result.Errors);
        }

        public async Task<ICommandResult> Handle(DeletePrivatePensionCommand command)
        {

            var result = await _validatorDelete.ValidateAsync(command);

            if (result.IsValid)
            {

                await _privatePensionRepository.DeleteAsync(command.Id);

                return new GenericResultCommand(true, "Deletado com Sucesso!");
            }

            return new GenericResultCommand(false, "Dados Invalidos!", result.Errors);
        }
    }
}