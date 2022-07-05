using NLog;

namespace Commons.MyLogger
{
    public static class MyNLogAdapter
    {
        public static LogLevel ConverterLogLevelLogger(Microsoft.Extensions.Logging.LogLevel logLevel)
        {
            return LogLevel.AllLevels.ElementAt(GetOrder(logLevel));
        }

        public static void Log(Microsoft.Extensions.Logging.LogLevel logLevel, String message)
        {
            var logLevelNLogger = ConverterLogLevelLogger(logLevel);
            MyNLogAdapter.GetMyNLogger().Log(logLevelNLogger, message);
        }

        public static Logger GetMyNLogger()
        {
            return new NLogBuilder().Builder();
        }

        public static int GetOrder(Microsoft.Extensions.Logging.LogLevel logLevel)
        {
            return Enum.GetValues(typeof(Microsoft.Extensions.Logging.LogLevel)).Cast<Microsoft.Extensions.Logging.LogLevel>().Select((x, i) => new { item = x, index = i }).Single(x => x.item == logLevel).index;
        }
    }
}
