using CustomerApi.Dtos;

namespace CustomerApi.Services
{
    public interface ICustomerService
    {
        Task CreateCustomerAsync(CreateCustomerDto createCustomerDto, CancellationToken cancellationToken);
        Task DeleteCustomerAsync(int id, CancellationToken cancellationToken);
        Task<IEnumerable<GetCustomerDto>> GetAllCustomersAsync(CancellationToken cancellationToken);
        Task<GetCustomerDto?> GetCustomerByIdAsync(int id, CancellationToken cancellationToken);
        Task UpdateCustomerAsync(int id, UpdateCustomerDto updateCustomerDto, CancellationToken cancellationToken);
    }
}