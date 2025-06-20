using CustomerApi.Entites;

namespace CustomerApi.Repositories;

public interface ICustomerRepository
{
    Task<IEnumerable<Customer>> GetAllAsync(CancellationToken cancellationToken);
    Task<Customer?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task AddAsync(Customer customer, CancellationToken cancellationToken);
    Task UpdateAsync(Customer customer, CancellationToken cancellationToken);
    Task DeleteAsync(int id, CancellationToken cancellationToken);
}