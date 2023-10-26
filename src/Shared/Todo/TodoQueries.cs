using ExampleProject.Shared.Todo.Models;
using Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleProject.Shared.Todo;

public static class TodoQueries
{
    public record GetTodos() : IRequest<List<TodoDto>>;
    public record GetTodo(int Id) : IRequest<TodoDto>;
}
