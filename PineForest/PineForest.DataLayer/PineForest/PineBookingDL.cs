using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using PineForest.CommonLayer;
using System.Data.Common;

namespace PineForest.DataLayer
{
    public class PineBookingDL : CommonForAllDL
    {
        //BookingID	int
        //LoginID	int
        //RegistrationID	varchar(20)
        //BookingDate	datetime
        //BookingName	varchar(75)
        //BookingFrom	date
        //BookingTo	date
        //CheckInTime	varchar(10)
        //CheckOutTime	varchar(10)
        //NoofAdults	int
        //NoofChildrens	int
        //AdditionalBed	int
        //Proofverification	varchar(100)
        //Remarks	varchar(300)
        //EmailID	varchar(150)
        //PhoneNumber	varchar(15)
        //RoomTypeID	int
        //RoomNo	int
        //AmountPerday	int
        //Discount	int
        //FeesandTax	int
        //TotalAmount	int
        //PaidAmount	int
        //IpAddress	varchar(20)
        //GeoLocation	varchar(150)

        public int BookingID { get; set; }
        public int LoginID { get; set; }
        public string RegistrationID { get; set; }
        public Nullable<DateTime> BookingDate { get; set; }
        public string BookingName { get; set; }
        public Nullable<DateTime> BookingFrom { get; set; }
        public Nullable<DateTime> BookingTo { get; set; }
        public string CheckInTime { get; set; }
        public string CheckOutTime { get; set; }
        public int NoofAdults { get; set; }
        public int NoofChildrens { get; set; }
        public int AdditionalBed { get; set; }
        public string Proofverification { get; set; }
        public string Remarks { get; set; }
        public string EmailID { get; set; }
        public string PhoneNumber { get; set; }
        public int RoomTypeID { get; set; }
        public int RoomNo { get; set; }
        public int AmountPerday { get; set; }
        public int Discount { get; set; }
        public int FeesandTax { get; set; }
        public int TotalAmount { get; set; }
        public int PaidAmount { get; set; }
        public string IpAddress { get; set; }
        public string GeoLocation { get; set; }


        public PineBookingDL()
        {

        }

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
                            result = AddEditPineBooking(db, transaction);
                            if (result.Status == TransactionStatus.Failure)
                            {
                                transaction.Rollback();
                                return result;
                            }
                            break;
                        case ScreenMode.Edit:
                            //result = UpdateLogin(db, transaction);
                            if (result.Status == TransactionStatus.Failure)
                            {
                                transaction.Rollback();
                                return result;
                            }

