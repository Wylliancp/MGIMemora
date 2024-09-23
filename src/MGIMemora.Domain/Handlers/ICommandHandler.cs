using MGIMemora.Domain.Commands;

namespace MGIMemora.Domain.Handlers
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task<ICommandResult> Handle(T command);
    }
}
