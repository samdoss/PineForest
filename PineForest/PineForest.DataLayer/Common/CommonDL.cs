using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using PineForest.CommonLayer;

namespace PineForest.DataLayer
{
  public class CommonDL : CommonForAllDL
  {
    #region Methods

    /// <summary>
    /// Get Server Date
    /// </summary>
    /// <returns></returns>
    public DateTime GetServerDate()
    {
      DateTime ServerDate = new DateTime();
      try
      {
        Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
        string sqlCommand = "SELECT GetDate() AS TodayDate";
        DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
        using (SqlDataReader dataReader = (SqlDataReader)db.ExecuteReader(dbCommand))
        {
          if (dataReader.HasRows)
          {
            dataReader.Read();
            ServerDate = dataReader.GetDateTime(dataReader.GetOrdinal("TodayDate"));
          }
        }
        return ServerDate;
      }
      catch (Exception ex)
      {
        ErrorLog.LogErrorMessageToDB("CommonDL.cs", "", "GetServerDate", ex.Message, new PineConnection());
      }
      return ServerDate;
    }

    /// <summary>
    /// Get Page ID
    /// </summary>
    /// <returns></returns>
    public static int GetPageID()
    {
      PineConnection _myConnection = new PineConnection();
      Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
      DbCommand dbCommand = db.GetStoredProcCommand("spGetPageID");
      String AppPath = System.Web.HttpContext.Current.Request.ApplicationPath;
      String AbsPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;

      String URL = AppPath == "/" ? AbsPath : AbsPath.Remove(AbsPath.IndexOf(AppPath), AppPath.Length);

      db.AddInParameter(dbCommand, "URL", DbType.String, URL);
      return Convert.ToInt32(db.ExecuteScalar(dbCommand));
    }

    /// <summary>
    /// Get Web App Root
    /// </summary>
    /// <returns></returns>
    public static string GetWebAppRoot()
    {
      if (System.Web.HttpContext.Current.Request.ApplicationPath == "/")
        return String.Format("{0}://{1}", System.Web.HttpContext.Current.Request.Url.Scheme, System.Web.HttpContext.Current.Request.Url.Host);
      else
        return String.Format("{0}://{1}{2}", System.Web.HttpContext.Current.Request.Url.Scheme, System.Web.HttpContext.Current.Request.Url.Host, System.Web.HttpContext.Current.Request.ApplicationPath);
    }

    /// <summary>
    /// Get Employee Upcoming Birthday
    /// </summary>
    /// <param name="PineConnection">Instance of the ACE Connection Class</param>
    /// <returns>Return the data as Dataset</returns>
    public DataSet GetEmployeeUpcomingBirthday(int CompanyID)
    {
      Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
      string sqlCommand = "spGetUpcomingbirth";
      DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
      db.AddInParameter(dbCommand, "CompanyID", DbType.String, CompanyID);
      return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// Get Employee Upcoming WeddingDay
    /// </summary>
    /// <param name="PineConnection">Instance of the ACE Connection Class</param>
    /// <returns>Return the data as Dataset</returns>
    public DataSet GetEmployeeUpcomingWeddingDay(int CompanyID)
    {
      DataSet ds = new DataSet(); ;

      try
      {
        Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
        string sqlCommand = "spGetUpcomingWedding";
        DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
        db.AddInParameter(dbCommand, "CompanyID", DbType.String, CompanyID);
        return db.ExecuteDataSet(dbCommand);
      }
      catch (Exception ex)
      {
        ErrorLog.LogErrorMessageToDB("UserDl.cs", "", "UpdateLastLoginDate", ex.Message, new PineConnection());
        return ds;
      }
    }

    public DataSet GetBankList()
    {
        DataSet dataSet;
        dataSet = new DataSet();
        try
        {
            Database database = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
            DbCommand dbCommand = database.GetStoredProcCommand("spGetBankList");
            dataSet = database.ExecuteDataSet(dbCommand);
        }
        catch (Exception exception1)
        {
            ErrorLog.LogErrorMessageToDB("", "InvoicePurchaseEntry.cs", "spGetBankList", exception1.Message.ToString(), this._myConnection);
        }
        return dataSet;
    }

    #endregion
  }
}
