using System;
using System.Data.Common;
using System.Data.SqlClient;
using PineForest.CommonLayer;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace PineForest.DataLayer
{
  public class InspirationQuoteDL : CommonForAllDL
  {
    #region Properties

    public string QuotesLine1 { get; set; }

    public string QuotesLine2 { get; set; }

    public string Author { get; set; }

    #endregion

    #region Constructors

    public InspirationQuoteDL()
    {
      GetInspirationQuoteOfTheDay();
    }

    #endregion

    #region Methods

    /// <summary>
    /// Get Inspiration Quote Of The Day
    /// </summary>
    private void GetInspirationQuoteOfTheDay()
    {
      try
      {
        Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
        string sqlCommand = "spGetInspirationQuoteOfTheDay";
        DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
        using (SqlDataReader dataReader = (SqlDataReader)db.ExecuteReader(dbCommand))
        {
          if (dataReader.HasRows)
          {
            while (dataReader.Read())
            {
              QuotesLine1 = dataReader.GetString(dataReader.GetOrdinal("QuoteLine1"));
              QuotesLine2 = dataReader.GetString(dataReader.GetOrdinal("QuoteLine2"));
              Author = dataReader.GetString(dataReader.GetOrdinal("Author"));
            }
          }
        }
      }
      catch (Exception ex)
      {
        ErrorLog.LogErrorMessageToDB("", "InspirationQuoteDL.cs", "GetInspirationQuoteOfTheDay", ex.Message.ToString(), _myConnection);
      }
    }

    #endregion
  }
}
