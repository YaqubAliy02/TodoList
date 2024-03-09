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
                Id = 2,
                TodoList = "Leedcode"
            };
            service.AddTodo(todo);
            service.ShowTodoList();
            service.Update(todo);
        }
    }
}