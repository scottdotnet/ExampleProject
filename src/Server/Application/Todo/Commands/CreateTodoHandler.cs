using ExampleProject.Server.Application.Common.Interfaces;
using ExampleProject.Shared.Todo;
using Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleProject.Server.Application.Todo.Commands;

internal sealed class CreateTodoHandler : IRequestHandler<TodoCommands.CreateTodo, bool>
{
    private readonly IApplicationDbContext _context;

    public CreateTodoHandler(IApplicationDbContext context)
        => _context = context;

    public async ValueTask<bool> Handle(TodoCommands.CreateTodo request, CancellationToken cancellationToken)
    {
        await _context.Todos.AddAsync(new()
        {
            Title = request.Todo.Title,
            Description = request.Todo.Description,
            Completed = request.Todo.Completed,
        }, cancellationToken);

        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }
}