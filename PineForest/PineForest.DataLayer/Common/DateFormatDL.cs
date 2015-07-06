using System;
using System.Data;
using System.Data.Common;
using PineForest.CommonLayer;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace PineForest.DataLayer
{
  public class DateFormatDL : CommonForAllDL
  {
    #region Properties

    public int DateFormatID { get; set; }

    public string DateFormatText { get; set; }

    public string DateFormatValue { get; set; }

    #endregion

    #region Constructors

    public DateFormatDL() { }

    public DateFormatDL(int DateFormatID, bool getAllProperties)
    {
      if (getAllProperties)
      {
        GetDateFormat(DateFormatID);
      }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Get Date Format List
    /// </summary>
    /// <param name="PineConnection">Instance of the PineConnection Class</param>
    /// <returns>Return the data as Dataset</returns>
    public DataSet GetDateFormatList()
    {
      DataSet ds = new DataSet();
      try
      {
        Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
        string sqlCommand = "spGetDateFormatList";
        DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
        ds = db.ExecuteDataSet(dbCommand);
      }
      catch (Exception ex)
      {
        ErrorLog.LogErrorMessageToDB("", "DateFormatDL.cs", "GetDateFormatList", ex.Message.ToString(), _myConnection);
      }
      return ds;
    }

    /// <summary>
    /// Gets the User Settings Details based on the UserID
    /// </summary>
    private void GetDateFormat(int DateFormatID)
    {
      try
      {
        Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
        string sqlCommand = "spGetDateFormat";
        DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
        db.AddInParameter(dbCommand, "DateFormatID", DbType.Int32, DateFormatID);
        DataSet ds = db.ExecuteDataSet(dbCommand);

        // Load Employee Info
        if (ds.Tables[0].Rows.Count > 0)
        {
          DataRow dRow = ds.Tables[0].Rows[0];

          DateFormatValue = Convert.ToString(dRow["DateFormatValue"]);
        }
      }
      catch (Exception ex)
      {
        ErrorLog.LogErrorMessageToDB("", "SettingsDL.cs", "GetDateFormat", ex.Message.ToString(), _myConnection);
      }
    }

    #endregion
  }
}
