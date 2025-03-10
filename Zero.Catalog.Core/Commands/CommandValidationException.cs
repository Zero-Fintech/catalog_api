using FluentValidation.Results;

namespace Zero.Catalog.Core.Commands;

public class CommandValidationException : ApplicationValidationException
{
    public CommandValidationException(string message) : base(message)
    {
    }

    public CommandValidationException(ValidationResult results) : base(results)
    {
    }
}