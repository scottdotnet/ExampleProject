using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
