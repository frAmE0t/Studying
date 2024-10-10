using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc; // [Route], [ApiController], ControllerBase and so on.
using Northwind.EntityModels; // To use Customer.
using Northwind.WebApi.Repositories; // ICustomerRepository.


namespace Northwind.WebApi.Repositories
{
    //Base address: api/customers
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _repo;

        //Constructor injects repository registered in Program.cs.
        public CustomersController(ICustomerRepository repo)
        {
            _repo = repo;
        }

        //GET: api/customers
        //GET: api/customer/?country=[country]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Customer>))]
        public async Task<IEnumerable<Customer>> GetCustomers(string? country)
        {
            if (string.IsNullOrWhiteSpace(country))
                return await _repo.RetriveAllAsync();
            else
                return (await _repo.RetriveAllAsync())
                    .Where(customer => customer.Country == country);
        }

        //GET: api/customers/[id]
        [HttpGet("{id}", Name = nameof(GetCustomer))]
        [ProducesResponseType(200, Type = typeof(Customer))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCustomer(string id)
        {
            Customer? c = await _repo.RetrieveAsync(id);

            if (c is null)
                return NotFound();
            return Ok(c);
        }

        //POST: api/customers
        //BODY: Customer (JSON, XML)
        [HttpPost]
        [ProducesResponseType(202, Type = typeof(Customer))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] Customer c)
        {
            if (c is null)
                return BadRequest();

            Customer? addedCustomer = await _repo.CreateAsync(c);

            if (addedCustomer is null)
                return BadRequest("Repository failed to create customer.");
            else
                return CreatedAtRoute(
                    routeName: nameof(GetCustomer),
                    routeValues: new { id = addedCustomer.CustomerId.ToLower()},
                    value: addedCustomer);
        }

        //PUT: api/customers/[id]
        //BODY: Customer (JSON, XML)
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(string id, [FromBody] Customer c)
        {
            id = id.ToUpper();
            c.CustomerId = c.CustomerId.ToUpper();

            if (c is null || c.CustomerId != id)
                return BadRequest(); // 400 Bad request.

            Customer? existing = await _repo.RetrieveAsync(id);

            if (existing is null)
                return NotFound(); //404 Resource not found.
            
            await _repo.UpdateAsync(c);

            return new NoContentResult(); // 204 No content.
        }

        //DELETE: api/customers/[id]
        [HttpDelete]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(string id)
        {
            Customer? existing = await _repo.RetrieveAsync(id);

            if ( existing is null)
                return NotFound(); // 404 Resource not found.

            bool? deleted = await _repo.DeleteAsync(id);

            if (deleted.HasValue && deleted.Value) // Short curcuit AND.
                return new NoContentResult(); //204 No content.
            else
                return BadRequest($"Customer {id} was founded but failed to delete."); // 400 Bad request.
        }
    }
}
