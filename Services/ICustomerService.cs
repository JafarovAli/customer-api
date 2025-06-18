using CustomerApi.Dtos;

namespace CustomerApi.Services
{
    public interface ICustomerService
    {
        Task CreateCustomerAsync(CreateCustomerDto createCustomerDto);
        Task DeleteCustomerAsync(int id);
        Task<IEnumerable<GetCustomerDto>> GetAllCustomersAsync();
        Task<GetCustomerDto?> GetCustomerByIdAsync(int id);
        Task UpdateCustomerAsync(int id, UpdateCustomerDto updateCustomerDto);
    }
}