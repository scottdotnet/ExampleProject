using ExampleProject.Shared.Todo.Models;
using FluentValidation;

namespace ExampleProject.Shared.Todo.Validators;

public sealed class TodoDtoValidator : AbstractValidator<TodoDto>
{
    public TodoDtoValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(20);

        RuleFor(x => x.Description)
            .MaximumLength(100);

        RuleFor(x => x.Completed);
    }
}