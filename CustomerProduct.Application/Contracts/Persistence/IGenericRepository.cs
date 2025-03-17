namespace CustomerProduct.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// returns a list of Task<T>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task<IReadOnlyList<T>> GetAsync();
        /// <summary>
        /// return object of type T for a given id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns>Task<T></returns>
        Task<T> GetAsync(long id);
        /// <summary>
        /// create a new object of type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns>Task<entity></returns>
        Task<T> AddAsync(T entity);
        /// <summary>
        /// update T object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task UpdateAsync(T entity);
        /// <summary>
        /// delete T object
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task DeleteAsync(T entity);
    }
}

//public interface IAsyncRepository<T> where T : class
//{
//    Task<T> GetByIdAsync(Guid id);
//    Task<IReadOnlyList<T>> ListAllAsync();
//    Task<T> AddAsync(T entity);
//    Task UpdateAsync(T entity);
//    Task DeleteAsync(T entity);
//}