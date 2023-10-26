using ExampleProject.Server.Application.Common.Interfaces;
using ExampleProject.Shared.Todo;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ExampleProject.Server.Application.Todo.Validators;

internal sealed class GetTodoHandler : AbstractValidator<TodoQueries.GetTodo>
{
    public GetTodoHandler(IApplicationDbContext context)
    {
        RuleFor(x => x)
            .MustAsync(async (request, cancellationToken)
                => await context.Todos.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken) is not null)
            .WithMessage("Todo with Id does not exist.");
    }
}
