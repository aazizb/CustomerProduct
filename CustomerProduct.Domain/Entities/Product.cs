namespace CustomerProduct.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductTypeName { get; set; }
        public int NumeracioTerminal { get; set; }
        public string SoldAt { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }  // navigation property
    }
}