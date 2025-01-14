using Microsoft.EntityFrameworkCore;
using UserApi.Infrastructure.DbContexts;

namespace UserApi.Infrastructure.Configurations
{
    public static class DbConfiguration
    {
        public static void AddDbConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            try
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

                Console.WriteLine("Database connection successful.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Database connection failed: {ex.Message}");
            }
        }
    }
}
