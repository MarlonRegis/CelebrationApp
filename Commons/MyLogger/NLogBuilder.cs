using NLog;
using NLog.Config;
using NLog.Targets;

namespace Commons.MyLogger
{
    public class NLogBuilder
        {
            LoggingConfiguration _config;
            FileTarget _target;

            public void AddFileTarget()
            {
                _target =  new FileTarget()
                {
                    FileName = "c:\\Sidi\\study\\FinalProject\\CelebrationApp\\Commons\\Logs\\${level}.log",
                    Layout = "${longdate}|${level}|${processid}|${threadid}|${callsite}|${message}",
                    MaxArchiveFiles = 10,
                    MaxArchiveDays = 20,
                    ArchiveAboveSize = 1024 * 1024 * 10
                };
            }

            public void AddRule(LogLevel minLevel, LogLevel maxLevel)
            {
                _config.AddRule(minLevel, maxLevel, _target);
            }
        
            public Logger Builder()
            {
                _config = new LoggingConfiguration();
                AddFileTarget();
                AddRule(LogLevel.Debug, LogLevel.Fatal);

                LogManager.Configuration = _config;
                return LogManager.GetCurrentClassLogger();
            }
        }
}
