using System;
using System.Data;
using System.Data.Common;
using PineForest.CommonLayer;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace PineForest.DataLayer
{
  public class CompanyXUsersDL : CommonForAllDL
  {
    #region Properties

    public int CompanyID { get; set; }

    public string CompanyName { get; set; }

    public int UserID { get; set; }

    public int RoleID { get; set; }

    public string RoleName { get; set; }

    public bool IsDefault { get; set; }

    #endregion

    #region Methods

    /// <summary>
    /// Commit
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
              //Adding Or Editing CompanyXUsers
              result = AddEditCompanyXUsers(db, transaction);
              if (result.Status == TransactionStatus.Failure)
              {
                transaction.Rollback();
                return result;
              }
              break;
            case ScreenMode.Edit:
              break;
            case ScreenMode.Delete:
              result = DeleteCompanyXUsers(db, transaction);
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
            ErrorLog.LogErrorMessageToDB("", "CompanyXUsersDL.cs", "Commit For Add", ex.Message.ToString(), _myConnection);
            return new TransactionResult(TransactionStatus.Failure, "Failure Adding");
          }
          if (ScreenMode == ScreenMode.Edit)
          {
            ErrorLog.LogErrorMessageToDB("", "CompanyXUsersDL.cs", "Commit For Edit", ex.Message.ToString(), _myConnection);
            return new TransactionResult(TransactionStatus.Failure, "Failure Updating");
          }
          if (ScreenMode == ScreenMode.Delete)
          {
            ErrorLog.LogErrorMessageToDB("", "CompanyXUsersDL.cs", "Commit For Delete", ex.Message.ToString(), _myConnection);
            return new TransactionResult(TransactionStatus.Failure, "Failure Deleting");
          }
        }
      }
      return null;
    }

    /// <summary>
    /// Gets the list of Users by their company id
    /// </summary>
    /// <param name="companyID"></param>
    /// <returns>DataSet Containing the List of Users</returns>
    public DataSet GetUsersListByCompanyID(int companyID)
    {
      DataSet ds = new DataSet();
      try
      {
        Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
        DbCommand dbCommand = db.GetStoredProcCommand("spGetUsersListByCompanyID");
        dbCommand.Parameters.Clear();
        dbCommand.CommandTimeout = 300;
        db.AddInParameter(dbCommand, "CompanyID", DbType.Int32, companyID);
        ds = db.ExecuteDataSet(dbCommand);
      }
      catch (Exception ex)
      {
        ErrorLog.LogErrorMessageToDB("", "CompanyXUsersDL.cs", "GetUsersListByCompanyID", ex.Message.ToString(), _myConnection);
      }
      return ds;
    }

    /// <summary>
    /// Add Edit CompanyXUsers - Formatted sp and changed the sp name on 20/06/2014
    /// </summary>
    /// <param name="db"></param>
    /// <param name="transaction"></param>
    /// <returns></returns>
    public TransactionResult AddEditCompanyXUsers(Database db, DbTransaction transaction)
    {
      int returnValue = 0;
      string sqlCommand = "spAddEditCompanyXUsers";//spAddEditCompanyXUsers
      DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
      db.AddInParameter(dbCommand, "CompanyID", DbType.Int32, CompanyID);
      db.AddInParameter(dbCommand, "UserID", DbType.Int32, UserID);
      db.AddInParameter(dbCommand, "RoleID", DbType.Int32, RoleID);
      db.AddInParameter(dbCommand, "IsDefault", DbType.Boolean, IsDefault);
      db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                      DataRowVersion.Default, returnValue);
      db.AddInParameter(dbCommand, "AddEditOption", DbType.Int16, AddEditOption);

      db.ExecuteNonQuery(dbCommand, transaction);
      returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

      if (returnValue == -1)
        return new TransactionResult(TransactionStatus.Failure, "Failure Adding User Company");
      else
      {
        if (AddEditOption == 1)
          return new TransactionResult(TransactionStatus.Success, "Successfully Updated");
        else
          return new TransactionResult(TransactionStatus.Success, "Successfully Added");
      }
    }

    /// <summary>
    /// To Delete a CompanyXUsers - Formatted sp and changed the sp name on 20/06/2014
    /// </summary>
    /// <param name="db"></param>
    /// <param name="transaction"></param>
    /// <returns>TransactionResult - Success / Failure</returns>
    private TransactionResult DeleteCompanyXUsers(Database db, DbTransaction transaction)
    {
      int returnValue = 0;
      DbCommand dbCommand = db.GetStoredProcCommand("spDeleteCompanyXUsers");//spDeleteCompanyXUsers
      db.AddInParameter(dbCommand, "CompanyID", DbType.Int32, CompanyID);
      db.AddInParameter(dbCommand, "UserID", DbType.Int32, UserID);
      db.AddInParameter(dbCommand, "AddEditOption", DbType.Int16, AddEditOption);

      db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                      DataRowVersion.Default, returnValue);

      db.ExecuteNonQuery(dbCommand, transaction);
      returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

      if (returnValue == -1)
        return new TransactionResult(TransactionStatus.Failure, "Failure Deleted");
      else
        return new TransactionResult(TransactionStatus.Success, "Successfully Deleted");
    }

    #endregion
  }
}