                            break;
                        case ScreenMode.Delete:
                            //result = DeleteLogin(db, transaction);
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
                        ErrorLog.LogErrorMessageToDB("", "PineBookingDL.cs", "Commit For Add", ex.Message.ToString(), _myConnection);
                        return new TransactionResult(TransactionStatus.Failure, "Failure Adding");
                    }
                    if (ScreenMode == ScreenMode.Edit)
                    {
                        ErrorLog.LogErrorMessageToDB("", "PineBookingDL.cs", "Commit For Edit", ex.Message.ToString(), _myConnection);
                        return new TransactionResult(TransactionStatus.Failure, "Failure Updating");
                    }
                    if (ScreenMode == ScreenMode.Delete)
                    {
                        ErrorLog.LogErrorMessageToDB("", "PineBookingDL.cs", "Commit For Delete", ex.Message.ToString(), _myConnection);
                        return new TransactionResult(TransactionStatus.Failure, "Failure Deleting");
                    }
                }
            }
            return null;
        }

        internal TransactionResult AddEditPineBooking(Database db, DbTransaction transaction)
        {
            try
            {
                int returnValue = 0;
                string sqlCommand = "spAddEditPineBooking";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
               
                db.AddInParameter(dbCommand, "BookingID", DbType.Int32, BookingID);
                db.AddInParameter(dbCommand, "LoginID", DbType.Int32, LoginID);
                db.AddInParameter(dbCommand, "RegistrationID", DbType.String,RegistrationID);
                db.AddInParameter(dbCommand, "BookingDate", DbType.DateTime,BookingDate);
                db.AddInParameter(dbCommand, "BookingName", DbType.String,BookingName);
                db.AddInParameter(dbCommand, "BookingFrom", DbType.DateTime,BookingFrom);
                db.AddInParameter(dbCommand, "BookingTo", DbType.DateTime,BookingTo);
                db.AddInParameter(dbCommand, "CheckInTime", DbType.String,CheckInTime);
                db.AddInParameter(dbCommand, "CheckOutTime", DbType.String,CheckOutTime);
                db.AddInParameter(dbCommand, "NoofAdults", DbType.Int32, NoofAdults);
                db.AddInParameter(dbCommand, "NoofChildrens", DbType.Int32, NoofChildrens);
                db.AddInParameter(dbCommand, "AdditionalBed", DbType.Int32, AdditionalBed);
                db.AddInParameter(dbCommand, "Proofverification", DbType.String,Proofverification);
                db.AddInParameter(dbCommand, "Remarks", DbType.String,Remarks);
                db.AddInParameter(dbCommand, "EmailID", DbType.String,EmailID);
                db.AddInParameter(dbCommand, "PhoneNumber", DbType.String,PhoneNumber);
                db.AddInParameter(dbCommand, "RoomTypeID", DbType.Int32,RoomTypeID);
                db.AddInParameter(dbCommand, "RoomNo", DbType.Int32,RoomNo);
                db.AddInParameter(dbCommand, "AmountPerday", DbType.Int32, AmountPerday);
                db.AddInParameter(dbCommand, "Discount", DbType.Int32,Discount);
                db.AddInParameter(dbCommand, "FeesandTax", DbType.Int32,FeesandTax);
                db.AddInParameter(dbCommand, "TotalAmount", DbType.Int32,TotalAmount);
                db.AddInParameter(dbCommand, "PaidAmount", DbType.Int32,PaidAmount);
                db.AddInParameter(dbCommand, "IpAddress", DbType.String, IpAddress);
                db.AddInParameter(dbCommand, "GeoLocation", DbType.String, GeoLocation);

                db.AddInParameter(dbCommand, "AddEditOption", DbType.Int16, AddEditOption);

                db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                                DataRowVersion.Default, returnValue);

                db.ExecuteNonQuery(dbCommand, transaction);
                returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

                LoginID = returnValue;

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

        public DataSet GetRoomTypes()
        {
            DataSet ds = new DataSet();
            try
            {
                Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
                string sqlCommand = "spGetRoomTypes";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                //db.AddInParameter(dbCommand, "CountryID", DbType.Int32, CountryID);
                ds = db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                ErrorLog.LogErrorMessageToDB("", "PineBookingDL.cs", "GetRoomTypes", ex.Message.ToString(), _myConnection);
            }
            return ds;
        }

        public int GetRoomTypesAvailableCount(int roomTypeID)
        {
            int roomCount = 0;
            DataSet ds = new DataSet();
            try
            {
                Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
                string sqlCommand = "spGetRoomTypeAvailableCount";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "RoomTypeID", DbType.Int32, roomTypeID);
                ds = db.ExecuteDataSet(dbCommand);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dRow = ds.Tables[0].Rows[0];
                    roomCount = Convert.ToInt32(dRow["RoomCount"]);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogErrorMessageToDB("", "PineBookingDL.cs", "GetRoomTypesAvailableCount", ex.Message.ToString(), _myConnection);
            }
            return roomCount;
        }

        public DataSet GetRoomCostOnPeriodDaysByCheckInCheckOut(int roomTypeID, DateTime checkIN, DateTime checkOut)
        {
            DataSet ds = new DataSet();
            try
            {
                Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
                string sqlCommand = "spGetRoomCostOnPeriodDaysByCheckInCheckOut";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "RoomTypeID", DbType.Int32, roomTypeID);
                db.AddInParameter(dbCommand, "CheckIN", DbType.DateTime, checkIN);
                db.AddInParameter(dbCommand, "CheckOUT", DbType.DateTime, checkOut);
                ds = db.ExecuteDataSet(dbCommand);
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    DataRow dRow = ds.Tables[0].Rows[0];
                //    roomCount = Convert.ToInt32(dRow["RoomPriceID"]);
                //    roomCount = Convert.ToInt32(dRow["RoomPriceID"]);
                //    roomCount = Convert.ToInt32(dRow["RoomPriceID"]);
                //}
            }
            catch (Exception ex)
            {
                ErrorLog.LogErrorMessageToDB("", "PineBookingDL.cs", "GetRoomTypesAvailableCount", ex.Message.ToString(), _myConnection);
            }
            return ds;
        }


        public DataSet GetLeaveApplicationDetailList(int employeeID, DateTime fromFinancialYear, DateTime toFinancialYear, int leaveStatusID, int leaveTypeID)
        {
            DataSet ds = new DataSet();
            try
            {
                Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
                string sqlCommand = "spGetLeaveApplicationDetailListByEmployeeIDAndFinancialYearAndStatusAndType";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "EmployeeID", DbType.Int32, employeeID);
                db.AddInParameter(dbCommand, "FromFinancialYear", DbType.DateTime, fromFinancialYear);
                db.AddInParameter(dbCommand, "ToFinancialYear", DbType.DateTime, toFinancialYear);
                db.AddInParameter(dbCommand, "LeaveStatusID", DbType.Int32, leaveStatusID);
                db.AddInParameter(dbCommand, "LeaveTypeID", DbType.Int32, leaveTypeID);
                ds = db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                ErrorLog.LogErrorMessageToDB("", "LeaveApplicationDetailDL.cs", "GetLeaveApplicationDetailList(employeeID,fromFinancialYear,toFinancialYear,leaveStatusID)", ex.Message, _myConnection);
                System.Web.HttpContext.Current.Response.Redirect("~/ECafeErrorPage.aspx");
            }
            return ds;
        }

        //private void GetUserSettings(int userID)
        //{
        //    try
        //    {
        //        Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
        //        string sqlCommand = "spGetUserSettings";
        //        DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
        //        db.AddInParameter(dbCommand, "UserID", DbType.Int32, UserID);
        //        DataSet ds = db.ExecuteDataSet(dbCommand);

        //        // Load Employee Info
        //        if (ds.Tables[0].Rows.Count > 0)
        //        {
        //            DataRow dRow = ds.Tables[0].Rows[0];

        //            UserSettingsID = Convert.ToInt32(dRow["UserSettingsID"]);
        //            DateFormatID = Convert.ToInt32(dRow["DateFormatID"]);
        //            BackgroundColorID = Convert.ToInt32(dRow["BackgroundColorID"]);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLog.LogErrorMessageToDB("", "SettingsDL.cs", "GetUserSettings", ex.Message.ToString(), _myConnection);
        //    }
        //}
    }
}
