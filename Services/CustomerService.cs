using AutoMapper;
using CustomerApi.Dtos;
using CustomerApi.Entites;
using CustomerApi.Repositories;

namespace CustomerApi.Services;

public class CustomerService(ICustomerRepository customerRepository, IMapper mapper) : ICustomerService
{
    public async Task<IEnumerable<GetCustomerDto>> GetAllCustomersAsync()
    {
        var customers = await customerRepository.GetAllAsync();
        return mapper.Map<IEnumerable<GetCustomerDto>>(customers);
    }

    public async Task<GetCustomerDto?> GetCustomerByIdAsync(int id)
    {
        var customer = await customerRepository.GetByIdAsync(id);
        return customer == null ? null : mapper.Map<GetCustomerDto>(customer);
    }

    public async Task CreateCustomerAsync(CreateCustomerDto createCustomerDto)
    {
        var customer = mapper.Map<CustomerEntity>(createCustomerDto);
        await customerRepository.AddAsync(customer);
    }

    public async Task UpdateCustomerAsync(int id, UpdateCustomerDto dto)
    {
        var existing = await customerRepository.GetByIdAsync(id);
        if (existing == null)
            throw new KeyNotFoundException($"Customer with ID {id} not found.");

        if (!string.IsNullOrWhiteSpace(dto.FirstName))
            existing.FirstName = dto.FirstName;

        if (!string.IsNullOrWhiteSpace(dto.LastName))
            existing.LastName = dto.LastName;

        if (!string.IsNullOrWhiteSpace(dto.Email))
            existing.Email = dto.Email;

        await customerRepository.UpdateAsync(existing);
    }


    public async Task DeleteCustomerAsync(int id)
    {
        await customerRepository.DeleteAsync(id);
    }
}

