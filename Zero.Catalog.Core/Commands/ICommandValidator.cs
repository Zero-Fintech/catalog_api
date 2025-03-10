using FluentValidation.Results;

namespace Zero.Catalog.Core.Commands;

public interface ICommandValidator<in TCommand>
{
    Task<ValidationResult> ValidateCommand(TCommand command);
}