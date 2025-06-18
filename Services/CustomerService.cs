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
        var customer = mapper.Map<Customer>(createCustomerDto);
        await customerRepository.AddAsync(customer);
    }

    public async Task UpdateCustomerAsync(int id, UpdateCustomerDto updateCustomerDto)
    {
        var customer = mapper.Map<Customer>(updateCustomerDto);
        customer.Id = id;
        await customerRepository.UpdateAsync(customer);
    }

    public async Task DeleteCustomerAsync(int id)
    {
        await customerRepository.DeleteAsync(id);
    }
}

