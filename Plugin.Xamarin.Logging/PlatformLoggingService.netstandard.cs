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
            throw new NotImplementedException();
        }
        public static void Info(string message, string tag = "")
        {
            throw new NotImplementedException();
        }

        public static void Error(string message, string tag = "")
        {
            throw new NotImplementedException();
        }

        public static void Error(Exception e, string message, string tag = "")
        {
            throw new NotImplementedException();
        }

        public static void Debug(string message, string tag = "")
        {
            throw new NotImplementedException();
        }

        public static void Warn(string message, string tag = "")
        {
            throw new NotImplementedException();
        }

        public static string GetLog()
        {
            throw new NotImplementedException();
        }

        public static void Clear()
        {
            throw new NotImplementedException();
        }
        
        
    }
}
