using TodoList.Services.TodoLists;
using TodoList.Models;
namespace TodoList
{
    class Program
    {
        static void Main(string[] args) 
        {
            ITodoListService service = new TodoListService();
            string userChoice;
            do
            {
                PrintMenu();
                Console.Write("Enter your choice:");
                userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "1":
                        Console.Clear();
                        Todo todo = new Todo();

                        Console.Write("Enter id: ");
                        string userIdStr = Console.ReadLine();
                        int userId = Convert.ToInt32(userIdStr);
                        todo.Id = userId;

                        Console.Write("Enter todo: ");
                        string nameOfItem = Console.ReadLine();
                        todo.TodoList = nameOfItem;
                        service.AddTodo(todo);
                        break;

                    case "2":
                        {
                            Console.Clear();
                            service.ShowTodoList();
                        }
                        break;

                    case "3":
                        {
                            Console.Clear();
                            Console.WriteLine("Enter an id which you want to delete");
                            Console.Write("Enter id:");
                            string deleteWithIdStr = Console.ReadLine();
                            int deleteWithId = Convert.ToInt32(deleteWithIdStr);
                            service.Delete(deleteWithId);
                        }
                        break;

                    case "4":
                        {
                            Todo newTodo = new Todo();
                            Console.Clear();
                            Console.WriteLine("Enter an id which you want  to edit");
                            Console.Write("Enter an id:");
                            string idStr = Console.ReadLine();
                            int id = Convert.ToInt32(idStr);
                            Console.Write("Enter new todo:");
                            string todoList = Console.ReadLine();
                            
                            newTodo.Id = id;
                            newTodo.TodoList= todoList;
                            service.Update(newTodo);
                        }
                        break;

                    case "0": break;

                    default:
                        Console.WriteLine("You entered wrong input, Try again");
                        break;
                }
            }
            while (userChoice != "0");
            Console.Clear();
            Console.WriteLine("The app has been finished");
        }
        public static void PrintMenu()
        {
            Console.WriteLine("1.Add todo list");
            Console.WriteLine("2.Display");
            Console.WriteLine("3.Delete");
            Console.WriteLine("4.Update");
            Console.WriteLine("0.Exit");
        }
    }
}