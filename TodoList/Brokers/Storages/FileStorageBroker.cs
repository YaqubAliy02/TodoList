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

        public void DeleteTodo(int id)
        {
            throw new NotImplementedException();
        }

        public Todo[] ReadAllTodo()
        {
            throw new NotImplementedException();
        }

        public void UpdateTodo(Todo todo)
        {
            throw new NotImplementedException();
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
