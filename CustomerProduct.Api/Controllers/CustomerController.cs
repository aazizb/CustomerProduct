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
        [HttpGet("all", Name = "Customers")]
        public async Task<ActionResult<List<CustomerListVm>>> GetAsync()
        {
            var result = await Mediator.Send(new GetCustomerListQuery());
            return Ok(result);
        }
        [HttpPost(Name = "CreateCustomer")]
        public async Task<ActionResult<CreateCustomerCommandResponse>> Create([FromBody] CreateCustomerCommand createCategoryCommand)
        {
            var response = await Mediator.Send(createCategoryCommand);
            return Ok(response);
        }
        [HttpPut(Name = "UpdateCustomer")]
        public async Task<ActionResult> Update([FromBody] UpdateCustomerCommand updateCustomerCommand)
        {
            await Mediator.Send(updateCustomerCommand);
            return NoContent();
        }
        [HttpDelete("{id:int}", Name = "DeleteCustomer")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteCustomerCommand = new DeleteCustomerCommand() { Id = id };
            await Mediator.Send(deleteCustomerCommand);
            return NoContent();
        }
        public IMediator Mediator { get; }
    }
}
