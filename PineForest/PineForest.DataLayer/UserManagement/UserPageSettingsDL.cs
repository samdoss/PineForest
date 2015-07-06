using System;
using System.Data;
using System.Data.Common;
using PineForest.CommonLayer;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace PineForest.DataLayer
{
  public class UserPageSettingsDL : CommonForAllDL
  {
    #region Properties

    public int UserID { get; set; }

    public int EmployeeID { get; set; }

    public DateTime AuditDate { get; set; }

    #endregion

    #region Constructors

    public UserPageSettingsDL() { }

    public UserPageSettingsDL(int employeeID, bool getAllProperties)
    {
      EmployeeID = employeeID;
      if (getAllProperties)
      {
      }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Get User Page List
    /// </summary>
    /// <param name="ACE">Instance of the ACE</param>
    /// <returns>Return the data as Dataset</returns>
    public DataSet GetUserPageList()
    {
      DataSet ds = new DataSet();
      try
      {
        Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
        string sqlCommand = "spGetUserPageList";
        DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
        EmployeeID = 0;
        db.AddInParameter(dbCommand, "EmployeeID", DbType.Int32, EmployeeID);
        ds = db.ExecuteDataSet(dbCommand);
      }
      catch (Exception ex)
      {
        ErrorLog.LogErrorMessageToDB("", "UserPageSettingsDL.cs", "GetUserPageList", ex.Message.ToString(), _myConnection);
      }
      return ds;
    }

    #endregion
  }
}
