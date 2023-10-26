using ExampleProject.Shared.Todo.Models;
using Mediator;

namespace ExampleProject.Shared.Todo;

public static class TodoQueries
{
    public record GetTodos() : IRequest<List<TodoDto>>;
    public record GetTodo(int Id) : IRequest<TodoDto>;
}
