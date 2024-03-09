using TodoList.Models;
namespace TodoList.Services.TodoLists
{
    internal interface ITodoListService
    {
        Todo AddTodo(Todo todo);
        void ShowTodoList();
        void Update(Todo todo);
    }
}
