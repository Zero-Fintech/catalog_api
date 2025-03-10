using FluentValidation.Results;

namespace Zero.Catalog.Core.Commands;

public class ValidationCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
{
    private readonly ICommandValidator<TCommand>? _validator;
    private readonly ICommandHandler<TCommand> _decoratee;

    public ValidationCommandHandlerDecorator(ICommandHandler<TCommand> decoratee, ICommandValidator<TCommand>? validator = null)
    {
        _validator = validator;
        _decoratee = decoratee;
    }

    public async Task Handle(TCommand command, CancellationToken cancellationToken)
    {
        //TODO: Log if not validator is set for command
        ValidationResult results = new ();
        if (_validator != null)
        {
            results = await _validator.ValidateCommand(command);
        }
        
        if(results.IsValid)
        {
            await _decoratee.Handle(command, cancellationToken);
        }
        else
        {
            throw new CommandValidationException(results);
        }              
    }
}