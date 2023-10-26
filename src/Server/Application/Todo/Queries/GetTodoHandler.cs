using ExampleProject.Server.Application.Common.Interfaces;
using ExampleProject.Shared.Todo;
using ExampleProject.Shared.Todo.Models;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace ExampleProject.Server.Application.Todo.Queries;

internal sealed class GetTodoHandler : IRequestHandler<TodoQueries.GetTodo, TodoDto>
{
    private readonly IApplicationDbContext _context;

    public GetTodoHandler(IApplicationDbContext context)
        => _context = context;

    public async ValueTask<TodoDto> Handle(TodoQueries.GetTodo request, CancellationToken cancellationToken)
    {
        var todo = await _context.Todos.SingleAsync(x => x.Id == request.Id);

        return new()
        {
            Id = todo.Id,
            Title = todo.Title,
            Description = todo.Description,
            Completed = todo.Completed
        };
    }
}
