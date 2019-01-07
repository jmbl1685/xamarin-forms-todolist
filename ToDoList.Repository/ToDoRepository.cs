using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Entities;

namespace ToDoList.Repository
{
    public class ToDoRepository : IRepository<ToDoItem, int>
    {

        public Task<int> AddOrUpdateAsync(ToDoItem toDoItem)
        {
            if (toDoItem.Id != 0)
                return DBConnection.Connect()
                    .UpdateAsync(toDoItem);
            else
                return DBConnection.Connect()
                    .InsertAsync(toDoItem);
        }

        public Task<int> DeleteAsync(ToDoItem toDoItem)
        {
            return DBConnection.Connect()
                .DeleteAsync(toDoItem);
        }

        public Task<List<ToDoItem>> GetAsync()
        {
            return DBConnection.Connect()
                .Table<ToDoItem>()
                .ToListAsync();
        }

        public Task<ToDoItem> GetByIdAsync(int id)
        {
            return DBConnection.Connect()
                .Table<ToDoItem>()
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
        }

        public Task<List<ToDoItem>> GetItemsNotDoneAsync()
        {
            var query = "SELECT * FROM [ToDoItem] WHERE [Done] = 0";
            return DBConnection.Connect()
                .QueryAsync<ToDoItem>(query);
        }

    }
}
