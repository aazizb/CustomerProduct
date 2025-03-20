using MediatR;

namespace CustomerProduct.Application.Features.Customers
{
    public class DeleteCustomerCommand : IRequest
    {
        public int Id { get; set; }
    }
}
