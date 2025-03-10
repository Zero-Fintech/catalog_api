using FluentValidation.Results;

namespace Zero.Catalog.Core.Queries;

public interface IQueryValidator<in TQuery>
{
    Task<ValidationResult> ValidateQuery(TQuery command);
}