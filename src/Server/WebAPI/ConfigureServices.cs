namespace ExampleProject.Server.WebAPI;

internal static class ConfigureServices
{
    public static void AddWebAPI(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }
}
