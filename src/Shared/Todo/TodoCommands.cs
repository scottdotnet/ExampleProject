using ExampleProject.Shared.Todo.Models;
using Mediator;

namespace ExampleProject.Shared.Todo;

public static class TodoCommands
{
    public record CreateTodo(TodoDto Todo) : IRequest<bool>;
    public record UpdateTodo(TodoDto Todo) : IRequest<bool>;
    public record DeleteTodo(int Id) : IRequest<bool>;
}
