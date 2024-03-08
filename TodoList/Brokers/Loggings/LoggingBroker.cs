using System;
using TodoList.Brokers.Logging;

namespace TodoList.Brokers.Loggings
{
    internal class LoggingBroker : ILoggingBroker
    {
        public void LogError(Exception exception)
        {
           Console.ForegroundColor = ConsoleColor.DarkRed;
           Console.WriteLine(exception);
           Console.ResetColor();
        }

        public void LogError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void LogInformation(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
