using ExampleProject.Server.Application.Common.Interfaces;
using ExampleProject.Shared.Todo;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace ExampleProject.Server.Application.Todo.Commands;

internal sealed class DeleteTodoHandler : IRequestHandler<TodoCommands.DeleteTodo, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteTodoHandler(IApplicationDbContext context)
        => _context = context;

    public async ValueTask<bool> Handle(TodoCommands.DeleteTodo request, CancellationToken cancellationToken)
    {
        var todo = await _context.Todos.SingleAsync(x => x.Id == request.Id);

        _context.Todos.Remove(todo);

        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }
}
