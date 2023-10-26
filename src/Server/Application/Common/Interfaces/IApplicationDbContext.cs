using ExampleProject.Server.Domain.Todo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleProject.Server.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Domain.Todo.Todo> Todos { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
