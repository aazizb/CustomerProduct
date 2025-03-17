
using AutoMapper;

using CustomerProduct.Application.Contracts.Persistence;
using CustomerProduct.Domain.Entities;

using MediatR;

namespace CustomerProduct.Application.Features.Customers.Commands.Update
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandHandler(IMapper mapper, IGenericRepository<Customer> repository)
        {
            Mapper = mapper;
            Repository = repository;
        }

        public IMapper Mapper { get; }
        public IGenericRepository<Customer> Repository { get; }

        public async Task Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer customer = await Repository.GetAsync(request.Id);
            Mapper.Map(request, customer, typeof(UpdateCustomerCommand), typeof(Customer));
            await Repository.UpdateAsync(customer);
        }
    }
}