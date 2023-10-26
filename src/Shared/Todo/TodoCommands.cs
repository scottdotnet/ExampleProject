using ExampleProject.Shared.Todo.Models;
using Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleProject.Shared.Todo;

public static class TodoCommands
{
    public record CreateTodo(TodoDto Todo) : IRequest<bool>;
    public record UpdateTodo(TodoDto Todo) : IRequest<bool>;
    public record DeleteTodo(int Id) : IRequest<bool>;
}
