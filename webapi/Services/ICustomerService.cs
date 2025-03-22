public interface ICustomerService
{
    Task<List<Customer>> GetAllCustomersAsync();
    Task<Customer?> GetCustomerByIdAsync(int id); // Mark as nullable
    Task<Customer> CreateCustomerAsync(Customer customer);
    Task<List<Customer?>> SearchCustomersByNameAsync(string name);
}