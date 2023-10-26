using FluentValidation;

namespace ExampleProject.Shared.Todo.Validators;

public sealed class DeleteTodoValidator : AbstractValidator<TodoCommands.DeleteTodo>
{
    public DeleteTodoValidator()
    {
        RuleFor(X => X.Id)
            .NotEmpty()
            .GreaterThan(0);
    }
}
