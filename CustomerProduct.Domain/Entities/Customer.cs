namespace CustomerProduct.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string DocType { get; set; }
        public string DocNum { get; set; }
        public string Email { get; set; }
        public int CustomerId { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string Phone { get; set; }
        public Product Product { get; set; }    // Navigation property
    }
}
