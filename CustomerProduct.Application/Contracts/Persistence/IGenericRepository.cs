namespace CustomerProduct.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// returns a list of T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task<IReadOnlyList<T>> GetAsync<T>();
        /// <summary>
        /// return object of type T for a given id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetAsync<T>(long id);
        /// <summary>
        /// create a new object of type T and return it
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> AddAsync<T>(T entity);
        /// <summary>
        /// update T object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> UpdateAsync<T>(T entity);
        /// <summary>
        /// delete T object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync<T>(long id);
    }
}
