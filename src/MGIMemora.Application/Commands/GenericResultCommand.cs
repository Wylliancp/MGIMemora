using MGIMemora.Domain.Commands;

namespace MGIMemora.Application.Commands
{
    public class GenericResultCommand : ICommandResult

    {
        public GenericResultCommand(bool success, string message)
        {
            Success = success;
            Message = message;
        }

       public bool Success { get; private set; }
       public string Message { get; private set; }
    }
}