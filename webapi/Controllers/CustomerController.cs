using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        if (id <= 0)
            return BadRequest("Customer ID must be a positive integer.");

        var customer = await _customerService.GetCustomerByIdAsync(id);
        if (customer == null)
            return NotFound();

        return Ok(customer);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
    {
        if (customer == null)
            return BadRequest("Customer data is required.");

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdCustomer = await _customerService.CreateCustomerAsync(customer);
        return CreatedAtAction(nameof(GetCustomers), new { id = createdCustomer.CustomerId }, createdCustomer);
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchCustomersByName([FromQuery] string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return BadRequest("Name parameter is required.");

        if (name.Length > 100)
            return BadRequest("Name parameter cannot exceed 100 characters.");

        // Basic XSS protection by removing potentially malicious characters
        var sanitizedName = System.Text.RegularExpressions.Regex.Replace(name, @"[<>""'&]", "");
        if (sanitizedName != name)
            return BadRequest("Name parameter contains invalid characters.");

        var customers = await _customerService.SearchCustomersByNameAsync(sanitizedName);

        if (customers == null || customers.Count == 0)
            return NotFound("No customers found matching the given name pattern.");

        return Ok(customers);
    }
}
