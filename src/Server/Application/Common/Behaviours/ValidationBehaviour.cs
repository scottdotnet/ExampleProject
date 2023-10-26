using FluentValidation;
using Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationException = ExampleProject.Shared.Common.Exceptions.ValidationException;

namespace ExampleProject.Server.Application.Common.Behaviours;

internal sealed class ValidationBehaviour<TMessage, TResponse> : IPipelineBehavior<TMessage, TResponse>
    where TMessage : IMessage
{
    private readonly IEnumerable<IValidator<TMessage>> _validators;

    public ValidationBehaviour(IEnumerable<IValidator<TMessage>> validators)
    {
        _validators = validators;
    }

    public async ValueTask<TResponse> Handle(TMessage message, MessageHandlerDelegate<TMessage, TResponse> next, CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            foreach (var validator in _validators)
            {
                var result = await validator.ValidateAsync(message, cancellationToken);

                if (result.Errors.Count > 0)
                    throw new ValidationException(result.Errors);
            }
        }

        return await next(message, cancellationToken);
    }
}
