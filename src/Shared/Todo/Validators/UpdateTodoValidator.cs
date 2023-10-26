using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
