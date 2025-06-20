using AutoMapper;
using CustomerApi.Dtos;
using CustomerApi.Entites;
using CustomerApi.Repositories;

namespace CustomerApi.Services;

public class CustomerService(ICustomerRepository customerRepository, IMapper mapper) : ICustomerService
{
    public async Task<IEnumerable<GetCustomerDto>> GetAllCustomersAsync(CancellationToken cancellationToken)
    {
        var customers = await customerRepository.GetAllAsync(cancellationToken);
        return mapper.Map<IEnumerable<GetCustomerDto>>(customers);
    }

    public async Task<GetCustomerDto?> GetCustomerByIdAsync(int id, CancellationToken cancellationToken)
    {
        var customer = await customerRepository.GetByIdAsync(id, cancellationToken);
        return customer == null ? null : mapper.Map<GetCustomerDto>(customer);
    }

    public async Task CreateCustomerAsync(CreateCustomerDto createCustomerDto, CancellationToken cancellationToken)
    {
        var customer = mapper.Map<Customer>(createCustomerDto);
        await customerRepository.AddAsync(customer, cancellationToken);
    }

    public async Task UpdateCustomerAsync(int id, UpdateCustomerDto dto, CancellationToken cancellationToken)
    {
        var existing = await customerRepository.GetByIdAsync(id, cancellationToken);
        if (existing == null)
            throw new KeyNotFoundException($"Customer with ID {id} not found.");

        if (!string.IsNullOrWhiteSpace(dto.FirstName))
            existing.FirstName = dto.FirstName;

        if (!string.IsNullOrWhiteSpace(dto.LastName))
            existing.LastName = dto.LastName;

        if (!string.IsNullOrWhiteSpace(dto.Email))
            existing.Email = dto.Email;

        await customerRepository.UpdateAsync(existing, cancellationToken);
    }


    public async Task DeleteCustomerAsync(int id, CancellationToken cancellationToken)
    {
        await customerRepository.DeleteAsync(id, cancellationToken);
    }
}

