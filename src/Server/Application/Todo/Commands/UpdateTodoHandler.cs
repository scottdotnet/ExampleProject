using ExampleProject.Server.Application.Common.Interfaces;
using ExampleProject.Shared.Todo;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace ExampleProject.Server.Application.Todo.Commands;

internal sealed class UpdateTodoHandler : IRequestHandler<TodoCommands.UpdateTodo, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateTodoHandler(IApplicationDbContext context)
        => _context = context;

    public async ValueTask<bool> Handle(TodoCommands.UpdateTodo request, CancellationToken cancellationToken)
    {
        var todo = await _context.Todos.SingleAsync(x => x.Id == request.Todo.Id, cancellationToken);

        todo.Title = request.Todo.Title;
        todo.Description = request.Todo.Description;
        todo.Completed = request.Todo.Completed;

        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }
}
