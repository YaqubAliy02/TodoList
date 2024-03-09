using TodoList.Models;
namespace TodoList.Brokers.Storages
{
    internal class FileStorageBroker : IStorageBroker
    {
        private const string FILEPATH = "../../../Assets/TodoList.txt";
        public FileStorageBroker()
        {
            EnsureFileExists();
        }
        public Todo AddTodo(Todo todo)
        {
            string todoLine = $"{todo.Id}*{todo.TodoList}\n";

            File.AppendAllText(FILEPATH, todoLine);
            return todo;
        }
        public Todo[] ReadAllTodo()
        {
            string[] TodoLines = File.ReadAllLines(FILEPATH);
            int todoLength = TodoLines.Length;
            Todo[] todos = new Todo[todoLength];

            for(int iteration = 0; iteration < todoLength; iteration++)
            {
                string todoLine = TodoLines[iteration];
                string[] todoProperties = todoLine.Split("*");
                Todo todo = new Todo
                {
                    Id = Convert.ToInt32(todoProperties[0]),
                    TodoList = todoProperties[1]
                };
                todos[iteration] = todo;
            }
            return todos;
        }
        public void DeleteTodo(int id)
        {
            Todo[] todos = this.ReadAllTodo();
            File.WriteAllText(FILEPATH, string.Empty);
            for (int iteration = 0; iteration < todos.Length; iteration++)
            {
                if (todos[iteration].Id != id)
                {
                    this.AddTodo(todos[iteration]);
                }
            }
        }
        public void UpdateTodo(Todo todo)
        {
            Todo[] todos = ReadAllTodo();
            for(int iteration = 0; iteration<todos.Length; iteration++)
            {
                if (todos[iteration].Id == todo.Id)
                {
                    todos[iteration] = todo;
                    break;
                }
            }
            File.WriteAllText(FILEPATH, string.Empty);
            foreach(Todo todo1 in todos)
            {
                AddTodo(todo1);
            }
        }
        private void EnsureFileExists()
        {
            bool fileExists = File.Exists(FILEPATH);
            if (fileExists is false) 
            {
                File.Create(FILEPATH).Close();
            }
        }
    }
}
