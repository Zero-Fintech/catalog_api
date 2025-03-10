using Microsoft.Extensions.Logging;

namespace Zero.Catalog.Core.Queries;

public class LoggingQueryHandlerDecorator<TQuery, TResult> : IQueryHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
{
    private readonly ILoggerFactory _loggerFactory;
    private readonly IQueryHandler<TQuery, TResult> _queryHandler;

    public LoggingQueryHandlerDecorator(ILoggerFactory loggerFactory, IQueryHandler<TQuery, TResult> queryHandler)
    {
        _loggerFactory = loggerFactory;
        _queryHandler = queryHandler;
    }

    public async Task<TResult?> Handle(TQuery query, CancellationToken cancellationToken)
    {
        var logger = _loggerFactory.CreateLogger(query.GetType());
        logger.LogInformation($"Starting to handle {query.GetType().Name}");

        try
        {
            var result = await _queryHandler.Handle(query, cancellationToken);
            logger.LogInformation($"Finished handling {query.GetType().Name}");
            return result;
        }
        catch (Exception exception)
        {
            logger.LogError(exception, $"Error while handling {query.GetType().Name}");
            throw;
        }
    }
}