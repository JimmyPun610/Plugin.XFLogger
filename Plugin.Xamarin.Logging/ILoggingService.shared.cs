using System;
using System.Collections.Generic;
using System.Text;

namespace Plugin.Xamarin.Logging
{
    public interface ILoggingService
    {
        void Init(XFLogger.Abstractions.LogTimeOption logTimeOption);
        void Info(string message, string tag);

        void Error(string message, string tag);
        void Error(Exception e, string message, string tag);

        void Debug(string message, string tag);

        void Warn(string message, string tag);
       
        string GetLog(bool requireReserve);

        void Clear();
    }
}
