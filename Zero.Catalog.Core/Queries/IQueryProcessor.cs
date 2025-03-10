namespace Zero.Catalog.Core.Queries;

public interface IQueryProcessor
{
    Task<TResult?> Process<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default);
}