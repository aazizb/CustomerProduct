using MediatR;

namespace CustomerProduct.Application.Features.Customers
{
    class GetCustomerDetailQuery : IRequest<CustomerDetailVm>
    {
        public int Id { get; set; }
    }
}