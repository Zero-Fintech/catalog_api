using FluentValidation.Results;

namespace Zero.Catalog.Core.Queries;

public class QueryValidationException : ApplicationValidationException
{
    public QueryValidationException(string message) : base(message)
    {
    }

    public QueryValidationException(ValidationResult results) : base(results)
    {
    }
}