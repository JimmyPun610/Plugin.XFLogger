# Plugin.XFLogger
Logging library for xamarin forms

Nuget Url : 
https://www.nuget.org/packages/Plugin.XFLogger/1.0.1
```
Install-Package Plugin.XFLogger -Version 1.0.1
```
Configuration
In MainActiviy.cs (Android)
```C#
base.OnCreate(savedInstanceState);
.....

Plugin.XFLogger.CrossXFLogger.Current.Configure(Plugin.XFLogger.Abstractions.LogTimeOption.DateTimeNow, "applicationLog.log", 3, 1024, Plugin.XFLogger.Abstractions.LogLevel.Info, true);
......
global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

```

In  / AppDelegate (iOS)
```C#
global::Xamarin.Forms.Forms.Init();
Plugin.XFLogger.CrossXFLogger.Current.Configure(Plugin.XFLogger.Abstractions.LogTimeOption.DateTimeNow, "applicationLog.log", 3, 1024, Plugin.XFLogger.Abstractions.LogLevel.Info, true);
LoadApplication(new App());
```
