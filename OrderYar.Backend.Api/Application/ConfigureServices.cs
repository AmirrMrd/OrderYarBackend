using OrderYar.Backend.Api.Application.Common.Interfaces;
using OrderYar.Backend.Api.Application.Common.Utilities;
using OrderYar.Backend.Api.Application.Services;
using Web.Services;

namespace OrderYar.Backend.Api.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IMailService, MailService>();
        services.AddScoped<IItemService, ItemService>();
        services.AddScoped<ICategoryItemService, CategoryItemService>();


        services.AddSingleton<ICurrentTime, CurrentTime>();
        services.AddSingleton<ICurrentUser, CurrentUser>();
        services.AddSingleton<ITokenService, TokenService>();
        services.AddSingleton<ICookieService, CookieService>();

        return services;
    }
}
