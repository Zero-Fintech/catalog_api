using FluentValidation;
using FluentValidation.Results;

namespace Zero.Catalog.Core.Commands;

public abstract class BaseCommandValidator<TCommand> : AbstractValidator<TCommand>, ICommandValidator<TCommand>
    where TCommand : ICommand
{
    public Task<ValidationResult> ValidateCommand(TCommand command)
    {
        return ValidateAsync(command);
    }
}