
using System.Reflection;
using linkshortner_mvc_net.Data;
using linkshortner_mvc_net.Entities;
using linkshortner_mvc_net.Middlewares;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

namespace linkshortner_mvc_net;

public static class ConfigureServices
{
    public static IServiceCollection AddWebUi(this IServiceCollection services)
    {
        services.AddControllersWithViews();
        services.AddHttpContextAccessor();
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme);
        services.AddSingleton<ExceptionHandlingMiddleware>();
        services.AddScoped<PasswordHasher<User>>();

        return services;
    }
}