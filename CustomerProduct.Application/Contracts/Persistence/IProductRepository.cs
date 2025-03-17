using CustomerProduct.Domain.Entities;

namespace CustomerProduct.Application.Contracts.Persistence
{
    public interface IProductRepository : IGenericRepository<Product>
    {
    }
}
