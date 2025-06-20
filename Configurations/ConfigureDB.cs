using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace CustomerApi.Configurations;

public static class ConfigureDb
{
    public static void AddConfigureDbServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<OracleConnection>(_ =>
        new OracleConnection(configuration.GetConnectionString("OracleConnection")));
    }
}
