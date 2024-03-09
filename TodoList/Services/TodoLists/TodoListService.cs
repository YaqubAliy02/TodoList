using TodoList.Brokers.Logging;
using TodoList.Brokers.Loggings;
using TodoList.Brokers.Storages;
using TodoList.Models;
namespace TodoList.Services.TodoLists
{
    internal class TodoListService : ITodoListService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;
        public TodoListService()
        {

            storageBroker = new FileStorageBroker();
            loggingBroker = new LoggingBroker();
        }
        public Todo AddTodo(Todo todo)
        {
            return todo is null
                ? CreateAndLogInvalidTodo()
                : ValidateAndAddTodo(todo);
        }

        public void Delete(int id)
        {
            this.storageBroker.DeleteTodo(id);
        }

        public void ShowTodoList()
        {
            Todo[] todos = this.storageBroker.ReadAllTodo();

            foreach (Todo todo in todos)
            {
                this.loggingBroker.LogInformation($"{todo.Id},{todo.TodoList}");
            }
            this.loggingBroker.LogInformation("======End of TodoList");
        }

        public void Update(Todo todo)
        {
            if(todo is null)
            {
                this.loggingBroker.LogError("Your Todo is empty");
                return;
            }
            if(todo.Id is 0 || string.IsNullOrEmpty(todo.TodoList))
            {
                this.loggingBroker.LogError("Your Todo is invalid");
            }
            this.storageBroker.UpdateTodo(todo);
        }

        private Todo CreateAndLogInvalidTodo()
        {
            loggingBroker.LogError("Todo is invalid");
            return new Todo();
        }
        private Todo ValidateAndAddTodo(Todo todo)
        {
            if (todo.Id is 0 || string.IsNullOrWhiteSpace(todo.TodoList))
            {
                loggingBroker.LogError("Todo details missing");
                return new Todo();
            }
            else
            {
                return storageBroker.AddTodo(todo);
            }
        }


    }
}
