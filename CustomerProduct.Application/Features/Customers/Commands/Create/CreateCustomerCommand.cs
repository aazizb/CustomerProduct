using MediatR;

namespace CustomerProduct.Application.Features.Customers
{
    public class CreateCustomerCommand : IRequest<CreateCustomerCommandResponse>
    {
        public string DocType { get; set; } = string.Empty;
        public string DocNum { get; set; }  = string.Empty ;
        public string Email { get; set; } = string.Empty;
        public int CustomerId { get; set; }
        public string GivenName { get; set; } = string.Empty;
        public string FamilyName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}
