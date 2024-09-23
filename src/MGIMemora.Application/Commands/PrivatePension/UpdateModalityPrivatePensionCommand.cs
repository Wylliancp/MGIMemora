using MGIMemora.Domain.Commands;

namespace MGIMemora.Application.Commands.PrivatePension
{

    public class UpdateModalityPrivatePensionCommand : ICommand
    {
        public int Id { get; set; } = default!;
        public String Modality { get; set; } = default!;
    }
    
}