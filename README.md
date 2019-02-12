# Plugin.XFLogger
Logging library for xamarin forms, work for iOS and Android

Nuget Url : 
https://www.nuget.org/packages/Plugin.XFLogger/1.0.1
```
Install-Package Plugin.XFLogger -Version 1.0.1
```
Configuration
In MainActiviy.cs (Android)
```C#
base.OnCreate(savedInstanceState);
Plugin.XFLogger.CrossXFLogger.Current.Configure(Plugin.XFLogger.Abstractions.LogTimeOption.DateTimeNow, "applicationLog.log", 3, 1024, Plugin.XFLogger.Abstractions.LogLevel.Info, true);
global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

```

In  / AppDelegate (iOS)
```C#
global::Xamarin.Forms.Forms.Init();
Plugin.XFLogger.CrossXFLogger.Current.Configure(Plugin.XFLogger.Abstractions.LogTimeOption.DateTimeNow, "applicationLog.log", 3, 1024, Plugin.XFLogger.Abstractions.LogLevel.Info, true);
LoadApplication(new App());
```

General usage
```C#
public void Info(string message, string tag = "")
        {
            CrossXFLogger.Current.Info(message, tag);
        }

        public void Debug(string message, string tag = "")
        {
            CrossXFLogger.Current.Debug(message, tag);
        }

        public void Error(string message, string tag = "")
        {
            CrossXFLogger.Current.Error(message, tag);
        }

        public void Error(Exception ex, string message, string tag = "")
        {
            CrossXFLogger.Current.Error(tag, message, ex);
        }

        public void Warn(string message, string tag = "")
        {
            CrossXFLogger.Current.Warn(message, tag);
        }

        public void Clear()
        {
            CrossXFLogger.Current.Purge();
        }

        public string GetLog(bool requireReverse = true)
        {
           return CrossXFLogger.Current.GetAll(requireReverse);
        }
```
