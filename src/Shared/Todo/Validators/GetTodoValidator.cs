using FluentValidation;

namespace ExampleProject.Shared.Todo.Validators;

public sealed class GetTodoValidator : AbstractValidator<TodoQueries.GetTodo>
{
    public GetTodoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .GreaterThan(0);
    }
}
