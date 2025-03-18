using CustomerProduct.Application.Contracts.Persistence;
using CustomerProduct.Domain.Entities;

namespace CustomerProduct.Persistence.Repositories
{
    /// <summary>
    /// inherit from GenericRepository and implement specific repository interface
    /// </summary>
    /// <param name="dbContext"></param>
    public class CustomerRepository(CustomerProductDbContext dbContext) : GenericRepository<Customer>(dbContext), ICustomerRepository
    {
    }
}
