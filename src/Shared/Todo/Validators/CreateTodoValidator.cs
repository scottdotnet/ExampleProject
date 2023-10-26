using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
