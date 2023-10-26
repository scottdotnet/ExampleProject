using FluentValidation;

namespace ExampleProject.Shared.Todo.Validators;

public sealed class CreateTodoValidator : AbstractValidator<TodoCommands.CreateTodo>
{
    public CreateTodoValidator()
    {
        RuleFor(x => x.Todo)
            .NotEmpty();

        RuleFor(x => x.Todo.Id)
            .Empty();

        RuleFor(x => x.Todo)
            .SetValidator(new TodoDtoValidator());
    }
}
