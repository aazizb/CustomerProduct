

using AutoMapper;

using CustomerProduct.Application.Contracts.Persistence;
using CustomerProduct.Domain.Entities;

using MediatR;

namespace CustomerProduct.Application.Features.Customers
{
    /// <summary>
    /// take GetCustomerListQuery query as parameter and return a list of CustomerListVm
    /// </summary>
    public class GetCustomerListQueryHandler : IRequestHandler<GetCustomerListQuery, List<CustomerListVm>>
    {
        public GetCustomerListQueryHandler(IMapper mapper, IGenericRepository<Customer> repository)
        {
            Mapper = mapper;
            Repository = repository;
        }

        public IMapper Mapper { get; }
        public IGenericRepository<Customer> Repository { get; }

        public async Task<List<CustomerListVm>> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
        {
            var customerList = await Repository.GetAsync();

            return Mapper.Map<List<CustomerListVm>>(customerList);
        }
    }
}
