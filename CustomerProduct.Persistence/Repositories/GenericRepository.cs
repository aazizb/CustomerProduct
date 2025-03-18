
using CustomerProduct.Application.Contracts.Persistence;

using Microsoft.EntityFrameworkCore;

namespace CustomerProduct.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public GenericRepository(CustomerProductDbContext dbContext) => DbContext = dbContext;

        public CustomerProductDbContext DbContext { get; }

        public async Task<T> AddAsync(T entity)
        {
            await DbContext.Set<T>().AddAsync(entity);
            await DbContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            DbContext.Set<T>().Remove(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync() => 
            await DbContext.Set<T>().ToListAsync();

        public async Task<T> GetAsync(int id) => 
            await DbContext.Set<T>().FindAsync(id);
    

        public async Task UpdateAsync(T entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
        }
    }
}
