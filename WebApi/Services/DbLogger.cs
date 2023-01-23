namespace WebApi.Services;

public class DbLogger : ILoggerService
{
    public void Write(string message)
    {
        // we will implement AWS CloudWatch logging
        System.Console.WriteLine("[DBLogger] " + message);
    }
}
