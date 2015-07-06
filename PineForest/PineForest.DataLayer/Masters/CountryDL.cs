using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;
using PineForest.CommonLayer;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace PineForest.DataLayer
{
  public class CountryDL : CommonForAllDL
  {
    #region Properties

    public new ScreenMode ScreenMode { get; set; }

    public int CountryID { get; set; }

    public string CountryName { get; set; }

    public List<StateDL> States { get; set; }

    public new int AddEditOption { get; set; }

    #endregion

    #region Constructors

    /// <summary>
    /// Class Constructor
    /// </summary>
    public CountryDL()
    {
      States = new List<StateDL>();
    }

    /// <summary>
    /// Constructor with Parameters
    /// </summary>
    /// <param name="CountryID"></param>
    /// <param name="getAllProperties"></param>
    public CountryDL(int CountryID, bool getAllProperties)
    {
      if (getAllProperties)
        GetCountry();
    }

    #endregion

    #region Methods

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
              //Adding Country
              result = AddEditCountry(db, transaction);
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
              result = DeleteCountry(db, transaction);
              if (result.Status == TransactionStatus.Failure)
              {
                transaction.Rollback();
                return result;
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
            if (((System.Data.SqlClient.SqlException)(ex)).Number == 2627)
            {
              return new TransactionResult(TransactionStatus.Failure, "Failure - Duplicate Country Name");
            }
            else
            {
              ErrorLog.LogErrorMessageToDB("", "CountryDL.cs", "Commit For Add", ex.Message, _myConnection);
              return new TransactionResult(TransactionStatus.Failure, "Failure Adding Country Description");
            }
          }
          if (ScreenMode == ScreenMode.Edit)
          {
            ErrorLog.LogErrorMessageToDB("", "CountryDL.cs", "Commit For Edit", ex.Message, _myConnection);
            return new TransactionResult(TransactionStatus.Failure, "Failure Updating Country Description");
          }
          if (ScreenMode == ScreenMode.Delete)
          {
            ErrorLog.LogErrorMessageToDB("", "CountryDL.cs", "Commit For Delete", ex.Message, _myConnection);
            return new TransactionResult(TransactionStatus.Failure, "Failure Deleting Country Description");
          }
        }
        return result;
      }
    }

    /// <summary>
    /// Get Country List - Added standard sp name on 20/06/2014
    /// </summary>
    /// <param name="PineConnection">Instance of the PineConnection Class</param>
    /// <returns>Return the data as Dataset</returns>
    public DataSet GetCountryList()
    {
      DataSet ds = new DataSet();

      try
      {
        Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
        string sqlCommand = "spGetCountryList";//spGetCountryList
        DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
        ds = db.ExecuteDataSet(dbCommand);
      }
      catch (Exception ex)
      {
        ErrorLog.LogErrorMessageToDB("", "CountryDL.cs", "GetCountryList", ex.Message.ToString(), _myConnection);
      }
      return ds;
    }

    /// <summary>
    /// GetCountryIDFromCountryName - Added standard sp name on 20/06/2014
    /// </summary>
    /// <param name="countryName"></param>
    /// <returns></returns>
    public int GetCountryIDFromCountryName(string countryName)
    {
      int countryID = 0;
      try
      {
        Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
        string sqlCommand = "spGetCountryIDFromCountryName";//spGetCountryIDFromCountryName
        DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
        db.AddInParameter(dbCommand, "CountryName", DbType.String, countryName);
        using (SqlDataReader dataReader = (SqlDataReader)db.ExecuteReader(dbCommand))
        {
          if (dataReader.HasRows)
          {
            while (dataReader.Read())
            {
              countryID = Common.CheckIntNull(dataReader.GetInt32(dataReader.GetOrdinal("CountryID")));
            }
          }
        }
      }
      catch (Exception ex)
      {
        ErrorLog.LogErrorMessageToDB("", "CountryDL.cs", "GetCountryIDFromCountryName", ex.Message, _myConnection);
      }
      return countryID;
    }

    /// <summary>
    /// GetCountry
    /// </summary>
    private void GetCountry()
    {
      try
      {
        Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
        string sqlCommand = "spGetCountry";
        DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
        db.AddInParameter(dbCommand, "CountryID", DbType.Int32, CountryID);
        using (SqlDataReader dataReader = (SqlDataReader)db.ExecuteReader(dbCommand))
        {
          if (dataReader.HasRows)
          {
            while (dataReader.Read())
            {
              CountryName = Common.CheckNull(dataReader.GetString(dataReader.GetOrdinal("CountryName")));
            }
          }
        }
      }
      catch (Exception ex)
      {
        ErrorLog.LogErrorMessageToDB("", "Country.cs", "GetCountry", ex.Message.ToString(), _myConnection);
      }
    }

    /// <summary>
    /// AddEditCountry
    /// </summary>
    /// <param name="db"></param>
    /// <param name="transaction"></param>
    /// <returns></returns>
    private TransactionResult AddEditCountry(Database db, DbTransaction transaction)
    {
      try
      {
        int returnValue = 0;
        string sqlCommand = "Country_MERGE";//spAddEditCountry
        DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

        db.AddInParameter(dbCommand, "CountryID", DbType.Int32, CountryID);
        db.AddInParameter(dbCommand, "CountryName", DbType.String, CountryName);

        db.AddInParameter(dbCommand, "AddEditOption", DbType.Int16, AddEditOption);

        db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                        DataRowVersion.Default, returnValue);

        db.ExecuteNonQuery(dbCommand, transaction);
        returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

        CountryID = returnValue;

        if (returnValue == -1)
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
      catch (Exception ex)
      {
        ErrorLog.LogErrorMessageToDB("", "CountryDL.cs", "AddEditCountry", ex.Message.ToString(), _myConnection);
        return new TransactionResult(TransactionStatus.Failure, "Failed Updating");
      }
    }

    /// <summary>
    /// DeleteCountry
    /// </summary>
    /// <param name="db"></param>
    /// <param name="transaction"></param>
    /// <returns></returns>
    private TransactionResult DeleteCountry(Database db, DbTransaction transaction)
    {
      try
      {
        int returnValue = 0;
        string sqlCommand = "Country_MERGE";//spDeleteCountry
        DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
        db.AddInParameter(dbCommand, "CountryID", DbType.Int32, CountryID);
        db.AddInParameter(dbCommand, "AddEditOption", DbType.Int16, AddEditOption);
        db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                        DataRowVersion.Default, returnValue);

        db.ExecuteNonQuery(dbCommand, transaction);
        returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

        if (returnValue == -1)
          return new TransactionResult(TransactionStatus.Failure, "Failure Deleting Country");
        else
          return new TransactionResult(TransactionStatus.Success, "Country Successfully Deleted");
      }
      catch (Exception ex)
      {
        ErrorLog.LogErrorMessageToDB("", "CountryDL.cs", "DeleteCountry", ex.Message.ToString(), _myConnection);
        return new TransactionResult(TransactionStatus.Failure, "Failed Updating");
      }
    }

    #endregion
  }
}
