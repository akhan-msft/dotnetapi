using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<List<Customer>> GetAllCustomersAsync()
    {
        return await _customerRepository.GetAllAsync();
    }

    public async Task<Customer?> GetCustomerByIdAsync(int id)
    {
        return await _customerRepository.GetByIdAsync(id);
    }

    public async Task<Customer> CreateCustomerAsync(Customer customer)
    {
        await _customerRepository.AddAsync(customer);
        return customer;
    }

    public async Task<List<Customer?>> SearchCustomersByNameAsync(string name)
    {
        return await _customerRepository.SearchByNameAsync(name);
    }
}
