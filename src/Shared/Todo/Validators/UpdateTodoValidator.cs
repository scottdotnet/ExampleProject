using FluentValidation;

namespace ExampleProject.Shared.Todo.Validators;

public sealed class UpdateTodoValidator : AbstractValidator<TodoCommands.UpdateTodo>
{
    public UpdateTodoValidator()
    {
        RuleFor(x => x.Todo)
            .NotEmpty();

        RuleFor(x => x.Todo.Id)
            .NotEmpty();

        RuleFor(x => x.Todo)
            .SetValidator(new TodoDtoValidator());
    }
}
