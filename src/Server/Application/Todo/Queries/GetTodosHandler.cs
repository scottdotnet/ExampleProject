using ExampleProject.Server.Application.Common.Interfaces;
using ExampleProject.Shared.Todo;
using ExampleProject.Shared.Todo.Models;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace ExampleProject.Server.Application.Todo.Queries;

internal sealed class GetTodosHandler : IRequestHandler<TodoQueries.GetTodos, List<TodoDto>>
{
    private readonly IApplicationDbContext _context;

    public GetTodosHandler(IApplicationDbContext context)
        => _context = context;

    public async ValueTask<List<TodoDto>> Handle(TodoQueries.GetTodos request, CancellationToken cancellationToken)
    {
        var todos = await _context.Todos.Select(x => new TodoDto
        {
            Id = x.Id,
            Title = x.Title,
            Description = x.Description,
            Completed = x.Completed
        }).ToListAsync();

        return todos;
    }
}
