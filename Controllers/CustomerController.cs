using CustomerApi.Dtos;
using CustomerApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController(ICustomerService customerService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var customers = await customerService.GetAllCustomersAsync();
        return Ok(customers);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var customer = await customerService.GetCustomerByIdAsync(id);
        if (customer == null)
            return NotFound();

        return Ok(customer);
    }


    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateCustomerDto createCustomerDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await customerService.CreateCustomerAsync(createCustomerDto);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateCustomerDto updateCustomerDto)
    {
        await customerService.UpdateCustomerAsync(id, updateCustomerDto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await customerService.DeleteCustomerAsync(id);
        return Ok();
    }
}

