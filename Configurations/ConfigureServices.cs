using CustomerApi.Repositories;
using CustomerApi.Services;
using CustomerApi.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace CustomerApi.Configurations;

public static class ConfigureServices
{
    public static void AddConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining<CreateCustomerDtoValidator>();
        services.AddValidatorsFromAssemblyContaining<UpdateCustomerDtoValidator>();

        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();

        services.AddAutoMapper(typeof(Program));
    }
}