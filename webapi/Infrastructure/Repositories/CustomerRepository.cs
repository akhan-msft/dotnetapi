using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class CustomerRepository : ICustomerRepository
{
    private readonly AppDbContext _context;

    public CustomerRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Customer>> GetAllAsync()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task<Customer?> GetByIdAsync(int id)
    {
        return await _context.Customers.FindAsync(id);
    }

    public async Task AddAsync(Customer customer)
    {
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Customer>> SearchByNameAsync(string name)
    {
        return await _context.Customers
            .Where(c => EF.Functions.Like(c.CustomerName, $"%{name}%"))
            .ToListAsync();
    }
}