using CustomerApi.Entites;

namespace CustomerApi.Repositories;

public interface ICustomerRepository
{
    Task<IEnumerable<CustomerEntity>> GetAllAsync();
    Task<CustomerEntity?> GetByIdAsync(int id);
    Task AddAsync(CustomerEntity customer);
    Task UpdateAsync(CustomerEntity customer);
    Task DeleteAsync(int id);
}