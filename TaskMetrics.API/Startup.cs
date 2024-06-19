using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.OpenApi.Models;
using task_api.TaskMetrics.API.Extenstions;
using task_api.TaskMetrics.API.Handlers;
using task_api.TaskMetrics.API.Services;
using task_api.TaskMetrics.Infrastructure;

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
            .AddApiAuthentication(Configuration)
            .AddJwtGenerating(Configuration)
            .AddUnitOfWork()
            .AddPasswordHasher()
            .AddGlobalExceptionFilter()
            .AddContextAccessor()
            .AddServices()
            .AddAutoMapper()
            .AddCustomAuthorization();
        

        services.AddControllers();
  
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
            app.UseSwagger()
                .UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Task API V1");
                c.RoutePrefix = string.Empty;
            });
        }

        app.UseRouting();
        app.UseHttpsRedirection();

        app.UseCookiePolicy(new CookiePolicyOptions()
        {
            MinimumSameSitePolicy = SameSiteMode.Strict,
            Secure = CookieSecurePolicy.Always,
            HttpOnly = HttpOnlyPolicy.Always
        });
        
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}