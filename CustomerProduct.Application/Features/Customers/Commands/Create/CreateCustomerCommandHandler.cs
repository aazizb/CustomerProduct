
using AutoMapper;

using CustomerProduct.Application.Contracts.Persistence;
using CustomerProduct.Domain.Entities;

using MediatR;

namespace CustomerProduct.Application.Features.Customers
{
    /// <summary>
    /// Create a customer and return the newly created customer along with validation errors
    /// </summary>
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerCommandResponse>
    {
        public CreateCustomerCommandHandler(IMapper mapper, IGenericRepository<Customer> repository)
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
                Customer customer = new() {DocType = request.DocType, DocNum = request.DocNum, Email = request.Email, CustomerId = request.CustomerId, GivenName = request.GivenName, FamilyName = request.FamilyName, Phone = request.Phone};

                customer = await Repository.AddAsync(customer);
                response.Customer = Mapper.Map<CreateCustomerDto>(customer);
            }

            return response;
        }
    }
}
