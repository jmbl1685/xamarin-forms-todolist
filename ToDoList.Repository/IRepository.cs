using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoList.Repository
{
    public interface IRepository<T, ID> where T : class
    {
        Task<List<T>> GetAsync();
        Task<T> GetByIdAsync(ID id);
        Task<int> DeleteAsync(T entity);
        Task<int> AddOrUpdateAsync(T entity);

    }
}
