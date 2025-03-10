using FluentValidation.Results;

namespace Zero.Catalog.Core.Queries;

public class ValidationQueryHandlerDecorator<TQuery, TResult> : IQueryHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
{
    private readonly IQueryValidator<TQuery>? _validator;
    private readonly IQueryHandler<TQuery, TResult> _decoratee;

    public ValidationQueryHandlerDecorator(IQueryHandler<TQuery, TResult> decoratee, IQueryValidator<TQuery>? validator = null)
    {
        _validator = validator;
        _decoratee = decoratee;
    }

    public async Task<TResult?> Handle(TQuery query, CancellationToken cancellationToken)
    {
        //TODO: Log if not validator is set for query
        ValidationResult results = new();
        if (_validator != null)
        {
            results = await _validator.ValidateQuery(query);
        }

        if (results.IsValid)
        {
            return await _decoratee.Handle(query, cancellationToken);
        }

        throw new QueryValidationException(results);
    }
}