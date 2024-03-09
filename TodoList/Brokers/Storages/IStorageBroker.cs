using TodoList.Models;
namespace TodoList.Brokers.Storages
{
    internal interface IStorageBroker
    {
       Todo AddTodo(Todo todo);
        Todo[] ReadAllTodo();
        void UpdateTodo(Todo todo);
        void DeleteTodo(int id);
    }
}
