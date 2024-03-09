using TodoList.Services.TodoLists;
using TodoList.Models;
namespace TodoList
{
    class Program
    {
        static void Main(string[] args) 
        {
            ITodoListService service = new TodoListService();
            Todo todo = new Todo
            {
                Id = 1,
                TodoList = "Sleeping"
            };
            service.AddTodo(todo);
            service.ShowTodoList();
        }
    }
}