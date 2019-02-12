using Plugin.XFLogger.Abstractions;
using System;
using System.IO;

namespace Plugin.XFLogger
{
    /// <summary>
    /// Implementation for Logger
    /// </summary>
    public class XFLoggerImplementation : LoggerBase
    {
        /// <summary>
        /// Configure logger
        /// </summary>
        /// <param name="logTimeOption">DateTime.Now / DateTime.UtcNow for log time</param>
        /// <param name="logFileName"></param>
        /// <param name="maxLogFilesCount"></param>
        /// <param name="maxLogFileSizeKb"></param>
        /// <param name="logLevel"></param>
        /// <param name="logToConsole"></param>
        public override void Configure(LogTimeOption logTimeOption = LogTimeOption.DateTimeNow, string logFileName = "app.log", int maxLogFilesCount = 3, int maxLogFileSizeKb = 1000, LogLevel logLevel = LogLevel.Warn, bool logToConsole = false)
        {
            base.Configure(logTimeOption, logFileName, maxLogFilesCount, maxLogFileSizeKb, logLevel, logToConsole);
        }

        /// <summary>
        /// Get local stoarge path
        /// </summary>
        /// <returns></returns>
        public override string GetLocalStoragePath()
        {
            string localStoragePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return localStoragePath;
        }
        /// <summary>
        /// Log message
        /// </summary>
        /// <param name="logLevel"></param>
        /// <param name="tag"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public override void Log(LogLevel logLevel = LogLevel.Warn, string tag = "tag", string message = "message", Exception exception = null)
        {
            LogLevel currentLogLevel = GetLogLevel();
            if (logLevel >= currentLogLevel)
            {
                string logFileName = GetLogFileName();
                string localStoragePath = GetLocalStoragePath();
                string logFilePath = Path.Combine(localStoragePath, logFileName);
                string formattedMessage = FormatMessage(logLevel, tag, message, exception);
                File.AppendAllText(logFilePath, formattedMessage);
                bool logToConsole = GetLogToConsole();
                if (logToConsole)
                {
                    System.Console.WriteLine(formattedMessage);
                }
            }
        }
        /// <summary>
        /// Get log
        /// </summary>
        /// <returns></returns>
        public override string GetAll()
        {
            string log = "";
            string logFileName = GetLogFileName();
            string localStoragePath = GetLocalStoragePath();
            string logFilePath = Path.Combine(localStoragePath, logFileName);
            if (File.Exists(logFilePath)) log = File.ReadAllText(logFilePath);
            return log;
        }
        /// <summary>
        /// Purge log
        /// </summary>
        public override void Purge()
        {
            string logFileName = GetLogFileName();
            string localStoragePath = GetLocalStoragePath();
            string logFilePath = Path.Combine(localStoragePath, logFileName);
            if (File.Exists(logFilePath)) File.Delete(logFilePath);
        }
    }
}