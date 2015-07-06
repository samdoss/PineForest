//using Microsoft.Practices.EnterpriseLibrary.Logging;
//using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
//using Microsoft.Practices.EnterpriseLibrary.Common;
//using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Configuration.Design;
//using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Logging;

namespace PineForest.CommonLayer
{
    public class HandledException
    {
        //private string WARNING = "Warning";
        ////private string HAR = "Handle And Resume Policy";
        ////private string LOGOP = "Log Only Policy";
        ////public enum PolicyEnum
        ////{
        ////    LogOnly = 1,
        ////    HandleAndResume = 2
        ////}

        //public HandledException()
        //{

        //}
        //public HandledException(Exception errEx)
        //{
        //    LogEntry objLog = new LogEntry();
        //    objLog.Message = errEx.Message;
        //    objLog.Categories.Add(WARNING);
        //    Logger.Write(objLog);
        //    objLog = null;
        //}

        //public string LogOrResumeNotPropagate(Exception ex, string PolicyName)
        //{
        //    bool rethrow = false;

        //    rethrow = ExceptionPolicy.HandleException(ex, PolicyName);
        //    if ((rethrow))
        //    {
        //        return "";
        //    }
        //    else
        //    {
        //        if (ex.InnerException == null)
        //        {
        //            return ex.Message;
        //        }
        //        else
        //        {
        //            return ex.Message.ToString() + "|".ToString() + ex.InnerException.ToString();
        //        }

        //    }
        //}
    } 

}
