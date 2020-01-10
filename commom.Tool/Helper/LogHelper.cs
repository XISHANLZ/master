using log4net;
using System;
using System.Collections.Generic;
using System.Text;

namespace common.Tools.Helper
{
    public class LogHelper
    {
        private static ILog logInfo = LogManager.GetLogger("NETCoreRepository", "INFO");
        private static ILog logError = LogManager.GetLogger("NETCoreRepository", "ERROR");
        //private static ILog logOutSource = LogManager.GetLogger("NETCoreRepository", "OUTSOURCE");
        //private static ILog logMSG = LogManager.GetLogger("NETCoreRepository", "MSG");
        //private static ILog logTime = LogManager.GetLogger("NETCoreRepository", "TIME");
        //private static ILog logTask = LogManager.GetLogger("NETCoreRepository", "TASK");
        //private static ILog logWechat = LogManager.GetLogger("NETCoreRepository", "Wechat");

        //public static void WechatLog(string msg)
        //{
        //    logWechat.Info(msg);

        //}
        public static void Info(string msg)
        {
            logInfo.Info(msg);
        }

        public static void Error(string msg)
        {
            logError.Error(msg);
        }

        //public static void MSG(string msg)
        //{
        //    logMSG.Info(msg);
        //}
        //public static void Time(string msg)
        //{
        //    logTime.Info(msg);
        //}
        //public static void TASK(string msg)
        //{
        //    logTask.Info(msg);
        //}
        ///// <summary>
        ///// 外部接口
        ///// </summary>
        ///// <param name="msg"></param>
        //public static void OutSourceInfo(string msg)
        //{
        //    logOutSource.Info(msg);
        //}

        public static void Error(Exception ex)
        {
            LogHelper.Error("发生异常:" + ex.Source + "\n" + ex.StackTrace + "\n" + ex.Message + "\n" + ex.InnerException);
        }
    }
}
