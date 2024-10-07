using OrderYar.Backend.Api.Application.Common;
using Microsoft.OpenApi.Models;

namespace OrderYar.Backend.Api.Web.Extensions;

public static class SwaggerExtension
{
    private static readonly string[] Value = ["Bearer"];

    public static IServiceCollection AddSwaggerOpenAPI(this IServiceCollection services, AppSettings appSettings)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("OpenAPISpecification",
            new OpenApiInfo
            {
                Title = appSettings.ApplicationDetail.ApplicationName,
                Version = "v1",
                Description = appSettings.ApplicationDetail.Description,
                Contact = new OpenApiContact
                {
                    Email = "amirrmrd97@gmail.com",
                    Name = "Amir.Alimoradi",
                    Url = new Uri(appSettings.ApplicationDetail.ContactWebsite),
                },
                License = new OpenApiLicense()
                {
                    Name = "Free License",
                    Url = new Uri("https://github.com/AmirrMrd")
                }
            });

            var securityScheme = new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            };

            options.AddSecurityDefinition("Bearer", securityScheme);

            var securityRequirement = new OpenApiSecurityRequirement { { securityScheme, Value } };

            options.AddSecurityRequirement(securityRequirement);
        });
        return services;
    }
}
