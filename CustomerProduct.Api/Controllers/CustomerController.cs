using CustomerProduct.Application.Features.Customers;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace CustomerProduct.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public CustomerController(IMediator mediator) => Mediator = mediator;
        [HttpGet("all", Name = "customers")]
        public async Task<ActionResult<List<CustomerListVm>>> GetAsync()
        {
            var result = await Mediator.Send(new GetCustomerListQuery());
            return Ok(result);
        }
        public IMediator Mediator { get; }
    }
}
