﻿using ExampleProject.Server.Application.Common.Interfaces;
using ExampleProject.Shared.Todo;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleProject.Server.Application.Todo.Validators;

internal sealed class DeleteTodoValidator : AbstractValidator<TodoCommands.DeleteTodo>
{
    public DeleteTodoValidator(IApplicationDbContext context)
    {
        RuleFor(x => x)
            .MustAsync(async (request, cancellationToken)
                => await context.Todos.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken) is not null)
            .WithMessage("Todo with Id does not exist.");
    }
}
