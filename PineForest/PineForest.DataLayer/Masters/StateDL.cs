using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;
using PineForest.CommonLayer;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace PineForest.DataLayer
{
  public class StateDL : CommonForAllDL
  {
    #region Properties

    public int StateID { get; set; }

    public string StateName { get; set; }

    public int CountryID { get; set; }

    public string CountryName { get; set; }

    public List<CityDL> Cities { get; set; }

    public List<DistrictDL> Districts { get; set; }

    #endregion

    #region Constructors

    public StateDL()
    {
      Cities = new List<CityDL>();
      Districts = new List<DistrictDL>();
    }

   public StateDL(int stateID, bool getAllProperties)
    {
      StateID = stateID;
      Cities = new List<CityDL>();
      Districts = new List<DistrictDL>();
      if (getAllProperties)
      {
        GetState();
      }
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Get State List By CountryID
    /// </summary>
    /// <param name="PineConnection">Instance of the PineConnection Class</param>
    /// <returns>Return the data as Dataset</returns>
    public DataSet GetStateListByCountryID(int CountryID)
    {
      DataSet ds = new DataSet();
      try
      {
        Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
        string sqlCommand = "spGetStateListByCountryID";
        DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
        db.AddInParameter(dbCommand, "CountryID", DbType.Int32, CountryID);
        ds = db.ExecuteDataSet(dbCommand);
      }
      catch (Exception ex)
      {
        ErrorLog.LogErrorMessageToDB("", "StateDL.cs", "GetStateListByCountryID", ex.Message.ToString(), _myConnection);
      }
      return ds;
    }

    /// <summary>
    /// GetStateID
    /// </summary>
    /// <param name="countryID"></param>
    /// <param name="stateName"></param>
    /// <returns></returns>
    public int GetStateID(int countryID, string stateName)
    {
      int stateID = 0;
      try
      {
        Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
        string sqlCommand = "spGetStateID";
        DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
        db.AddInParameter(dbCommand, "CountryID", DbType.Int32, countryID);
        db.AddInParameter(dbCommand, "StateName", DbType.String, stateName);
        using (SqlDataReader dataReader = (SqlDataReader)db.ExecuteReader(dbCommand))
        {
          if (dataReader.HasRows)
          {
            while (dataReader.Read())
            {
              stateID = Common.CheckIntNull(dataReader.GetInt32(dataReader.GetOrdinal("StateID")));
            }
          }
        }
      }
      catch (Exception ex)
      {
        ErrorLog.LogErrorMessageToDB("", "StateDL.cs", "GetStateID", ex.Message.ToString(), _myConnection);
      }
      return stateID;
    }

    /// <summary>
    /// Commit
    /// </summary>
    /// <returns></returns>
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
              result = AddEditState(db, transaction);
              if (result.Status == TransactionStatus.Failure)
              {
                transaction.Rollback();
                return result;
              }
              break;
            case ScreenMode.View:
              result = new TransactionResult(TransactionStatus.Success);
              break;
            case ScreenMode.Delete:
              result = DeleteState(db, transaction);
              if (result.Status == TransactionStatus.Failure)
              {
                transaction.Rollback();
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
            ErrorLog.LogErrorMessageToDB("", "StateDL.cs", "Commit For Add", ex.Message, _myConnection);
            System.Web.HttpContext.Current.Response.Redirect("~/OrderErrorPage.aspx");
            return new TransactionResult(TransactionStatus.Failure, "Failure Adding State Description");
          }
          if (ScreenMode == ScreenMode.Edit)
          {
            ErrorLog.LogErrorMessageToDB("", "StateDL.cs", "Commit For Edit", ex.Message, _myConnection);
            System.Web.HttpContext.Current.Response.Redirect("~/OrderErrorPage.aspx");
            return new TransactionResult(TransactionStatus.Failure, "Failure Updating State Description");
          }
          if (ScreenMode == ScreenMode.Delete)
          {
            ErrorLog.LogErrorMessageToDB("", "StateDL.cs", "Commit For Delete", ex.Message, _myConnection);
            System.Web.HttpContext.Current.Response.Redirect("~/OrderErrorPage.aspx");
            return new TransactionResult(TransactionStatus.Failure, "Failure Deleting State Description");
          }
        }
        return result;
      }
    }

    /// <summary>
    /// Gets the State Details based on the StateID
    /// </summary>
    private void GetState()
    {
      try
      {
        Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
        string sqlCommand = "spGetState";
        DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
        db.AddInParameter(dbCommand, "StateID", DbType.Int32, StateID);
        DataSet ds = db.ExecuteDataSet(dbCommand);

        // Load State Info
        if (ds.Tables[0].Rows.Count > 0)
        {
          DataRow dRow = ds.Tables[0].Rows[0];
          StateID = Common.CheckIntNull(dRow["StateID"]);
          StateName = Common.CheckNull(dRow["StateName"]);
          CountryID = Common.CheckIntNull(dRow["CountryID"]);
          CountryName = Common.CheckNull(dRow["CountryName"]);
        }
      }
      catch (Exception ex)
      {
        ErrorLog.LogErrorMessageToDB("", "StateDL.cs", "GetState", ex.Message.ToString(), _myConnection);
        System.Web.HttpContext.Current.Response.Redirect("~/OrderErrorPage.aspx");
      }
    }

    /// <summary>
    /// AddEditState
    /// </summary>
    /// <param name="db"></param>
    /// <param name="transaction"></param>
    /// <returns></returns>
    private TransactionResult AddEditState(Database db, DbTransaction transaction)
    {
      int returnValue = 0;
      string sqlCommand = "spAddEditState";
      DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
      db.AddInParameter(dbCommand, "CountryID", DbType.Int32, CountryID);
      db.AddInParameter(dbCommand, "StateID", DbType.Int32, StateID);
      db.AddInParameter(dbCommand, "StateName", DbType.String, StateName);
      db.AddInParameter(dbCommand, "AddEditOption", DbType.Int16, AddEditOption);

      db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                      DataRowVersion.Default, returnValue);

      db.ExecuteNonQuery(dbCommand, transaction);
      returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

      StateID = returnValue;

      if (returnValue == 0)
      {
        return new TransactionResult(TransactionStatus.Failure, "State Already Exists in the Country");
      }
      else if (returnValue == -1)
      {
        if (AddEditOption == 1)
          return new TransactionResult(TransactionStatus.Failure, "Failure Updated");
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
    /// DeleteState
    /// </summary>
    /// <param name="db"></param>
    /// <param name="transaction"></param>
    /// <returns></returns>
    private TransactionResult DeleteState(Database db, DbTransaction transaction)
    {
      int returnValue = 0;
      string sqlCommand = "spDeleteState";
      DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
      db.AddInParameter(dbCommand, "StateID", DbType.Int32, StateID);
      db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                      DataRowVersion.Default, returnValue);

      db.ExecuteNonQuery(dbCommand, transaction);
      returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

      if (returnValue == -1)
        return new TransactionResult(TransactionStatus.Failure, "Failure Deleting State");
      else
        return new TransactionResult(TransactionStatus.Success, "State Successfully Deleted");
    }

    #endregion
  }
}
