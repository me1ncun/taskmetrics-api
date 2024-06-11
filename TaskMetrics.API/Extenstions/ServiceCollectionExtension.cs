﻿using Microsoft.EntityFrameworkCore;
using task_api.Domain;
using task_api.TaskMetrics.API.Services.User;
using task_api.TaskMetrics.Domain.Interfaces;
using task_api.TaskMetrics.Infrastructure;
using task_api.TaskMetrics.Infrastructure.Repositories;

namespace task_api.TaskMetrics.API.Extenstions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services
            .AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>))
            .AddScoped<IUserRepository, UserRepository>();
    }

    public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
    {
        return services
            .AddScoped<IUnitOfWork, UnitOfWork>();
    }

    public static IServiceCollection AddDatabase(this IServiceCollection services
        , IConfiguration configuration)
    {
        return services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("Database")));
    }

    public static IServiceCollection AddBusinessServices(this IServiceCollection services
    )
    {
        return services
            .AddScoped<UserService>();
    }
}