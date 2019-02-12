using Plugin.XFLogger;
using Plugin.XFLogger.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plugin.Xamarin.Logging
{
    internal class PlatformLoggingService
    {
        public static void Init(LogTimeOption logTimeOption)
        {
            CrossXFLogger.Current.Configure(logTimeOption, "applicationLog.log", 3, 100, LogLevel.Info, true);
        }

        public static void Info(string message, string tag = "")
        {
            CrossXFLogger.Current.Log(LogLevel.Info, tag, message);
        }

        public static void Error(string message, string tag = "")
        {
            CrossXFLogger.Current.Log(LogLevel.Error, tag, message);
        }

        public static void Error(Exception e, string message, string tag = "")
        {
            CrossXFLogger.Current.Log(LogLevel.Error, tag, message, e);
        }

        public static void Debug(string message, string tag = "")
        {
            CrossXFLogger.Current.Log(LogLevel.Debug, tag, message);
        }

        public static void Warn(string message, string tag = "")
        {
            CrossXFLogger.Current.Log(LogLevel.Warn, tag, message);
        }

        public static string GetLog()
        {
            return CrossXFLogger.Current.GetAll();
        }

        public static void Clear()
        {
            CrossXFLogger.Current.Purge();
        }
    }
}
