using CustomerProduct.Domain.Entities;

namespace CustomerProduct.Application.Contracts.Persistence
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
    }
}
