using ExampleProject.Shared.Todo;
using ExampleProject.Shared.Todo.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleProject.Shared.Common.Endpoints;

public interface ITodoApi
{
    [Get("/Todo")]
    Task<List<TodoDto>> GetTodos(CancellationToken cancellationToken);

    [Get("/Todo/{request.Id}")]
    Task<TodoDto> GetTodo(TodoQueries.GetTodo request, CancellationToken cancellationToken);

    [Post("/Todo")]
    Task<bool> CreateTodo(TodoCommands.CreateTodo request, CancellationToken cancellationToken);

    [Put("/Todo")]
    Task<bool> UpdateTodo(TodoCommands.UpdateTodo request, CancellationToken cancellationToken);

    [Delete("/Todo")]
    Task<bool> DeleteTodo(TodoCommands.DeleteTodo request, CancellationToken cancellationToken);
}
