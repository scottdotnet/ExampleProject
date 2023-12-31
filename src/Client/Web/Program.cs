using ExampleProject.Client.Web;
using ExampleProject.Client.Web.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

ConfigureServices(builder.Services, builder.Configuration, builder.HostEnvironment);

await builder.Build().RunAsync();

static void ConfigureServices(IServiceCollection services, IConfiguration configuration, IWebAssemblyHostEnvironment web)
    => services.AddWeb(configuration, web);