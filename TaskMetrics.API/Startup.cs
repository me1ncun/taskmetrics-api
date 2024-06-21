using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Identity;
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
    
    // add services to the container
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
            .AddAutoMapper();
        

        services.AddControllers();
  
        // add swagger documentation
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "ToDo API",
                Description = "An ASP.NET Core Web API for managing ToDo items",
                Contact = new OpenApiContact
                {
                    Name = "Shapovalov Denis",
                    Url = new Uri("https://t.me/den1sshap")
                },
                License = new OpenApiLicense
                {
                    Name = "The MIT License",
                    Url = new Uri("https://www.mit.edu/~amini/LICENSE.md")
                }
            });
            
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
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

        // add cookie policy
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