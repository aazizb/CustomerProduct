
using AutoMapper;

using CustomerProduct.Application.Contracts.Persistence;
using CustomerProduct.Domain.Entities;

using MediatR;

namespace CustomerProduct.Application.Features.Customers
{
    class GetCustomerdetailQueryHandler : IRequestHandler<GetCustomerDetailQuery, CustomerDetailVm>
    {
        public GetCustomerdetailQueryHandler(IMapper mapper, IGenericRepository<Customer> repository)
        {
            Mapper = mapper;
            Repository = repository;
        }

        public IMapper Mapper { get; }
        public IGenericRepository<Customer> Repository { get; }

        public async Task<CustomerDetailVm> Handle(GetCustomerDetailQuery request, CancellationToken cancellationToken)
        {
            var customer = await Repository.GetAsync(request.Id);

            return Mapper.Map<CustomerDetailVm>(customer);
        }
    }
}
