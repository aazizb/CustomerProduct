using MediatR;

namespace CustomerProduct.Application.Features.Customers
{
    public class GetCustomerDetailQuery : IRequest<CustomerDetailVm>
    {
        public int Id { get; set; }
    }
}