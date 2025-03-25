using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCustomers()
    {
        var customers = await _customerService.GetAllCustomersAsync();
        return Ok(customers);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomer(int id)
    {
        var customer = await _customerService.GetCustomerByIdAsync(id);
        if (customer == null)
            return NotFound();

        return Ok(customer);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
    {
        var createdCustomer = await _customerService.CreateCustomerAsync(customer);
        return CreatedAtAction(nameof(GetCustomers), new { id = createdCustomer.CustomerId }, createdCustomer);
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchCustomersByName([FromQuery] string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return BadRequest("Name parameter is required.");

        var customers = await _customerService.SearchCustomersByNameAsync(name);

        if (customers == null || customers.Count == 0)
            return NotFound("No customers found matching the given name pattern.");

        return Ok(customers);
    }
}
