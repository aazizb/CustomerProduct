
using AutoMapper;

using CustomerProduct.Application.Contracts.Persistence;
using CustomerProduct.Application.Features.Customers.Commands.DTOs;
using CustomerProduct.Domain.Entities;

using MediatR;

namespace CustomerProduct.Application.Features.Customers
{
    public class CreateCustomeerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerCommandResponse>
    {
        public CreateCustomeerCommandHandler(IMapper mapper, IGenericRepository<Customer> repository)
        {
            Mapper = mapper;
            Repository = repository;
        }

        public IMapper Mapper { get; }
        public IGenericRepository<Customer> Repository { get; }

        public async Task<CreateCustomerCommandResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            CreateCustomerCommandResponse response = new();
            CreateCustomerCommandValidator validator = new();
            var validationResult = validator.Validate(request);
            if (validationResult.Errors.Any()) 
            {
                response.Success = false;
                response.ValidationErrors = [];
                foreach (var error in validationResult.Errors) 
                {
                    response.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (response.Success)
            {
                Customer customer = new() { FamilyName = request.FamilyName, GivenName = request.GivenName };

                customer = await Repository.AddAsync(customer);
                response.Customer = Mapper.Map<CreateCustomerDto>(customer);
            }

            return response;
        }
    }
}
