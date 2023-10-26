using Microsoft.EntityFrameworkCore;

namespace ExampleProject.Server.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Domain.Todo.Todo> Todos { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
