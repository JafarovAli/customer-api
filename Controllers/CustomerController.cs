using CustomerApi.Dtos;
using CustomerApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController(ICustomerService customerService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        var customers = await customerService.GetAllCustomersAsync(cancellationToken);
        return Ok(customers);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var customer = await customerService.GetCustomerByIdAsync(id, cancellationToken);
        if (customer == null)
            return NotFound();

        return Ok(customer);
    }


    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateCustomerDto createCustomerDto, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await customerService.CreateCustomerAsync(createCustomerDto, cancellationToken);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateCustomerDto updateCustomerDto, CancellationToken cancellationToken)
    {
        await customerService.UpdateCustomerAsync(id, updateCustomerDto,cancellationToken);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        await customerService.DeleteCustomerAsync(id, cancellationToken);
        return Ok();
    }
}

