using FluentValidation;
using MGIMemora.Application.Commands;
using MGIMemora.Application.Commands.PrivatePension;
using MGIMemora.Domain.Commands;
using MGIMemora.Domain.Handlers;
using MGIMemora.Domain.Repositories;

namespace MGIMemora.Application.Handlers.PrivatePension
{

    public class PrivatePensionCommandHandler(
        IPrivatePensionRepository privatePensionRepository,
        IValidator<CreatePrivatePensionCommand> validatorCreate,
        IValidator<UpdatePrivatePensionCommand> validatorUpdate,
        IValidator<UpdateModalityPrivatePensionCommand> validatorUpdateModality,
        IValidator<DeletePrivatePensionCommand> validatorDelete)
        : ICommandHandler<CreatePrivatePensionCommand>,
            ICommandHandler<UpdateModalityPrivatePensionCommand>,
            ICommandHandler<UpdatePrivatePensionCommand>,
            ICommandHandler<DeletePrivatePensionCommand>
    {
        public async Task<ICommandResult> Handle(CreatePrivatePensionCommand command)
        {

            var result = await validatorCreate.ValidateAsync(command);

            if (result.IsValid)
            {

                if (command is null) return new GenericResultCommand(false, "Dados Invalidos!");

                var privatePension = new MGIMemora.Domain.Entities.PrivatePension(command.Name, command.BenefitName, command.Modality, command.ValueMillions, command.SponsorshipCompany);

                await privatePensionRepository.CreateAsync(privatePension);

                return new GenericResultCommand(true, "Criado com Sucesso!");

            }

            return new GenericResultCommand(false, "Dados Invalidos!", result.Errors);
        }

        public async Task<ICommandResult> Handle(UpdateModalityPrivatePensionCommand command)
        {

            var result = await validatorUpdateModality.ValidateAsync(command);

            if (result.IsValid)
            {

                var privatePension = await privatePensionRepository.GetByIdAsync(command.Id);

                privatePension.UpdateModality(command.Modality);

                await privatePensionRepository.UpdateAsync(privatePension);

                return new GenericResultCommand(true, "Modalidade atualizado com Sucesso!");

            }

            return new GenericResultCommand(false, "Dados Invalidos!", result.Errors);

        }

        public async Task<ICommandResult> Handle(UpdatePrivatePensionCommand command)
        {

            var result = await validatorUpdate.ValidateAsync(command);

            if (result.IsValid)
            {

                var privatePension = await privatePensionRepository.GetByIdAsync(command.Id);

                privatePension.Update(command.Name, command.BenefitName, command.ValueMillions, command.SponsorshipCompany);

                await privatePensionRepository.UpdateAsync(privatePension);

                return new GenericResultCommand(true, "Atualizado com Sucesso!");
            }

            return new GenericResultCommand(false, "Dados Invalidos!", result.Errors);
        }

        public async Task<ICommandResult> Handle(DeletePrivatePensionCommand command)
        {

            var result = await validatorDelete.ValidateAsync(command);

            if (result.IsValid)
            {

                await privatePensionRepository.DeleteAsync(command.Id);

                return new GenericResultCommand(true, "Deletado com Sucesso!");
            }

            return new GenericResultCommand(false, "Dados Invalidos!", result.Errors);
        }
    }
}