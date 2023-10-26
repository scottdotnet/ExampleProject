using ExampleProject.Shared.Common.Endpoints;
using ExampleProject.Shared.Todo;
using ExampleProject.Shared.Todo.Models;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace ExampleProject.Server.WebAPI.Controllers;

public sealed class TodoController : ApiControllerBase, ITodoApi
{
    [HttpPost]
    public async Task<bool> CreateTodo(TodoCommands.CreateTodo request, CancellationToken cancellationToken)
        => await Mediator.Send(request, cancellationToken);

    [HttpDelete]
    public async Task<bool> DeleteTodo(TodoCommands.DeleteTodo request, CancellationToken cancellationToken)
        => await Mediator.Send(request, cancellationToken);

    [HttpGet("{Id}")]
    public async Task<TodoDto> GetTodo([FromRoute] TodoQueries.GetTodo request, CancellationToken cancellationToken)
        => await Mediator.Send(request, cancellationToken);

    [HttpGet]
    public async Task<List<TodoDto>> GetTodos(CancellationToken cancellationToken)
        => await Mediator.Send(new TodoQueries.GetTodos(), cancellationToken);

    [HttpPut]
    public async Task<bool> UpdateTodo(TodoCommands.UpdateTodo request, CancellationToken cancellationToken)
        => await Mediator.Send(request, cancellationToken);
}
