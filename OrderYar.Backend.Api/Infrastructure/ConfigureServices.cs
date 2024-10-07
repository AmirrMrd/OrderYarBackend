using OrderYar.Backend.Api.Application;
using OrderYar.Backend.Api.Application.Common;
using OrderYar.Backend.Api.Application.Repositories;
using OrderYar.Backend.Api.Infrastructure.Data;
using OrderYar.Backend.Api.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace OrderYar.Backend.Api.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructuresService(this IServiceCollection services, AppSettings configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.ConnectionStrings.DefaultConnection));

        //if (configuration.UseInMemoryDatabase)
        //{
        //    services.AddDbContext<ApplicationDbContext>(options =>
        //        options.UseInMemoryDatabase("CleanArchitecture"));
        //}
        //else
        //{
            
        //}

        // register services
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ApplicationDbContextInitializer>();

        return services;
    }
}
