
using System.Reflection;
using MediatR;

namespace linkshortner_mvc_net;

public static class ConfigureServices
{
    public static IServiceCollection AddWebUi(this IServiceCollection services)
    {
        services.AddControllersWithViews();
        services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }
}