
using AutoMapper;

using CustomerProduct.Application.Contracts.Persistence;
using CustomerProduct.Domain.Entities;

using MediatR;

namespace CustomerProduct.Application.Features.Customers.Commands.Delete
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {
        public DeleteCustomerCommandHandler(IMapper mapper, IGenericRepository<Customer> repository)
        {
            Mapper = mapper;
            Repository = repository;
        }

        public IMapper Mapper { get; }
        public IGenericRepository<Customer> Repository { get; }

        public async Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer customer = await Repository.GetAsync(request.Id);
            await Repository.DeleteAsync(customer);
        }
    }
}
