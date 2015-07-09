using Microsoft.Practices.EnterpriseLibrary.Data;
using PineForest.CommonLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace PineForest.DataLayer.PineForest
{
    public class PineLoginDL : CommonForAllDL
    {
        //LoginID	int	Unchecked
        //RoleID	int	Unchecked
        //LoginMailID	varchar(300)	Checked
        //LoginMobileNo	varchar(20)	Checked
        //IsAuthenticated	bit	Checked
        //AuthenticationCode	varchar(8)	Checked
        //AuthenticationDate	date	Checked
        //LogininIpAddress	varchar(20)	Checked
        //geolocation	varchar(30)	Checked

        public int LoginID { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public string LoginMailID { get; set; }
        public string LoginMobileNo { get; set; }
        public bool IsAuthenticated { get; set; }
        public string AuthenticationCode { get; set; }
        public Nullable<DateTime> AuthenticationDate { get; set; }
        public string LogininIpAddress { get; set; }
        public string GeoLocation { get; set; }


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
                            result = AddEditLogin(db, transaction);
                            if (result.Status == TransactionStatus.Failure)
                            {
                                transaction.Rollback();
                                return result;
                            }
                            break;
                        case ScreenMode.Edit:
                            result = UpdateLogin(db, transaction);
                            if (result.Status == TransactionStatus.Failure)
                            {
                                transaction.Rollback();
                                return result;
                            }

                            break;
                        case ScreenMode.Delete:
                            result = DeleteLogin(db, transaction);
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
                        ErrorLog.LogErrorMessageToDB("", "PineLoginDL.cs", "Commit For Add", ex.Message.ToString(), _myConnection);
                        return new TransactionResult(TransactionStatus.Failure, "Failure Adding");
                    }
                    if (ScreenMode == ScreenMode.Edit)
                    {
                        ErrorLog.LogErrorMessageToDB("", "PineLoginDL.cs", "Commit For Edit", ex.Message.ToString(), _myConnection);
                        return new TransactionResult(TransactionStatus.Failure, "Failure Updating");
                    }
                    if (ScreenMode == ScreenMode.Delete)
                    {
                        ErrorLog.LogErrorMessageToDB("", "PineLoginDL.cs", "Commit For Delete", ex.Message.ToString(), _myConnection);
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
        public bool GetLoginDetails(string LoginEmailIDorMobileNo)
        {
            try
            {
                bool _isSuccess = false;
                Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
                string sqlCommand = "spGetLoginDetails";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "@LoginEmailIDorMobileNo", DbType.String, LoginEmailIDorMobileNo);                
                using (SqlDataReader dataReader = (SqlDataReader)db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        _isSuccess = true;
                        LoginID = dataReader.GetInt32(dataReader.GetOrdinal("LoginID"));
                        LoginMailID = dataReader.GetString(dataReader.GetOrdinal("LoginMailID"));
                        LoginMobileNo = dataReader.GetString(dataReader.GetOrdinal("LoginMobileNo"));
                        IsAuthenticated = dataReader.GetBoolean(dataReader.GetOrdinal("IsAuthenticated"));
                        AuthenticationCode = dataReader.GetString(dataReader.GetOrdinal("AuthenticationCode"));
                        AuthenticationDate = dataReader.GetDateTime(dataReader.GetOrdinal("AuthenticationDate"));
                        LogininIpAddress = dataReader.GetString(dataReader.GetOrdinal("LogininIpAddress"));
                        GeoLocation = dataReader.GetString(dataReader.GetOrdinal("geolocation"));
                        RoleName = dataReader.GetString(dataReader.GetOrdinal("RoleName"));
                        RoleID = dataReader.GetInt32(dataReader.GetOrdinal("RoleID"));                       
                    }
                }
                return _isSuccess;
            }
            catch (Exception ex)
            {
                ErrorLog.LogErrorMessageToDB("PineLoginDL.cs", "", "GetLoginDetails", ex.Message, new PineConnection());
                return false;
            }
        }

        /// <summary>
        /// Get Login
        /// </summary>
        /// <returns></returns>
        public bool GetLoginAuthentication(string LoginEmailIDorMobileNo)
        {
            try
            {
                bool _isSuccess = false;
                Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
                string sqlCommand = "spGetLoginAuthentication";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "@LoginEmailIDorMobileNo", DbType.String, LoginEmailIDorMobileNo);
                using (SqlDataReader dataReader = (SqlDataReader)db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        _isSuccess = true;
                        LoginID = dataReader.GetInt32(dataReader.GetOrdinal("LoginID"));
                        LoginMailID = dataReader.GetString(dataReader.GetOrdinal("LoginMailID"));
                        LoginMobileNo = dataReader.GetString(dataReader.GetOrdinal("LoginMobileNo"));
                        IsAuthenticated = dataReader.GetBoolean(dataReader.GetOrdinal("IsAuthenticated"));
                        AuthenticationCode = dataReader.GetString(dataReader.GetOrdinal("AuthenticationCode"));
                        AuthenticationDate = dataReader.GetDateTime(dataReader.GetOrdinal("AuthenticationDate"));
                        LogininIpAddress = dataReader.GetString(dataReader.GetOrdinal("LogininIpAddress"));
                        GeoLocation = dataReader.GetString(dataReader.GetOrdinal("geolocation"));
                        RoleName = dataReader.GetString(dataReader.GetOrdinal("RoleName"));
                        RoleID = dataReader.GetInt32(dataReader.GetOrdinal("RoleID"));
                    }
                }
                return _isSuccess;
            }
            catch (Exception ex)
            {
                ErrorLog.LogErrorMessageToDB("PineLoginDL.cs", "", "GetLoginAuthentication", ex.Message, new PineConnection());
                return false;
            }
        }
    }
}
