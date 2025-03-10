namespace Zero.Catalog.Core.Commands;

public interface ICommandDispatcher
{
    Task Dispatch(ICommand command, CancellationToken cancellationToken = default);
}