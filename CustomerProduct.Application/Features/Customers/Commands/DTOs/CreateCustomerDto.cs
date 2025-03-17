namespace CustomerProduct.Application.Features.Customers
{
    public class CreateCustomerDto
    {
        public int CustomerId { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
    }
}
