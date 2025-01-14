using Microsoft.OpenApi.Models;
using UserApi.Infrastructure.Configurations;
using UserApi.Application.Interfaces;
using UserApi.Application.Services;
using UserApi.Infrastructure.Repositories;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Configure database connection
            services.AddDbConfiguration(configuration);

            // Add controllers
            services.AddControllers();

            // Add application-specific services
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            // Add HttpClient for external API calls
            services.AddHttpClient();

            // Add Swagger for API documentation
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "User API",
                    Version = "v1",
                    Description = "API to manage users and fetch data from the Random User Generator API."
                });
            });

            // Add CORS policy to allow requests from frontend
            services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend", policy =>
                {
                    policy.WithOrigins("http://localhost:3000") // Replace with your frontend URL
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });
        }
    }
}
