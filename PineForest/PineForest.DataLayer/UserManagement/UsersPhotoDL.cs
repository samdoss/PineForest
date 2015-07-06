using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using PineForest.CommonLayer;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace PineForest.DataLayer
{
  public class UsersPhotoDL : CommonForAllDL
  {
    #region Properties

    public int UserID { get; set; }

    public int UserPhotoID { get; set; }

    public string UserName { get; set; }

    public string Photo { get; set; }

    #endregion

    #region Constructors

    public UsersPhotoDL()
    {
    }

    public UsersPhotoDL(int userID, bool getAllProperties)
    {
      UserID = userID;
      if (getAllProperties)
      {
        GetUserPhoto();
      }
    }

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
              //Adding Or Editing User Photo
              result = AddEditUserPhoto(db, transaction);
              if (result.Status == TransactionStatus.Failure)
              {
                transaction.Rollback();
                return result;
              }
              break;
            case ScreenMode.Edit:
              break;
            case ScreenMode.Delete:
              result = DeleteUserPhoto(db, transaction);
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
            ErrorLog.LogErrorMessageToDB("", "UsersPhotoDL.cs", "Commit For Add", ex.Message.ToString(), _myConnection);
            System.Web.HttpContext.Current.Response.Redirect("~/OrderErrorPage.aspx");
            return new TransactionResult(TransactionStatus.Failure, "Failure Adding");
          }
          if (ScreenMode == ScreenMode.Edit)
          {
            ErrorLog.LogErrorMessageToDB("", "UsersPhotoDL.cs", "Commit For Edit", ex.Message.ToString(), _myConnection);
            System.Web.HttpContext.Current.Response.Redirect("~/OrderErrorPage.aspx");
            return new TransactionResult(TransactionStatus.Failure, "Failure Updating");
          }
          if (ScreenMode == ScreenMode.Delete)
          {
            ErrorLog.LogErrorMessageToDB("", "UsersPhotoDL.cs", "Commit For Delete", ex.Message.ToString(), _myConnection);
            System.Web.HttpContext.Current.Response.Redirect("~/OrderErrorPage.aspx");
            return new TransactionResult(TransactionStatus.Failure, "Failure Deleting");
          }
        }
      }
      return null;
    }

    /// <summary>
    /// Get User Photo
    /// </summary>
    public void GetUserPhoto()
    {
      try
      {
        Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
        string sqlCommand = "spGetUserPhoto";
        DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
        db.AddInParameter(dbCommand, "UserID", DbType.Int32, UserID);

        using (SqlDataReader dataReader = (SqlDataReader)db.ExecuteReader(dbCommand))
        {
          if (dataReader.HasRows)
          {
            dataReader.Read();
            UserPhotoID = dataReader.GetInt32(dataReader.GetOrdinal("UserPhotoID"));
            Photo = dataReader.GetString(dataReader.GetOrdinal("Photo"));
          }
        }
      }
      catch (Exception ex)
      {
        ErrorLog.LogErrorMessageToDB("", "UsersDL.cs", "GetUserRole", ex.Message.ToString(), _myConnection);
      }
    }

    /// <summary>
    /// To Delete a DeleteUserPhoto
    /// </summary>
    /// <param name="db"></param>
    /// <param name="transaction"></param>
    /// <returns>TransactionResult - Success / Failure</returns>
    private TransactionResult DeleteUserPhoto(Database db, DbTransaction transaction)
    {
      int returnValue = 0;
      DbCommand dbCommand = db.GetStoredProcCommand("spDeleteUserPhoto");
      db.AddInParameter(dbCommand, "UserID", DbType.Int32, UserID);
      db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                      DataRowVersion.Default, returnValue);

      db.ExecuteNonQuery(dbCommand, transaction);
      returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

      if (returnValue == -1)
        return new TransactionResult(TransactionStatus.Failure, "Failure Deleted");
      else
        return new TransactionResult(TransactionStatus.Success, "Successfully Deleted");
    }

    /// <summary>
    /// To Add / Edit a User Photo
    /// </summary>
    /// <param name="db"></param>
    /// <param name="transaction"></param>
    /// <returns>TransactionResult - Success / Failure</returns>
    internal TransactionResult AddEditUserPhoto(Database db, DbTransaction transaction)
    {
      int returnValue = 0;
      string sqlCommand = "spAddEditUserPhoto";
      DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
      db.AddInParameter(dbCommand, "UserPhotoID", DbType.Int32, UserPhotoID);
      db.AddInParameter(dbCommand, "UserID", DbType.Int32, UserID);
      db.AddInParameter(dbCommand, "Photo", DbType.String, Photo);
      db.AddInParameter(dbCommand, "AddEditOption", DbType.Int16, AddEditOption);

      db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                      DataRowVersion.Default, returnValue);

      db.ExecuteNonQuery(dbCommand, transaction);
      returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

      UserID = returnValue;

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
    /// Get User Photo
    /// </summary>
    public void GetUserPhotoForMobile(int UserID)
    {
      try
      {
        Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
        string sqlCommand = "spGetUserPhotoForMobile";
        DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
        db.AddInParameter(dbCommand, "UserName", DbType.Int32, UserID);

        using (SqlDataReader dataReader = (SqlDataReader)db.ExecuteReader(dbCommand))
        {
          if (dataReader.HasRows)
          {
            dataReader.Read();
            UserPhotoID = dataReader.GetInt32(dataReader.GetOrdinal("UserPhotoID"));
            Photo = dataReader.GetString(dataReader.GetOrdinal("Photo"));
          }
        }
      }
      catch (Exception ex)
      {
        ErrorLog.LogErrorMessageToDB("", "UsersDL.cs", "GetUserPhotoForMobile", ex.Message.ToString(), _myConnection);
        System.Web.HttpContext.Current.Response.Redirect("~/OrderErrorPage.aspx");
      }
    }

    #endregion
  }
}
