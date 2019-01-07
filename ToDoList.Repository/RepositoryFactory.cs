namespace ToDoList.Repository
{
    public static class RepositoryFactory
    {
        public static ToDoRepository GetToDoRepository() => new ToDoRepository();
    }
}
