using CustomerApi.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CustomerApi.Configurations;

public static class ConfigureDb
{
    public static void AddConfigureDbServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        options.UseOracle(configuration.GetConnectionString("OracleConnection")));
    }
}
