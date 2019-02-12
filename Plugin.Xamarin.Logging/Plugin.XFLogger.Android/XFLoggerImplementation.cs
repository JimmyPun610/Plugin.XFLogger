using Plugin.XFLogger.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Plugin.XFLogger
{
    /// <summary>
    /// Implementation for Feature
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
        /// Get local storage path
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
                    switch (logLevel)
                    {
                        case LogLevel.Debug:
                            Android.Util.Log.Debug(tag, formattedMessage);
                            break;
                        case LogLevel.Info:
                            Android.Util.Log.Info(tag, formattedMessage);
                            break;
                        case LogLevel.Warn:
                            Android.Util.Log.Warn(tag, formattedMessage);
                            break;
                        case LogLevel.Error:
                            Android.Util.Log.Error(tag, formattedMessage);
                            break;
                        case LogLevel.Fatal:
                            Android.Util.Log.Wtf(tag, formattedMessage);
                            break;
                    }
                }
            }
        }
        /// <summary>
        /// Get log
        /// </summary>
        /// <param name="inDescendingOrder">Indicator the log display order. Descending Order will need more times</param>
        /// <returns></returns>
        public override string GetAll(bool inDescendingOrder = true)
        {
            string log = "";
            string logFileName = GetLogFileName();
            string localStoragePath = GetLocalStoragePath();
            string logFilePath = Path.Combine(localStoragePath, logFileName);
            if (File.Exists(logFilePath)) log = File.ReadAllText(logFilePath);
            if (inDescendingOrder)
                log = reverseLog(log);
            return log;
        }

        private string reverseLog(string logContent)
        {
            List<string> logs = logContent.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
            logs.Reverse();
            StringBuilder str = new StringBuilder();
            logs.ForEach(s =>
            {
                str.AppendLine(s);
            });
            return str.ToString();
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