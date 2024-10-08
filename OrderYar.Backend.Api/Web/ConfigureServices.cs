using System.Diagnostics;
using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using OrderYar.Backend.Api.Web.Extensions;
using OrderYar.Backend.Api.Application.Common;
using OrderYar.Backend.Api.Web.Middlewares;

namespace Web;

public static class ConfigureServices
{
    public static IServiceCollection AddWebAPIService(this IServiceCollection services, AppSettings appSettings)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();
        services.AddAuthentication();
        services.AddAuthorization();

        // Middleware
        services.AddSingleton<GlobalExceptionMiddleware>();
        services.AddSingleton<PerformanceMiddleware>();
        services.AddSingleton<Stopwatch>();

        // Extension classes
        services.AddHealthChecks();
        services.AddCompressionCustom();
        services.AddCorsCustom(appSettings);
        services.AddHttpClient();
        services.AddSwaggerOpenAPI(appSettings);
        services.AddJWTCustom(appSettings);
        //services.SetupHealthCheck(appSettings);

        return services;
    }
}
