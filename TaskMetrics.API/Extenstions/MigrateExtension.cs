using Microsoft.EntityFrameworkCore;
using task_api.TaskMetrics.Infrastructure;

namespace task_api.TaskMetrics.API.Extenstions;

public static class MigrateExtension
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();
        {
            using ApplicationDbContext context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            {
                context.Database.Migrate();
            }
        }
    }
}