using System.Collections.Generic;
using System.Threading.Tasks;

public interface ICustomerRepository
{
    Task<List<Customer>> GetAllAsync();
    Task<Customer?> GetByIdAsync(int id);
    Task AddAsync(Customer customer);
    Task<List<Customer>> SearchByNameAsync(string name);
}