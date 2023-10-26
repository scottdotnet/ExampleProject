using ExampleProject.Server.Application.Common.Interfaces;
using ExampleProject.Shared.Todo;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleProject.Server.Application.Todo.Validators;

internal sealed class CreateTodoValidator : AbstractValidator<TodoCommands.CreateTodo>
{
    public CreateTodoValidator()
    {
        
    }
}
