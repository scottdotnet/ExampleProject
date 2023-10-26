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
        var todo = await _context.Todos.Select(x => new TodoDto
        {
            Id = x.Id,
            Title = x.Title,
            Description = x.Description,
            Completed = x.Completed
        }).SingleAsync(x => x.Id == request.Id);

        return todo;
    }
}
