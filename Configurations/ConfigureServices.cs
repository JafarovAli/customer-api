using CustomerApi.Repositories;
using CustomerApi.Services;
using Oracle.ManagedDataAccess.Client;

namespace CustomerApi.Configurations;

public static class ConfigureServices
{
    public static void AddConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<OracleConnection>(_ =>
        new OracleConnection(configuration.GetConnectionString("OracleConnection")));

        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();

        services.AddAutoMapper(typeof(Program));
    }
}
