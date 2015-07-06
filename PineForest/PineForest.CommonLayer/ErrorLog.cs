using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;

namespace PineForest.CommonLayer
{
  public static class ErrorLog
  {
    public static PineConnection _myConnection = new PineConnection();
    /// <summary>
    /// LogErrorMessageToDB
    /// </summary>
    /// <param name="pageName"></param>
    /// <param name="className"></param>
    /// <param name="eventName"></param>
    /// <param name="errorMessage"></param>
    /// <param name="_pineConnection"></param>
    public static void LogErrorMessageToDB(string pageName, string className, string eventName, string errorMessage, PineConnection _pineConnection)
    {
      try
      {
        //if (errorMessage != "Thread was being aborted.")
        //{
        Database db = DatabaseFactory.CreateDatabase(_pineConnection.DatabaseName);
        string sqlCommand = "spAddLogErrorMessageToDB";
        DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
        db.AddInParameter(dbCommand, "PageName", DbType.String, pageName);
        db.AddInParameter(dbCommand, "ClassName", DbType.String, className);
        db.AddInParameter(dbCommand, "EventName", DbType.String, eventName);
        db.AddInParameter(dbCommand, "ErrorMessage", DbType.String, errorMessage);
        db.ExecuteNonQuery(dbCommand);
        // }

      }
      catch { }
    }

    public static DataSet GetErrorLogList()
    {
      DataSet ds = new DataSet();
      try
      {
        Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
        string sqlCommand = "spGetErrorLog";
        DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

        ds = db.ExecuteDataSet(dbCommand);
      }
      catch (Exception ex)
      {
        ErrorLog.LogErrorMessageToDB("", "ErrorLog.cs", "GetErrorLogList", ex.Message.ToString(), _myConnection);
        System.Web.HttpContext.Current.Response.Redirect("~/OrderErrorPage.aspx");
      }
      return ds;
    }
  }
}