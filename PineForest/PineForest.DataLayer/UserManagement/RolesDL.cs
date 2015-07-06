using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using PineForest.CommonLayer;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace PineForest.DataLayer
{
  public class RolesDL : CommonForAllDL
  {
    #region Properties

    public int RoleID { get; set; }

    public string RoleName { get; set; }

    public List<RolesXPagesDL> RolePages { get; set; }

    #endregion

    #region Contructors

    public RolesDL()
    {
      RolePages = new List<RolesXPagesDL>();
    }

    public RolesDL(int roleID, bool getAllProperties)
    {
      RoleID = roleID;
      RolePages = new List<RolesXPagesDL>();
      if (getAllProperties)
      {
      }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Decides whether to Call Add/Edit/Delete method
    /// And Calls the appropriate method
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
              //Adding RolesXPages

              break;

            case ScreenMode.Edit:
              if (RolePages != null)
              {
                result = AddEditRolesXPages(db, transaction);
                if (result.Status == TransactionStatus.Failure)
                {
                  transaction.Rollback();
                  return result;
                }
              }
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
        }
      }
      return null;
    }

    /// <summary>
    /// To Add / Edit a Role
    /// </summary>
    /// <param name="db"></param>
    /// <param name="transaction"></param>
    /// <returns>TransactionResult - Success / Failure</returns>
    private TransactionResult AddEditRole(Database db, DbTransaction transaction)
    {
      int returnValue = 0;
      string sqlCommand = "spAddEditRole";
      DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

      db.AddInParameter(dbCommand, "RoleID", DbType.Int32, RoleID);
      db.AddInParameter(dbCommand, "RoleName", DbType.String, RoleName);

      db.AddInParameter(dbCommand, "AddEditOption", DbType.Int16, AddEditOption);

      db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                      DataRowVersion.Default, returnValue);

      db.ExecuteNonQuery(dbCommand, transaction);
      returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

      RoleID = returnValue;

      if (returnValue == -1)
      {
        if (AddEditOption == 1)
          return new TransactionResult(TransactionStatus.Failure, "Failure Updating");
        else
          return new TransactionResult(TransactionStatus.Failure, "Failure Adding");
      }
      else
      {
        if (AddEditOption == 1)
          return new TransactionResult(TransactionStatus.Success, "Successfully Updated");
        else
          return new TransactionResult(TransactionStatus.Success, "Successfully Added");
      }
    }

    /// <summary>
    /// Add / Edit RolesXPages
    /// </summary>
    /// <param name="db"></param>
    /// <param name="transaction"></param>
    /// <returns></returns>
    private TransactionResult AddEditRolesXPages(Database db, DbTransaction transaction)
    {
      TransactionResult tResult = null;
      bool isSuccessful = true;
      if (RolePages != null)
      {
        foreach (RolesXPagesDL rPage in RolePages)
        {
          rPage.AddEditOption = 0;
          tResult = rPage.AddEditRolesXPages(db, transaction);
          if (tResult.Status == TransactionStatus.Failure)
          {
            isSuccessful = false;
          }
        }
      }

      if (isSuccessful == true)
        tResult.Status = TransactionStatus.Success;
      else
        tResult.Status = TransactionStatus.Failure;

      return tResult;
    }

    /// <summary>
    /// Get Roles List
    /// </summary>
    /// <param name="ACE">Instance of the ACE</param>
    /// <returns>Return the data as Dataset</returns>
    public DataSet GetRolesList()
    {
      DataSet ds =new DataSet();
      try
      {
        Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
        string sqlCommand = "spGetRolesList";
        DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
        ds = db.ExecuteDataSet(dbCommand);
      }
      catch (Exception ex)
      {
        ErrorLog.LogErrorMessageToDB("", "RolesDL.cs", "GetRolesList", ex.Message.ToString(), _myConnection);
      }
      return ds;
    }

    /// <summary>
    /// Get Roles List
    /// </summary>
    /// <param name="ACE">Instance of the ACE</param>
    /// <returns>Return the data as Dataset</returns>
    public DataSet GetRolesListByLevel(int userID, int companyID)
    {
      DataSet ds =new DataSet();
      try
      {
        Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
        string sqlCommand = "spGetRolesListByLevel";
        DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
        db.AddInParameter(dbCommand, "UserID", DbType.Int32, userID);
        db.AddInParameter(dbCommand, "CompanyID", DbType.Int32, companyID);

        ds = db.ExecuteDataSet(dbCommand);
      }
      catch (Exception ex)
      {
        ErrorLog.LogErrorMessageToDB("", "RolesDL.cs", "GetRolesListByLevel", ex.Message.ToString(), _myConnection);
      }
      return ds;
    }

    #endregion
  }
}
