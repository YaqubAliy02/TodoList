namespace TodoList.Brokers.Logging
{
    internal interface ILoggingBroker
    {
        void LogError(Exception exception);
        void LogInformation(string message);
        void LogError(string message);

    }
}
