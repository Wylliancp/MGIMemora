using FluentValidation.Results;
using MGIMemora.Domain.Commands;

namespace MGIMemora.Application.Commands;

public class GenericResultCommand : ICommandResult

{
    public GenericResultCommand(bool success, string message, List<ValidationFailure> errors = default!, object? data = default)
    {
        Success = success;
        Message = message;
        Errors = errors;
        Data = data;
    }

    public bool Success { get; private set; }
    public string Message { get; private set; }
    public List<ValidationFailure>? Errors { get; private set; }
    public object? Data { get; private set; }
}
