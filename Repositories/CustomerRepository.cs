using CustomerApi.Entites;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace CustomerApi.Repositories;

public class CustomerRepository(OracleConnection connection) : ICustomerRepository
{
    public async Task<IEnumerable<Customer>> GetAllAsync(CancellationToken cancellationToken)
    {
        var customers = new List<Customer>();

        using var cmd = new OracleCommand("GetAllCustomers", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor, ParameterDirection.Output);

        await connection.OpenAsync();
        using var reader = await cmd.ExecuteReaderAsync(cancellationToken);

        while (await reader.ReadAsync())
        {
            customers.Add(new Customer
            {
                Id = Convert.ToInt32(reader["Id"]),
                FirstName = reader["FirstName"].ToString(),
                LastName = reader["LastName"].ToString(),
                Email = reader["Email"].ToString()
            });
        }

        await connection.CloseAsync();
        return customers;
    }

    public async Task<Customer?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        Customer? customer = null;

        using var cmd = new OracleCommand("GetCustomerById", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        cmd.Parameters.Add("p_Id", id);
        cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor, ParameterDirection.Output);

        await connection.OpenAsync();
        using var reader = await cmd.ExecuteReaderAsync(cancellationToken);

        if (await reader.ReadAsync())
        {
            customer = new Customer
            {
                Id = Convert.ToInt32(reader["Id"]),
                FirstName = reader["FirstName"].ToString(),
                LastName = reader["LastName"].ToString(),
                Email = reader["Email"].ToString()
            };
        }

        await connection.CloseAsync();
        return customer;
    }


    public async Task AddAsync(Customer customer, CancellationToken cancellationToken)
    {
        using var cmd = new OracleCommand("InsertCustomer", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        cmd.Parameters.Add("p_FirstName", customer.FirstName);
        cmd.Parameters.Add("p_LastName", customer.LastName);
        cmd.Parameters.Add("p_Email", customer.Email);

        await connection.OpenAsync();
        await cmd.ExecuteNonQueryAsync(cancellationToken);
        await connection.CloseAsync();
    }

    public async Task UpdateAsync(Customer customer, CancellationToken cancellationToken)
    {
        using var cmd = new OracleCommand("UpdateCustomer", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        cmd.Parameters.Add("p_Id", customer.Id);
        cmd.Parameters.Add("p_FirstName", customer.FirstName);
        cmd.Parameters.Add("p_LastName", customer.LastName);
        cmd.Parameters.Add("p_Email", customer.Email);

        await connection.OpenAsync();
        await cmd.ExecuteNonQueryAsync(cancellationToken);
        await connection.CloseAsync();
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        using var cmd = new OracleCommand("DeleteCustomer", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        cmd.Parameters.Add("p_Id", id);

        await connection.OpenAsync();
        await cmd.ExecuteNonQueryAsync(cancellationToken);
        await connection.CloseAsync();
    }
}

