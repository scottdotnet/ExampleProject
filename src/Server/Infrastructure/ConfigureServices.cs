using ExampleProject.Server.Application.Common.Interfaces;
using ExampleProject.Server.Infrastructure.Common;
using ExampleProject.Server.Infrastructure.Persistance;
using ExampleProject.Server.Infrastructure.Persistance.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExampleProject.Server.Infrastructure;

public static class ConfigureServices
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IInterceptor, CacheDataInterceptor>();

        services.AddDbContext<ApplicationDbContext>(x
            => x.UseSqlServer(
                configuration.GetConnectionString("Default"),
                x => x.MigrationsAssembly(InfrastructureAssembly.Assembly.FullName)));
        services.AddScoped<IApplicationDbContext>(x => x.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<IMemoryCache, MemoryCache>();
    }
}
