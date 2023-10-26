using ExampleProject.Server.Application.Common;
using ExampleProject.Server.Application.Common.Behaviours;
using ExampleProject.Shared.Common;
using FluentValidation;
using Mediator;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleProject.Server.Application;

public static class ConfigureServices
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblies(new[] { SharedAssembly.Assembly, ApplicationAssembly.Assembly }, includeInternalTypes: true);
        services.AddMediator(x => x.ServiceLifetime = ServiceLifetime.Scoped);

        ValidatorOptions.Global.DefaultClassLevelCascadeMode = CascadeMode.Stop;

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
    }
}
