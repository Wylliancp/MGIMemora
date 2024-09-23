using MGIMemora.Domain.Commands;

namespace MGIMemora.Application.Commands.PrivatePension
{

    public class DeletePrivatePensionCommand : ICommand
    {
        public int Id { get; set; }

    }
    
}