using Microsoft.Extensions.Logging;

namespace Commons.MyLogger
{
    public class MyLogger :ILogger
    {
        public IDisposable BeginScope<TState>(TState state)
        {
            return default(IDisposable);
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            MyNLogAdapter.Log(logLevel, $"{formatter(state, exception)}");
        }

        public static ILogger GetLog()
        {
            return new MyLogger();
        }
    }
}
