using System;
using System.Data;
using System.Data.Common;
using PineForest.CommonLayer;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace PineForest.DataLayer
{
  public class UsersXPagesDL : CommonForAllDL
  {
    #region Properties

    public int UserID { get; set; }

    public string UserName { get; set; }

    public int CompanyID { get; set; }

    public string CompanyName { get; set; }

    public int PageID { get; set; }

    public string PageName { get; set; }

    public bool IsAddorEdit { get; set; }

    public bool IsDelete { get; set; }

    #endregion

    #region Constructors

    public UsersXPagesDL() { }

    public UsersXPagesDL(int userID, int companyID, int pageID, bool getAllProperties)
    {
      UserID = userID;
      CompanyID = companyID;
      PageID = pageID;
      if (getAllProperties)
      {
        GetUserPageRights();
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
              //Adding Or Editing UsersXPages
              result = AddEditUsersXPages(db, transaction);
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
            ErrorLog.LogErrorMessageToDB("", "UsersXPagesDL.cs", "Commit For Add", ex.Message.ToString(), _myConnection);
            return new TransactionResult(TransactionStatus.Failure, "Failure Adding");
          }
          if (ScreenMode == ScreenMode.Edit)
          {
            ErrorLog.LogErrorMessageToDB("", "UsersXPagesDL.cs", "Commit For Edit", ex.Message.ToString(), _myConnection);
            return new TransactionResult(TransactionStatus.Failure, "Failure Updating");
          }
          if (ScreenMode == ScreenMode.Delete)
          {
            ErrorLog.LogErrorMessageToDB("", "UsersXPagesDL.cs", "Commit For Delete", ex.Message.ToString(), _myConnection);
            return new TransactionResult(TransactionStatus.Failure, "Failure Deleting");
          }
        }
      }
      return null;
    }

    /// <summary>
    /// Gets the list of users - Changed sp name on 20/06/2014
    /// </summary>
    /// <param name="CompanyID"></param>
    /// <param name="UserID"></param>
    /// <returns>DataSet Containing the List of Users</returns>
    public DataSet GetUsersListByCompanyID(int companyID, int userID)
    {
      DataSet ds = new DataSet();
      try
      {
        Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
        DbCommand dbCommand = db.GetStoredProcCommand("UsersListByCompanyID_SELECT");//spGetUsersListByCompanyID
        dbCommand.Parameters.Clear();
        dbCommand.CommandTimeout = 300;
        db.AddInParameter(dbCommand, "CompanyID", DbType.Int32, companyID);
        db.AddInParameter(dbCommand, "UserID", DbType.Int32, userID);
        ds = db.ExecuteDataSet(dbCommand);
      }
      catch (Exception ex)
      {
        ErrorLog.LogErrorMessageToDB("", "UsersXPagesDL.cs", "GetUsersListByCompanyID", ex.Message.ToString(), _myConnection);
      }
      return ds;
    }

    /// <summary>
    /// Get UsersXPages List
    /// </summary>
    /// <param name="ACE">Instance of the ACE</param>
    /// <returns>Return the data as Dataset</returns>
    public DataSet GetUsersPagesList(int userID, int companyID)
    {
      DataSet ds = new DataSet();
      try
      {
        Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
        string sqlCommand = "spGetUsersXPages";
        DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
        db.AddInParameter(dbCommand, "UserID", DbType.Int32, userID);
        db.AddInParameter(dbCommand, "CompanyID", DbType.Int32, companyID);
        ds = db.ExecuteDataSet(dbCommand);
      }
      catch (Exception ex)
      {
        ErrorLog.LogErrorMessageToDB("", "UsersXPagesDL.cs", "GetUsersPagesList", ex.Message.ToString(), _myConnection);
      }
      return ds;
    }

    /// <summary>
    /// Add/Edit UsersXPages
    /// </summary>
    /// <param name="db"></param>
    /// <param name="transaction"></param>
    /// <returns></returns>
    public TransactionResult AddEditUsersXPages(Database db, DbTransaction transaction)
    {
      int returnValue = 0;
      string sqlCommand = "spAddEditUsersXPages";
      DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
      db.AddInParameter(dbCommand, "UserID", DbType.Int32, UserID);
      db.AddInParameter(dbCommand, "CompanyID", DbType.Int32, CompanyID);
      db.AddInParameter(dbCommand, "PageID", DbType.Int32, PageID);
      db.AddInParameter(dbCommand, "IsAddOrEdit", DbType.Boolean, IsAddorEdit);
      db.AddInParameter(dbCommand, "IsDelete", DbType.Boolean, IsDelete);

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
    /// Gets the Employee Details based on the EmployeeID
    /// </summary>
    private void GetUserPageRights()
    {
      try
      {
        Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
        string sqlCommand = "spGetUserPageRights";
        DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
        db.AddInParameter(dbCommand, "CompanyID", DbType.Int32, CompanyID);
        db.AddInParameter(dbCommand, "UserID", DbType.Int32, UserID);
        db.AddInParameter(dbCommand, "PageID", DbType.Int32, PageID);
        DataSet ds = db.ExecuteDataSet(dbCommand);

        // Load Employee Info
        if (ds.Tables[0].Rows.Count > 0)
        {
          DataRow dRow = ds.Tables[0].Rows[0];

          IsAddorEdit = Convert.ToBoolean(dRow["IsAddorEdit"]);
          IsDelete = Convert.ToBoolean(dRow["IsDelete"]);
        }
      }
      catch (Exception ex)
      {
        ErrorLog.LogErrorMessageToDB("", "UsersXPagesDL.cs", "GetUserPageRights", ex.Message.ToString(), _myConnection);
      }
    }

    #endregion
  }
}
