using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;
using PineForest.CommonLayer;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace PineForest.DataLayer
{
  public class UsersDL : CommonForAllDL
  {
    #region Properties

    public int UserID { get; set; }

    public int UserName { get; set; }

    public string Password { get; set; }

    public string OldPassword { get; set; }

    public int EmployeeID { get; set; }

    public int CompanyID { get; set; }

    public int RoleID { get; set; }

    public string CompanyName { get; set; }

    public string EmployeeName { get; set; }

    public string SpouseName { get; set; }

    public string RoleName { get; set; }

    public int DepartmentID { get; set; }

    public string DepartmentName { get; set; }

    public string DateFormat { get; set; }

    public Nullable<DateTime> EmployeeDOB { get; set; }

    public Nullable<DateTime> EmployeeWeddingDate { get; set; }

    public bool IsValid { get; set; }

    public bool IsPasswordChanged { get; set; }

    public int AuditUserID { get; set; }

    public Nullable<DateTime> AuditDate { get; set; }

    public List<CompanyXUsersDL> UserCompanies { get; set; }

    public List<UsersXPagesDL> UserPages { get; set; }

    #endregion

    #region Constructors

    public UsersDL()
    {
      UserCompanies = new List<CompanyXUsersDL>();
      UserPages = new List<UsersXPagesDL>();
    }

    public UsersDL(int userID, bool getAllProperties)
    {
      UserID = userID;
      UserCompanies = new List<CompanyXUsersDL>();
      UserPages = new List<UsersXPagesDL>();
      if (getAllProperties)
      {
        GetUser();
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
              //Adding Or Editing User
              result = AddEditUser(db, transaction);
              if (result.Status == TransactionStatus.Failure)
              {
                transaction.Rollback();
                return result;
              }
              if (UserCompanies != null && UserCompanies.Count != 0)
              {
                result = AddCompanyXUsers(db, transaction);
                if (result.Status == TransactionStatus.Failure)
                {
                  transaction.Rollback();
                  return result;
                }
              }
              break;
            case ScreenMode.Edit:
              if (UserPages != null)
              {
                result = AddEditUsersXPages(db, transaction);
                if (result.Status == TransactionStatus.Failure)
                {
                  transaction.Rollback();
                  return result;
                }
              }
              break;
            case ScreenMode.Delete:
              result = DeleteUser(db, transaction);
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
            ErrorLog.LogErrorMessageToDB("", "UsersDL.cs", "Commit For Add", ex.Message.ToString(), _myConnection);
            return new TransactionResult(TransactionStatus.Failure, "Failure Adding");
          }
          if (ScreenMode == ScreenMode.Edit)
          {
            ErrorLog.LogErrorMessageToDB("", "UsersDL.cs", "Commit For Edit", ex.Message.ToString(), _myConnection);
            return new TransactionResult(TransactionStatus.Failure, "Failure Updating");
          }
          if (ScreenMode == ScreenMode.Delete)
          {
            ErrorLog.LogErrorMessageToDB("", "UsersDL.cs", "Commit For Delete", ex.Message.ToString(), _myConnection);
            return new TransactionResult(TransactionStatus.Failure, "Failure Deleting");
          }
        }
      }
      return null;
    }

    /// <summary>
    /// Get Login
    /// </summary>
    /// <returns></returns>
    public bool GetLogin()
    {
      try
      {
        bool _isSuccess = false;
        Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
        string sqlCommand = "spGetLogin";
        DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
        db.AddInParameter(dbCommand, "UserName", DbType.String, UserName);
        db.AddInParameter(dbCommand, "Password", DbType.String, Password);

        using (SqlDataReader dataReader = (SqlDataReader)db.ExecuteReader(dbCommand))
        {
          while (dataReader.Read())
          {
            _isSuccess = true;
            EmployeeID = dataReader.GetInt32(dataReader.GetOrdinal("EmployeeID"));
            UserName = dataReader.GetInt32(dataReader.GetOrdinal("UserName"));
            UserID = dataReader.GetInt32(dataReader.GetOrdinal("UserID"));
            CompanyID = dataReader.GetInt32(dataReader.GetOrdinal("CompanyID"));
            CompanyName = dataReader.GetString(dataReader.GetOrdinal("CompanyName"));
            EmployeeName = dataReader.GetString(dataReader.GetOrdinal("FName"));
            EmployeeDOB = dataReader.GetDateTime(dataReader.GetOrdinal("DOB"));
            EmployeeWeddingDate = dataReader.GetDateTime(dataReader.GetOrdinal("WeddingDate"));
            SpouseName = dataReader.GetString(dataReader.GetOrdinal("SpouseName"));
            DateFormat = dataReader.GetString(dataReader.GetOrdinal("DateFormatValue"));
            RoleName = dataReader.GetString(dataReader.GetOrdinal("RoleDescription"));
            DepartmentID = dataReader.GetInt32(dataReader.GetOrdinal("DepartmentID"));
            DepartmentName = dataReader.GetString(dataReader.GetOrdinal("Department"));
            IsPasswordChanged = dataReader.GetBoolean(dataReader.GetOrdinal("IsPasswordChanged"));
          }
        }
        return _isSuccess;
      }
      catch (Exception ex)
      {
        ErrorLog.LogErrorMessageToDB("UserDl.cs", "", "GetLogin", ex.Message, new PineConnection());
        return false;
      }
    }

    /// <summary>
    /// Change Password 
    /// </summary>
    /// <returns></returns>
    public bool ChangePassword()
    {
      bool _bolCP = false;
      Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
      DbCommand dbCommand = db.GetStoredProcCommand("spUpdateUserPassword");
      db.AddInParameter(dbCommand, "UserName", DbType.String, UserName);
      db.AddInParameter(dbCommand, "OldPassword", DbType.String, OldPassword);
      db.AddInParameter(dbCommand, "NewPassword", DbType.String, Password);

      _bolCP = Convert.ToBoolean(db.ExecuteScalar(dbCommand));

      return _bolCP;
    }

    /// <summary>
    /// Get User Role
    /// </summary>
    /// <param name="UserID"></param>
    /// <param name="CompanyID"></param>
    public void GetUserRole(int UserID, int CompanyID)
    {
      try
      {
        Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
        string sqlCommand = "spGetUserRole";
        DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
        db.AddInParameter(dbCommand, "UserID", DbType.String, UserID);
        db.AddInParameter(dbCommand, "CompanyID", DbType.String, CompanyID);

        using (SqlDataReader dataReader = (SqlDataReader)db.ExecuteReader(dbCommand))
        {
          if (dataReader.HasRows)
          {
            dataReader.Read();
            RoleID = dataReader.GetInt32(dataReader.GetOrdinal("RoleID"));
            RoleName = dataReader.GetString(dataReader.GetOrdinal("RoleName"));
          }
        }
      }
      catch (Exception ex)
      {
        ErrorLog.LogErrorMessageToDB("", "UsersDL.cs", "GetUserRole", ex.Message.ToString(), _myConnection);
      }
    }

    /// <summary>
    /// Get User Details
    /// </summary>
    /// <param name="userName"></param>
    /// <returns></returns>
    public DataSet GetUserDetails(string userName)
    {
      DataSet ds = new DataSet();
      try
      {
        Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
        string sqlCommand = "spGetUserDetailsByUserName";
        DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
        db.AddInParameter(dbCommand, "Username", DbType.Int32, userName);
        ds = db.ExecuteDataSet(dbCommand);
        return ds;
      }
      catch (Exception ex)
      {
        ErrorLog.LogErrorMessageToDB("", "UsersDL.cs", "GetUserDetails", ex.Message.ToString(), _myConnection);
        return ds;
      }
    }

    /// <summary>
    /// Gets the list of users that match the specified search text (in any of the selected fields)
    /// </summary>
    /// <param name="userID"></param>
    /// <param name="searchText"></param>
    /// <returns>DataSet Containing the List of Users</returns>
    public DataSet GetUserDetails(int userID, string searchText)
    {
      DataSet ds = new DataSet();
      try
      {
        Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
        DbCommand dbCommand = db.GetStoredProcCommand("spGetUser");
        dbCommand.Parameters.Clear();
        dbCommand.CommandTimeout = 300;
        db.AddInParameter(dbCommand, "UserID", DbType.Int32, userID);
        db.AddInParameter(dbCommand, "SearchText", DbType.String, searchText);
        ds = db.ExecuteDataSet(dbCommand);
      }
      catch (Exception ex)
      {
        ErrorLog.LogErrorMessageToDB("", "UsersDL.cs", "GetUserDetails", ex.Message.ToString(), _myConnection);
      }
      return ds;
    }

    /// <summary>
    /// Gets the list of users that match the specified search text (in any of the selected fields) By CompanyID
    /// </summary>
    /// <param name="companyID"></param>
    /// <param name="searchText"></param>
    /// <returns>DataSet Containing the List of Users By CompanyID</returns>
    public DataSet GetUserListByCompanyID(int companyID, string searchText, bool activatedDeactivated)
    {
      DataSet ds = new DataSet();
      try
      {
        Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
        DbCommand dbCommand = db.GetStoredProcCommand("spGetUserListByCompanyID");
        dbCommand.Parameters.Clear();
        dbCommand.CommandTimeout = 300;
        db.AddInParameter(dbCommand, "CompanyID", DbType.Int32, companyID);
        db.AddInParameter(dbCommand, "SearchText", DbType.String, searchText);
        db.AddInParameter(dbCommand, "ActivatedDeactivated", DbType.Boolean, activatedDeactivated);
        ds = db.ExecuteDataSet(dbCommand);
      }
      catch (Exception ex)
      {
        ErrorLog.LogErrorMessageToDB("", "UsersDL.cs", "GetUserListByCompanyID", ex.Message.ToString(), _myConnection);
      }
      return ds;
    }

    /// <summary>
    /// Reset the User Password
    /// </summary>
    /// <param name="userID"></param>        
    /// <param name="password"></param>
    /// <returns></returns>
    public TransactionResult UserResetPassword(int userID, string password)
    {
      int returnValue = 0;

      Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
      DbCommand dbCommand = db.GetStoredProcCommand("spUserResetPassword");
      dbCommand.Parameters.Clear();
      dbCommand.CommandTimeout = 300;
      db.AddInParameter(dbCommand, "UserID", DbType.Int32, userID);
      db.AddInParameter(dbCommand, "Password", DbType.String, password);
      db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                      DataRowVersion.Default, returnValue);

      db.ExecuteNonQuery(dbCommand);
      returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

      if (returnValue == -1)
        return new TransactionResult(TransactionStatus.Failure, "Failure Resetting the Password");
      else
        return new TransactionResult(TransactionStatus.Success, "Successfully Reset the Password");
    }

    /// <summary>
    /// User Forgot Password
    /// </summary>
    /// <param name="userID"></param>
    /// <param name="reGeneratePassword"></param>
    /// <returns></returns>
    public TransactionResult UserForgotPassword(int userID, string reGeneratePassword)
    {
      int returnValue = 0;

      Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
      DbCommand dbCommand = db.GetStoredProcCommand("spUpdateUserForgotPassword");
      dbCommand.Parameters.Clear();
      dbCommand.CommandTimeout = 300;
      db.AddInParameter(dbCommand, "UserID", DbType.Int32, userID);
      db.AddInParameter(dbCommand, "Password", DbType.String, reGeneratePassword);
      db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                      DataRowVersion.Default, returnValue);

      db.ExecuteNonQuery(dbCommand);

      returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

      if (returnValue == -1)
        return new TransactionResult(TransactionStatus.Failure, "Failure");
      else
        return new TransactionResult(TransactionStatus.Success, "Successfully");
    }

    /// <summary>
    /// Update Last Login Date
    /// </summary>
    /// <param name="userID"></param>
    /// <returns></returns>
    public TransactionResult UpdateLastLoginDate(int userID)
    {
      try
      {
        int returnValue = 0;

        Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
        DbCommand dbCommand = db.GetStoredProcCommand("spUpdateLastLoginDate");
        dbCommand.Parameters.Clear();
        dbCommand.CommandTimeout = 300;
        db.AddInParameter(dbCommand, "UserID", DbType.Int32, userID);
        db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                        DataRowVersion.Default, returnValue);

        db.ExecuteNonQuery(dbCommand);
        returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

        if (returnValue == -1)
          return new TransactionResult(TransactionStatus.Failure, "Failure Updating Last Login Date");
        else
          return new TransactionResult(TransactionStatus.Success, "Successfully Updated the Last Login Date");
      }
      catch (Exception ex)
      {
        ErrorLog.LogErrorMessageToDB("UserDL.cs", "", "UpdateLastLoginDate", ex.Message, new PineConnection());
        return new TransactionResult(TransactionStatus.Failure, "Failure Updating");
      }
    }

    /// <summary>
    /// Get User Details
    /// </summary>
    /// <param name="employeeID"></param>
    private void GetUserDetails(int employeeID)
    {
      try
      {
        Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
        string sqlCommand = "spGetUserDetail";
        DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
        db.AddInParameter(dbCommand, "EmployeeID", DbType.String, employeeID);

        using (SqlDataReader dataReader = (SqlDataReader)db.ExecuteReader(dbCommand))
        {
          if (dataReader.HasRows)
          {
            dataReader.Read();
            UserID = dataReader.GetInt32(dataReader.GetOrdinal("UserID"));
            UserName = dataReader.GetInt32(dataReader.GetOrdinal("UserName"));
            Password = dataReader.GetString(dataReader.GetOrdinal("Password"));
            IsValid = dataReader.GetBoolean(dataReader.GetOrdinal("IsValid"));
          }
        }
      }
      catch (Exception ex)
      {
        ErrorLog.LogErrorMessageToDB("", "UsersDL.cs", "GetUserDetails", ex.Message.ToString(), _myConnection);
      }
    }

    /// <summary>
    /// Gets the User Details based on the UserID
    /// </summary>
    private void GetUser()
    {
      try
      {
        Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
        string sqlCommand = "spGetUser";
        DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
        db.AddInParameter(dbCommand, "UserID", DbType.Int32, UserID);
        DataSet ds = db.ExecuteDataSet(dbCommand);

        // Load Company Info
        if (ds.Tables[0].Rows.Count > 0)
        {
          DataRow dRow = ds.Tables[0].Rows[0];
          UserName = Common.CheckIntNull(dRow["UserName"]);
          Password = Common.CheckNull(dRow["Password"]);
          EmployeeID = Common.CheckIntNull(dRow["EmployeeID"]);
          IsValid = Convert.ToBoolean(dRow["IsValid"]);
          AuditUserID = Common.CheckIntNull(dRow["AuditUserID"]);
          if (dRow["AuditDate"] != DBNull.Value)
            AuditDate = Convert.ToDateTime(dRow["AuditDate"]);
          else
            AuditDate = null;
        }

        // Load User Companies
        foreach (DataRow dRow in ds.Tables[1].Rows)
        {
          CompanyXUsersDL uCompany = new CompanyXUsersDL();
          uCompany.CompanyID = Common.CheckIntNull(dRow["CompanyID"]);
          uCompany.CompanyName = Common.CheckNull(dRow["CompanyName"]);
          uCompany.UserID = Common.CheckIntNull(dRow["UserID"]);
          uCompany.RoleID = Common.CheckIntNull(dRow["RoleID"]);
          uCompany.RoleName = Common.CheckNull(dRow["RoleName"]);
          if (dRow["IsDefault"] != DBNull.Value)
            uCompany.IsDefault = Convert.ToBoolean(dRow["IsDefault"]);
          else
            uCompany.IsDefault = false;

          UserCompanies.Add(uCompany);
        }
      }
      catch (Exception ex)
      {
        ErrorLog.LogErrorMessageToDB("", "UsersDL.cs", "GetUser", ex.Message.ToString(), _myConnection);
      }
    }

    /// <summary>
    /// To Add / Edit a User
    /// </summary>
    /// <param name="db"></param>
    /// <param name="transaction"></param>
    /// <returns>TransactionResult - Success / Failure</returns>
    internal TransactionResult AddEditUser(Database db, DbTransaction transaction)
    {
      try
      {
        int returnValue = 0;
        string sqlCommand = "spAddEditUser";
        DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

        db.AddInParameter(dbCommand, "UserID", DbType.Int32, UserID);
        db.AddInParameter(dbCommand, "UserName", DbType.Int32, UserName);
        db.AddInParameter(dbCommand, "Password", DbType.String, Password);
        db.AddInParameter(dbCommand, "EmployeeID", DbType.String, EmployeeID);
        db.AddInParameter(dbCommand, "IsValid", DbType.Boolean, IsValid);
        if (AuditUserID != 0)
        {
          db.AddInParameter(dbCommand, "AuditUserID", DbType.String, AuditUserID);
        }
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
      catch (Exception ex)
      {
        ErrorLog.LogErrorMessageToDB("UserDL.cs", "", "AddEditUser", ex.Message, new PineConnection());
        return new TransactionResult(TransactionStatus.Failure, "Failure Updating");
      }
    }

    /// <summary>
    /// To Add the User Companies
    /// </summary>
    /// <param name="db"></param>
    /// <param name="transaction"></param>
    /// <returns></returns>
    internal TransactionResult AddCompanyXUsers(Database db, DbTransaction transaction)
    {
      try
      {
        TransactionResult tResult = null;
        bool isSuccessful = true;
        if (UserCompanies != null)
        {
          foreach (CompanyXUsersDL uCompany in UserCompanies)
          {
            uCompany.UserID = UserID;
            uCompany.AddEditOption = 0;
            tResult = uCompany.AddEditCompanyXUsers(db, transaction);
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
      catch (Exception ex)
      {
        ErrorLog.LogErrorMessageToDB("UserDL.cs", "", "AddCompanyXUsers", ex.Message, new PineConnection());
        return new TransactionResult(TransactionStatus.Failure, "Failure Updating");
      }
    }

    /// <summary>
    /// To AddEdit the User X Pages
    /// </summary>
    /// <param name="db"></param>
    /// <param name="transaction"></param>
    /// <returns></returns>
    private TransactionResult AddEditUsersXPages(Database db, DbTransaction transaction)
    {
      try
      {
        TransactionResult tResult = null;
        bool isSuccessful = true;
        if (UserCompanies != null)
        {
          foreach (UsersXPagesDL uPages in UserPages)
          {
            uPages.AddEditOption = 0;
            tResult = uPages.AddEditUsersXPages(db, transaction);
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
      catch (Exception ex)
      {
        ErrorLog.LogErrorMessageToDB("UserDL.cs", "", "AddEditUsersXPages", ex.Message, new PineConnection());
        return new TransactionResult(TransactionStatus.Failure, "Failure Updating");
      }
    }

    /// <summary>
    /// To Delete a User
    /// </summary>
    /// <param name="db"></param>
    /// <param name="transaction"></param>
    /// <returns>TransactionResult - Success / Failure</returns>
    private TransactionResult DeleteUser(Database db, DbTransaction transaction)
    {
      int returnValue = 0;
      DbCommand dbCommand = db.GetStoredProcCommand("spDeleteUser");
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
    /// GetGUIDForMobileApp
    /// </summary>
    /// <param name="UserID"></param>
    /// <param name="CompanyID"></param>
    public string GetGUIDForMobileApp()
    {
      string _GUID =string.Empty;
      try
      {
        Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
        string sqlCommand = "spCheckAuthenticationForMobileApp";
        DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
        _GUID = Convert.ToString(db.ExecuteScalar(dbCommand));
        return _GUID;
      }
      catch (Exception ex)
      {
        ErrorLog.LogErrorMessageToDB("", "UsersDL.cs", "GetGUIDForMobileApp", ex.Message.ToString(), _myConnection);
      }
      return _GUID;
    }

    /// <summary>
    /// GetUserIDByEmpIDForMobileApplication
    /// </summary>
    /// <param name="UserName"></param>
    /// <returns></returns>
    public string GetUserIDByEmpIDForMobileApplication(string UserName)
    {
      string _userID = string.Empty;
      try
      {
        Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);

        string sqlCommand = "sp_GetUserIDByUserNameForMobile";
        DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
        db.AddInParameter(dbCommand, "UserName", DbType.Int32, UserName);
        _userID = Convert.ToString(db.ExecuteScalar(dbCommand));
        return _userID;
      }
      catch (Exception ex)
      {
        ErrorLog.LogErrorMessageToDB("", "UsersDL.cs", "GetUserIDByEmpIDForMobileApplication", ex.Message.ToString(), _myConnection);
      }
      return _userID;
    }

    #endregion
  }
}
