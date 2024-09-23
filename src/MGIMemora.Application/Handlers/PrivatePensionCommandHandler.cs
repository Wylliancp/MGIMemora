using MGIMemora.Application.Commands;
using MGIMemora.Application.Commands.PrivatePension;
using MGIMemora.Domain.Commands;
using MGIMemora.Domain.Entities;
using MGIMemora.Domain.Handlers;
using MGIMemora.Domain.Repositories;

namespace MGIMemora.Application.Handlers
{

    public class PrivatePensionCommandHandler : ICommandHandler<CreatePrivatePensionCommand>, 
                                                ICommandHandler<UpdateModalityPrivatePensionCommand>, 
                                                ICommandHandler<UpdatePrivatePensionCommand>, 
                                                ICommandHandler<DeletePrivatePensionCommand>
    {

        private readonly IPrivatePensionRepository _privatePensionRepository;
        public PrivatePensionCommandHandler(IPrivatePensionRepository privatePensionRepository)
        {
            _privatePensionRepository = privatePensionRepository;
        }

        public async Task<ICommandResult> Handle(CreatePrivatePensionCommand command)
        {
            if (command is null) return new GenericResultCommand(false, "Dados Invalidos!");

            var privatePension = new PrivatePension(command.Name, command.BenefitName, command.Modality, command.ValueMillions, command.SponsorshipCompany);

            await _privatePensionRepository.CreateAsync(privatePension);

            return new GenericResultCommand(true, "Criado com Sucesso!");
        }

        public async Task<ICommandResult> Handle(UpdateModalityPrivatePensionCommand command)
        {
            if (command is null) return new GenericResultCommand(false, "Dados Invalidos!");

            var privatePension = await _privatePensionRepository.GetByIdAsync(command.Id);

            privatePension.UpdateModality(command.Modality);

            await _privatePensionRepository.UpdateAsync(privatePension);

            return new GenericResultCommand(true, "Modalidade atualizado com Sucesso!");
        }

        public async Task<ICommandResult> Handle(UpdatePrivatePensionCommand command)
        {
            if (command is null) return new GenericResultCommand(false, "Dados Invalidos!");

            var privatePension = await _privatePensionRepository.GetByIdAsync(command.Id);

            privatePension.Update(command.Name, command.BenefitName, command.ValueMillions, command.SponsorshipCompany);

            await _privatePensionRepository.UpdateAsync(privatePension);

            return new GenericResultCommand(true, "Atualizado com Sucesso!");
        }

        public async Task<ICommandResult> Handle(DeletePrivatePensionCommand command)
        {
            if (command is null) return new GenericResultCommand(false, "Dados Invalidos!");

            await _privatePensionRepository.DeleteAsync(command.Id);

            return new GenericResultCommand(true, "Deletado com Sucesso!");
        }
    }
}