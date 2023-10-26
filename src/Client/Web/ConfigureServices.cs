using ExampleProject.Shared.Common.Endpoints;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Refit;

namespace ExampleProject.Client.Web;

public static class ConfigureServices
{
    public static void AddWeb(this IServiceCollection services, IConfiguration configuration, IWebAssemblyHostEnvironment web)
    {
        services.AddRefitClient<ITodoApi>()
            .ConfigureHttpClient(x => x.BaseAddress = new Uri($"{configuration["API"]}api"));
    }
}
