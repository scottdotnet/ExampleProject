using ExampleProject.Server.Application.Common.Interfaces;
using ExampleProject.Server.Domain.Todo;
using ExampleProject.Server.Infrastructure.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleProject.Server.Infrastructure.Persistance;

public sealed class ApplicationDbContext : DbContext, IApplicationDbContext
{
    private readonly IEnumerable<IInterceptor> _interceptors;

    public DbSet<Todo> Todos => Set<Todo>();

    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        IEnumerable<IInterceptor> interceptors)
        : base(options)
    {
        _interceptors = interceptors;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.AddInterceptors(_interceptors);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(InfrastructureAssembly.Assembly);
}
