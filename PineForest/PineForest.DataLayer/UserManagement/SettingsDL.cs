using System;
using System.Data;
using System.Data.Common;
using PineForest.CommonLayer;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace PineForest.DataLayer
{
  public class SettingsDL : CommonForAllDL
  {
    #region Properties

    public int UserSettingsID { get; set; }

    public int UserID { get; set; }

    public int DateFormatID { get; set; }

    public int BackgroundColorID { get; set; }

    #endregion

    #region Constructors

    public SettingsDL() { }

    public SettingsDL(int userID, bool getAllProperties)
    {
      UserID = userID;
      if (getAllProperties)
      {
        GetUserSettings(userID);
      }
    }

    #endregion

    #region Methods

    /// <summary>
    ///Commit
    /// </summary>
    /// <returns>TransactionResult - Success / Failure</returns>
    public TransactionResult Commit()
    {
      TransactionResult result = null;
      Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
      using (DbConnection connection = db.CreateConnection())
      {
        connection.Open();
        DbTransaction transaction = connection.BeginTransaction();
        try
        {
          switch (ScreenMode)
          {
            case ScreenMode.Add:
              //Adding Or Editing Settings
              result = AddEditUserSettings(db, transaction);
              if (result.Status == TransactionStatus.Failure)
              {
                transaction.Rollback();
                return result;
              }
              break;
            case ScreenMode.Edit:
              break;
            case ScreenMode.Delete:
              if (result.Status == TransactionStatus.Failure)
              {
                transaction.Rollback();
                return result;
              }
              break;
            case ScreenMode.View:
              break;
          }
          transaction.Commit();
          return result;
        }
        catch (Exception ex)
        {
          transaction.Rollback();
          if (ScreenMode == ScreenMode.Add)
          {
            ErrorLog.LogErrorMessageToDB("", "SettingsDL.cs", "Commit For Add", ex.Message.ToString(), _myConnection);
            return new TransactionResult(TransactionStatus.Failure, "Failure Adding");
          }
          if (ScreenMode == ScreenMode.Edit)
          {
            ErrorLog.LogErrorMessageToDB("", "SettingsDL.cs", "Commit For Edit", ex.Message.ToString(), _myConnection);
            return new TransactionResult(TransactionStatus.Failure, "Failure Updating");
          }
          if (ScreenMode == ScreenMode.Delete)
          {
            ErrorLog.LogErrorMessageToDB("", "SettingsDL.cs", "Commit For Delete", ex.Message.ToString(), _myConnection);
            return new TransactionResult(TransactionStatus.Failure, "Failure Deleting");
          }
        }
      }
      return null;
    }

    /// <summary>
    /// Add/Edit UserSettings
    /// </summary>
    /// <param name="db"></param>
    /// <param name="transaction"></param>
    /// <returns></returns>
    public TransactionResult AddEditUserSettings(Database db, DbTransaction transaction)
    {
      int returnValue = 0;
      string sqlCommand = "spAddEditUserSettings";
      DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
      db.AddInParameter(dbCommand, "UserSettingsID", DbType.Int32, UserSettingsID);
      db.AddInParameter(dbCommand, "UserID", DbType.Int32, UserID);
      db.AddInParameter(dbCommand, "DateFormatID", DbType.Int32, DateFormatID);
      db.AddInParameter(dbCommand, "BackGroundColorID", DbType.Int32, BackgroundColorID);

      db.AddInParameter(dbCommand, "AddEditOption", DbType.Int16, AddEditOption);

      db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                      DataRowVersion.Default, returnValue);

      db.ExecuteNonQuery(dbCommand, transaction);
      returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

      UserID = returnValue;

      if (returnValue == -1)
      {
        return new TransactionResult(TransactionStatus.Failure, "Failure Updated");
      }
      else
      {
        return new TransactionResult(TransactionStatus.Success, "Successfully Updated");
      }
    }

    /// <summary>
    /// Gets the User Settings Details based on the UserID
    /// </summary>
    private void GetUserSettings(int userID)
    {
      try
      {
        Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
        string sqlCommand = "spGetUserSettings";
        DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
        db.AddInParameter(dbCommand, "UserID", DbType.Int32, UserID);
        DataSet ds = db.ExecuteDataSet(dbCommand);

        // Load Employee Info
        if (ds.Tables[0].Rows.Count > 0)
        {
          DataRow dRow = ds.Tables[0].Rows[0];

          UserSettingsID = Convert.ToInt32(dRow["UserSettingsID"]);
          DateFormatID = Convert.ToInt32(dRow["DateFormatID"]);
          BackgroundColorID = Convert.ToInt32(dRow["BackgroundColorID"]);
        }
      }
      catch (Exception ex)
      {
        ErrorLog.LogErrorMessageToDB("", "SettingsDL.cs", "GetUserSettings", ex.Message.ToString(), _myConnection);
      }
    }

    #endregion
  }
}
