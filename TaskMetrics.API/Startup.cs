using Microsoft.OpenApi.Models;
using task_api.TaskMetrics.API.Extenstions;
using task_api.TaskMetrics.API.Handlers;

namespace task_api.TaskMetrics.API;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }
    
    public void ConfigureServices(IServiceCollection services)
    {
        // Application services
        services
            .AddDatabase(Configuration)
            .AddUnitOfWork()
            .AddRepositories()
            .AddBusinessServices()
            .AddApiAuthentication(Configuration)
            .AddPasswordHasher()
            .AddGlobalExceptionFilter()
            .AddJwtGenerating(Configuration);
        
        
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            /*app.ApplyMigrations();*/
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Task API V1");
                c.RoutePrefix = string.Empty;
            });
        }

        app.UseRouting();
        app.UseHttpsRedirection();

        app.UseAuthorization();
        app.UseAuthentication();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}