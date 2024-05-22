using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Npgsql;
using TodoListBULKED.App.Abstractions;
using TodoListBULKED.App.Handlers.Auth;
using TodoListBULKED.App.Handlers.Ticket;
using TodoListBULKED.App.Handlers.User;
using TodoListBULKED.App.Handlers.User.Validators;
using TodoListBULKED.App.Utilities;
using TodoListBULKED.Data.Configuration;
using TodoListBULKED.Data.Context;
using TodoListBULKED.Data.Repositories;
using TodoLIstBULKED.Infrastructure.Cookie;
using TodoLIstBULKED.Infrastructure.Hashers;
using TodoLIstBULKED.Infrastructure.Providers;

namespace TodoListBULKED.API.Dependencies;

/// <summary>
/// Регистрация зависимостей
/// </summary>
public static class DependenciesExtension
{
    public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddBaseDependencies(configuration)
            .AddDatabaseDependencies()
            .AddAuthDependencies()
            .AddUserDependencies()
            .AddTicketDependencies();
    }

    private static IServiceCollection AddAuthDependencies(this IServiceCollection services)
    {
        services
            .AddHttpContextAccessor()
            .AddAuthorization()
            .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/login";
            });
        
        return services
            .AddScoped<IAuthRepository, AuthRepository>()
            .AddScoped<LoginHandler>()
            .AddScoped<LogoutHandler>();
    }

    private static IServiceCollection AddUserDependencies(this IServiceCollection services)
    {
        return services
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<CreateUserHandler>()
            .AddScoped<CreateUserValidator>()
            .AddScoped<EditUserHandler>();
    }

    private static IServiceCollection AddTicketDependencies(this IServiceCollection services)
    {
        return services
            .AddScoped<ITicketRepository, TicketRepository>()
            .AddScoped<CreateTicketHandler>()
            .AddScoped<TicketNumberUtility>()
            .AddScoped<GetTicketsHandler>()
            .AddScoped<GetPerformerTicketsHandler>()
            .AddScoped<GetCreatorTicketsHandler>()
            .AddScoped<EditTicketHandler>();
    }

    private static IServiceCollection AddBaseDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();

        return services
            .AddMemoryCache()
            .AddSingleton<TimeProvider, MainTimeProvider>()
            .AddSingleton<EnumDescriptionProvider>()
            .AddScoped<IHasher, Hasher>()
            .AddScoped<ICookieGetter, CookieGetter>()
            .Configure<AppConfig>(configuration)
            .AddSwaggerGen();
    }

    private static IServiceCollection AddDatabaseDependencies(this IServiceCollection services)
    {
        return services.AddDbContext<AppDbContext>((provider, options) =>
        {
            var databaseConfig = provider.GetRequiredService<IOptions<AppConfig>>().Value.DatabaseConfig;
            var connectionStringBuilder = new NpgsqlConnectionStringBuilder
            {
                Host = databaseConfig.Host,
                Port = databaseConfig.Port,
                Database = databaseConfig.Database,
                Username = databaseConfig.Username,
                Password = databaseConfig.Password
            };
            
            options.UseNpgsql(connectionStringBuilder.ConnectionString);
        });
    }
}