using Mediator;
using Microsoft.Extensions.Logging;

namespace ExampleProject.Server.Application.Common.Behaviours;

internal sealed class UnhandledExceptionBehaviour<TMessage, TResponse> : IPipelineBehavior<TMessage, TResponse>
    where TMessage : IMessage
{
    private readonly ILogger<TMessage> _logger;

    public UnhandledExceptionBehaviour(ILogger<TMessage> logger)
        => _logger = logger;

    public async ValueTask<TResponse> Handle(TMessage message, MessageHandlerDelegate<TMessage, TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next(message, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception for request {Name} {@Reques}", typeof(TMessage).Name, message);

            throw;
        }
    }
}
