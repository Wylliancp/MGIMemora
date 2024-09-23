using FluentValidation.Results;
using MGIMemora.Domain.Commands;

namespace MGIMemora.Application.Commands;

public class GenericResultCommand : ICommandResult

{
    public GenericResultCommand(bool success, string message, List<ValidationFailure> errors = default!)
    {
        Success = success;
        Message = message;
        Errors = errors;
    }

    public bool Success { get; private set; }
    public string Message { get; private set; }
    public List<ValidationFailure>? Errors { get; private set; }
}
