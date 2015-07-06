using System;
using System.Data;
using System.Data.Common;
using PineForest.CommonLayer;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace PineForest.DataLayer
{
  public class RolesXPagesDL : CommonForAllDL
  {
    #region Properties

    public int RoleID { get; set; }

    public int PageID { get; set; }

    public string RoleName { get; set; }

    public string PageName { get; set; }

    public bool IsAddorEdit { get; set; }

    public bool IsDelete { get; set; }

    #endregion

    #region Constructors

    public RolesXPagesDL() { }

    public RolesXPagesDL(int roleID, bool getAllProperties)
    {
      RoleID = roleID;
      if (getAllProperties)
      {
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
              //Adding Or Editing RolesXPages
              result = AddEditRolesXPages(db, transaction);
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
            ErrorLog.LogErrorMessageToDB("", "RolesXPagesDL.cs", "Commit For Add", ex.Message.ToString(), _myConnection);
            return new TransactionResult(TransactionStatus.Failure, "Failure Adding");
          }
          if (ScreenMode == ScreenMode.Edit)
          {
            ErrorLog.LogErrorMessageToDB("", "RolesXPagesDL.cs", "Commit For Edit", ex.Message.ToString(), _myConnection);
            return new TransactionResult(TransactionStatus.Failure, "Failure Updating");
          }
          if (ScreenMode == ScreenMode.Delete)
          {
            ErrorLog.LogErrorMessageToDB("", "RolesXPagesDL.cs", "Commit For Delete", ex.Message.ToString(), _myConnection);
            return new TransactionResult(TransactionStatus.Failure, "Failure Deleting");
          }
        }
      }
      return null;
    }

    /// <summary>
    /// Get RolesPages List
    /// </summary>
    /// <param name="ACE">Instance of the ACE</param>
    /// <returns>Return the data as Dataset</returns>
    public DataSet GetRolesPagesList(int roleID)
    {
      DataSet ds = new DataSet();
      try
      {
        Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
        string sqlCommand = "spGetRolesPagesList";
        DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
        db.AddInParameter(dbCommand, "RoleID", DbType.Int32, roleID);
        ds = db.ExecuteDataSet(dbCommand);
      }
      catch (Exception ex)
      {
        ErrorLog.LogErrorMessageToDB("", "RolesXPagesDL.cs", "GetRolesPagesList", ex.Message.ToString(), _myConnection);
      }
      return ds;
    }

    /// <summary>
    /// Get RolesPages List
    /// </summary>
    /// <param name="ACE">Instance of the ACE</param>
    /// <returns>Return the data as Dataset</returns>
    public DataSet GetRolesPagesListByModules(int roleID, string moduleName)
    {
      DataSet ds = new DataSet();
      try
      {
        Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
        string sqlCommand = "spGetRolesPagesListByModules";
        DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
        db.AddInParameter(dbCommand, "RoleID", DbType.Int32, roleID);
        db.AddInParameter(dbCommand, "ModuleName", DbType.String, moduleName);
        ds = db.ExecuteDataSet(dbCommand);
      }
      catch (Exception ex)
      {
        ErrorLog.LogErrorMessageToDB("", "RolesXPagesDL.cs", "GetRolesPagesListByModules", ex.Message.ToString(), _myConnection);
      }
      return ds;
    }

    /// <summary>
    /// Add / Edit RolesXPages
    /// </summary>
    /// <param name="db"></param>
    /// <param name="transaction"></param>
    /// <returns></returns>
    public TransactionResult AddEditRolesXPages(Database db, DbTransaction transaction)
    {
      int returnValue = 0;
      string sqlCommand = "spAddEditRolesXPages";
      DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

      db.AddInParameter(dbCommand, "RoleID", DbType.Int32, RoleID);
      db.AddInParameter(dbCommand, "PageID", DbType.Int32, PageID);
      db.AddInParameter(dbCommand, "IsAddOrEdit", DbType.Boolean, IsAddorEdit);
      db.AddInParameter(dbCommand, "IsDelete", DbType.Boolean, IsDelete);

      db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                      DataRowVersion.Default, returnValue);

      db.ExecuteNonQuery(dbCommand, transaction);
      returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

      RoleID = returnValue;

      if (returnValue == -1)
      {
        return new TransactionResult(TransactionStatus.Failure, "Failure Updated");
      }
      else
      {
        return new TransactionResult(TransactionStatus.Success, "Successfully Updated");
      }
    }

    #endregion
  }
}
