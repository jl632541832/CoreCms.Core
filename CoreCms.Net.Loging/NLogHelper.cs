using System;
using NLog;

namespace CoreCms.Net.Loging
{
    public static class NLogHelper
    {
        public static void Error(string title, Exception exception)
        {
            NLogUtil.WriteFileLog(NLog.LogLevel.Error, LogType.Other, title, exception);
            NLogUtil.WriteDbLog(NLog.LogLevel.Error, LogType.Other, title, exception);
        }

        public static void Trace(string title)
        {
            NLogUtil.WriteFileLog(NLog.LogLevel.Error, LogType.Other, title);
            //NLogUtil.WriteDbLog(NLog.LogLevel.Error, LogType.Other, title);
        }

        public static void Error(Exception exception)
        {
            NLogUtil.WriteFileLog(NLog.LogLevel.Error, LogType.Other, "", exception);
            NLogUtil.WriteDbLog(NLog.LogLevel.Error, LogType.Other, "", exception);
        }
    }
}