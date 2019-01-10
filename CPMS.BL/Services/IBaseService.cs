using System.Collections.Generic;
using System.Threading.Tasks;

namespace CPMS.BL.Services
{
    /// <summary>
    /// Base service interface declare methods that are used in implemented services.
    /// </summary>
    /// <typeparam name="T">Entity type of T</typeparam>
    public interface IBaseService<T>
    {
        /// <summary>
        /// Create item in DbSet through the factory pattern
        /// </summary>
        /// <param name="item">Item type of T</param>
        /// <returns>Item type of T with added attributes from DB</returns>
        T Add(T item);

        /// <summary>
        /// Method find item in DbSet by ID.
        /// If item is found is item removed from DbSet through repository pattern. 
        /// </summary>
        /// <param name="id">Id of item</param>
        /// <returns>State of thread</returns>
        Task Delete(int id);

        /// <summary>
        /// Method update item through repository pattern
        /// </summary>
        /// <param name="item">Item type of T</param>
        void Update(T item);

        /// <summary>
        /// Method find item through repository pattern.
        /// If item is found return item.
        /// </summary>
        /// <param name="id">Id of item</param>
        /// <returns>Item type of T or null</returns>
        Task<T> GetById(int id);

        /// <summary>
        /// Method get all items type of T as collection from repository pattern
        /// </summary>
        /// <returns>Collection of items type of T</returns>
        Task<IEnumerable<T>> GetAll();
    }
}
