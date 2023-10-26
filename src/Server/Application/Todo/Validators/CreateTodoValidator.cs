using ExampleProject.Shared.Todo;
using FluentValidation;

namespace ExampleProject.Server.Application.Todo.Validators;

internal sealed class CreateTodoValidator : AbstractValidator<TodoCommands.CreateTodo>
{
    public CreateTodoValidator()
    {

    }
}
