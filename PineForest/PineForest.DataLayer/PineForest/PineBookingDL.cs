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

        public PineBookingDL()
        {

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
