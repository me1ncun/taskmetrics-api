using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using task_api.Domain;
using task_api.TaskMetrics.API.Handlers;
using task_api.TaskMetrics.API.Helpers;
using task_api.TaskMetrics.API.Helpers.Jwt;
using task_api.TaskMetrics.API.Services;
using task_api.TaskMetrics.API.Services.Interfaces;
using task_api.TaskMetrics.Domain.Interfaces;
using task_api.TaskMetrics.Infrastructure;
using task_api.TaskMetrics.Infrastructure.Repositories;

namespace task_api.TaskMetrics.API.Extenstions;

// service collection extension
public static class ServiceCollectionExtension
{
    public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
    {
        return services
            .AddScoped<IUnitOfWork, UnitOfWork>();
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services.AddScoped<IAuthService, AuthService>()
            .AddScoped<ITaskService, TaskService>()
            .AddScoped<ITaskRecordService, TaskRecordService>()
            .AddScoped<IAnalyticsService, AnalyticsService>();
    }

    public static IServiceCollection AddAutoMapper(this IServiceCollection services)
    {
        return services
            .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }

    public static IServiceCollection AddDatabase(this IServiceCollection services
        , IConfiguration configuration)
    {
        return services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("Database")));
    }


    public static IServiceCollection AddPasswordHasher(this IServiceCollection services)
    {
        return services
            .AddScoped<HashPasswordHelper>();
    }

    public static IServiceCollection AddGlobalExceptionFilter(this IServiceCollection services)
    {
        return services
            .AddScoped<GlobalExceptionFilter>();
    }

    public static IServiceCollection AddJwtGenerating(this IServiceCollection services,
        IConfiguration configuration)
    {
        return services
            .Configure<JwtOptions>(configuration.GetSection("JwtOptions"))
            .AddScoped<JwtProvider>();
    }

    public static IServiceCollection AddContextAccessor(this IServiceCollection services)
    {
        return services.AddSingleton<IHttpContextAccessor,
            HttpContextAccessor>();
    }
}