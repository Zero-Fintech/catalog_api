using FluentValidation.Results;

namespace Zero.Catalog.Core;

public abstract class ApplicationValidationException : Exception
{
    private const string _defaultMessage = "Validation failed";

    protected ApplicationValidationException(string message) :
        base(message)
    {
    }

    protected ApplicationValidationException(ValidationResult results) : base(_defaultMessage)
    {
        var errorsByPropertyName = results.Errors.GroupBy(x => x.PropertyName);

        Errors = errorsByPropertyName.ToDictionary(x => x.Key, x =>
        {
            return string.Join(';', x.Select(r => r.ErrorMessage));
        });
    }

    public Dictionary<string, string> Errors { get; } = new();
}