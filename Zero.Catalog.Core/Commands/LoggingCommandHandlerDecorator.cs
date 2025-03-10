using Microsoft.Extensions.Logging;

namespace Zero.Catalog.Core.Commands;

public class LoggingCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand> 
    where TCommand : ICommand
{
    private readonly ILoggerFactory _loggerFactory;
    private readonly ICommandHandler<TCommand> _commandHandler;

    public LoggingCommandHandlerDecorator(ILoggerFactory loggerFactory, ICommandHandler<TCommand> commandHandler)
    {
        _loggerFactory = loggerFactory;
        _commandHandler = commandHandler;
    }

    public async Task Handle(TCommand command, CancellationToken cancellationToken)
    {
        var logger = _loggerFactory.CreateLogger(command.GetType());

        logger.LogInformation($"Starting to handle {command.GetType().Name}");

        try
        {
            await _commandHandler.Handle(command, cancellationToken);
        }
        catch (CommandValidationException exception)
        {
            logger.LogWarning(exception, $"Validation failed while handling {command.GetType().Name}");
            throw;
        }
        catch (Exception exception)
        {
            logger.LogError(exception, $"Error while handling {command.GetType().Name}");
            throw;
        }

        logger.LogInformation($"Finished handling {command.GetType().Name}");
    }
}