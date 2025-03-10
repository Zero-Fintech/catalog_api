using FluentValidation;
using FluentValidation.Results;

namespace Zero.Catalog.Core.Queries;
public abstract class BaseQueryValidator<TQuery, TResult> : AbstractValidator<TQuery>, IQueryValidator<TQuery>
    where TQuery : IQuery<TResult>
{
    public Task<ValidationResult> ValidateQuery(TQuery query)
    {
        return ValidateAsync(query);
    }
}