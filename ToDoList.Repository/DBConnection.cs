using SQLite;
using ToDoList.Entities;

namespace ToDoList.Repository
{
    public static class DBConnection
    {
        private static SQLiteAsyncConnection database;

        public static void Connect(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<ToDoItem>().Wait();
        }

        public static SQLiteAsyncConnection Connect() => database;
    }
}
