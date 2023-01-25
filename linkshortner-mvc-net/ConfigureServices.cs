
namespace linkshortner_mvc_net;

public static class ConfigureServices
{
    public static IServiceCollection AddWebUI(this IServiceCollection services)
    {
        services.AddControllersWithViews();
        return services;
    }
}