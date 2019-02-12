using Plugin.XFLogger;
using Plugin.XFLogger.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plugin.Xamarin.Logging
{
    internal class LoggingService : ILoggingService
    {
        private static LoggingService _instance { get; set; }
        public static LoggingService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new LoggingService();
                return _instance;
            }
        }
        public LoggingService()
        {
   
        }

        public void Info(string message, string tag)
        {
            PlatformLoggingService.Info(message, tag);
        }

        public void Error(string message, string tag)
        {
            PlatformLoggingService.Error(message, tag);
        }

        public void Error(Exception e, string message, string tag)
        {
            PlatformLoggingService.Error(e, message, tag);
        }

        public void Debug(string message, string tag)
        {
            PlatformLoggingService.Debug(message, tag);
        }

        public void Warn(string message, string tag)
        {
            PlatformLoggingService.Warn(message, tag);
        }

        public string GetLog(bool requireReserve)
        {
            string log = PlatformLoggingService.GetLog();
            if (requireReserve)
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
        public void Clear()
        {
            PlatformLoggingService.Clear();
        }

        public void Init(LogTimeOption logTimeOption)
        {
            PlatformLoggingService.Init(logTimeOption);
        }
    }
}
