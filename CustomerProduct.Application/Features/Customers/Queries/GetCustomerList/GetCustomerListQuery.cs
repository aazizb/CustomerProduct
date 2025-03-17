using MediatR;

namespace CustomerProduct.Application.Features.Customers
{
    public class GetCustomerListQuery : IRequest<List<CustomerListVm>>
    {
    }
}
