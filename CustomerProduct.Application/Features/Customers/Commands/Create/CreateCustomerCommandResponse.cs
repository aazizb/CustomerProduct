using CustomerProduct.Application.Responses;

namespace CustomerProduct.Application.Features.Customers
{
    public class CreateCustomerCommandResponse : BaseResponse
    {
        public CreateCustomerCommandResponse() : base() { }

        public CreateCustomerDto Customer { get; set; } = default!;
    }
}