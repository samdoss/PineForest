using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using PineForest.CommonLayer;
using System.Data;

namespace PineForest.DataLayer
{
    public class EnquiryReviewListDL
    {
        private int _addEditOption;
        private int _enquiryReviewListID;

        public int EnquiryReviewListID
        {
            get { return _enquiryReviewListID; }
            set { _enquiryReviewListID = value; }
        }

        private int _enquiryReviewCheckListID;

        public int EnquiryReviewCheckListID
        {
            get { return _enquiryReviewCheckListID; }
            set { _enquiryReviewCheckListID = value; }
        }
        private int _reviewDetailsID;

        public int ReviewDetailsID
        {
            get { return _reviewDetailsID; }
            set { _reviewDetailsID = value; }
        }
        private bool _isYes;

        public bool IsYes
        {
            get { return _isYes; }
            set { _isYes = value; }
        }
        private bool _isNo;

        public bool IsNo
        {
            get { return _isNo; }
            set { _isNo = value; }
        }
        private bool _isNA;

        public bool IsNA
        {
            get { return _isNA; }
            set { _isNA = value; }
        }
        private string _remarks;

        public string Remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }


        private PineConnection _myConnection;
        private ScreenMode _screenMode;

        public EnquiryReviewListDL()
        {
            _myConnection = new PineConnection();
            AddEditOption = 0;
        }

        public int AddEditOption
        {
            get { return _addEditOption; }
            set { _addEditOption = value; }
        }
        public ScreenMode ScreenMode
        {
            get
            {
                return _screenMode;
            }
            set
            {
                _screenMode = value;
            }
        }

        private TransactionResult AddEditEnquiryReviewList(Database db, DbTransaction transaction)
        {
            int i = 0;
            DbCommand dbCommand = db.GetStoredProcCommand("spAddEditEnquiryReviewList");
            db.AddInParameter(dbCommand, "EnquiryReviewListID", System.Data.DbType.Int32, _enquiryReviewListID);
            db.AddInParameter(dbCommand, "EnquiryReviewCheckListID", System.Data.DbType.Int32, _enquiryReviewCheckListID);
            db.AddInParameter(dbCommand, "ReviewDetailsID", System.Data.DbType.Int32, _reviewDetailsID);
            db.AddInParameter(dbCommand, "IsYes", System.Data.DbType.Boolean, _isYes);
            db.AddInParameter(dbCommand, "IsNo", System.Data.DbType.Boolean, _isNo);
            db.AddInParameter(dbCommand, "IsNA", System.Data.DbType.Boolean, _isNA);
            db.AddInParameter(dbCommand, "Remarks", System.Data.DbType.String, _remarks);

            db.AddInParameter(dbCommand, "AddEditOption", System.Data.DbType.Int16, _addEditOption);
            db.AddParameter(dbCommand, "Return Value", System.Data.DbType.Int32, System.Data.ParameterDirection.ReturnValue, "Return Value", System.Data.DataRowVersion.Default, i);
            db.ExecuteNonQuery(dbCommand, transaction);
            _enquiryReviewListID = (int)db.GetParameterValue(dbCommand, "Return Value");
            if (_enquiryReviewListID == -1)
            {
                if (_addEditOption == 1)
                    return new TransactionResult(TransactionStatus.Failure, "Failure Updating");
                else
                    return new TransactionResult(TransactionStatus.Failure, "Failure Adding");
            }           
            else
            {
                if (_addEditOption == 1)
                {
                    return new TransactionResult(TransactionStatus.Success, "Successfully Updated");
                }
                else
                {
                    return new TransactionResult(TransactionStatus.Success, "Successfully Added");
                }
            }
        }


        #region Commit Add/Update/Delete Transactions

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
                    switch (_screenMode)
                    {
                        case ScreenMode.Add:
                            result = AddEditEnquiryReviewList(db, transaction);
                            if (result.Status == TransactionStatus.Failure)
                            {
                                transaction.Rollback();
                                return result;
                            }

                            break;
                        case ScreenMode.Edit:
                            break;
                        case ScreenMode.Delete:
                            result = DeleteEnquiryReviewList(db, transaction);
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
                    if (_screenMode == ScreenMode.Add)
                    {

                        return new TransactionResult(TransactionStatus.Failure, "Failure Adding");
                    }
                    if (_screenMode == ScreenMode.Edit)
                    {

                        return new TransactionResult(TransactionStatus.Failure, "Failure Updating");
                    }
                    if (_screenMode == ScreenMode.Delete)
                    {

                        return new TransactionResult(TransactionStatus.Failure, "Failure Deleting");
                    }
                }
            }
            return null;
        }
        #endregion


        private TransactionResult DeleteEnquiryReviewList(Database db, DbTransaction transaction)
        {
            TransactionResult transactionResult;
            int i = 0;
            DbCommand dbCommand = db.GetStoredProcCommand("spDeleteEnquiryReviewList");
            db.AddInParameter(dbCommand, "EnquiryReviewListID", System.Data.DbType.Int32, _enquiryReviewListID);
            db.AddParameter(dbCommand, "Return Value", System.Data.DbType.Int32, System.Data.ParameterDirection.ReturnValue, "Return Value", System.Data.DataRowVersion.Default, i);
            db.ExecuteNonQuery(dbCommand, transaction);
            i = (int)db.GetParameterValue(dbCommand, "Return Value");
            transactionResult = i == -1 ? new TransactionResult(TransactionStatus.Failure, "Failure Deleted") : new TransactionResult(TransactionStatus.Success, "Successfully Deleted");
            return transactionResult;
        }

        public void GetEnquiryReviewListByEnquiryReviewListID(int enquiryReviewListID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
                string sqlCommand = "spGetEnquiryReviewListByEnquiryReviewListID";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "EnquiryReviewListID", DbType.Int32, enquiryReviewListID);
                DataSet ds = db.ExecuteDataSet(dbCommand);
                               
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dRow = ds.Tables[0].Rows[0];                    
                    EnquiryReviewListID = Common.CheckIntNull(Convert.ToInt32(dRow["EnquiryReviewListID"]));
                    EnquiryReviewCheckListID = Common.CheckIntNull(Convert.ToInt32(dRow["EnquiryReviewCheckListID"]));
                    ReviewDetailsID = Common.CheckIntNull(Convert.ToInt32(dRow["ReviewDetailsID"]));
                    IsYes = Convert.ToBoolean(dRow["IsYes"]);
                    IsNo = Convert.ToBoolean(dRow["IsNo"]);
                    IsNA = Convert.ToBoolean(dRow["IsNA"]);
                    Remarks = Common.CheckNull(Convert.ToString(dRow["Remarks"]));
                }
            }
            catch (System.Exception exception1)
            {
                ErrorLog.LogErrorMessageToDB("", "EnquiryReviewListDL.cs", "GetEnquiryReviewListByEnquiryReviewListID", exception1.Message.ToString(), _myConnection);
            }

        }

        public void GetEnquiryReviewListByReviewDetailsID(int enquiryReviewCheckListID, int reviewDetailsID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
                string sqlCommand = "spGetEnquiryReviewListByReviewDetailsID";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "EnquiryReviewCheckListID", DbType.Int32, enquiryReviewCheckListID);
                db.AddInParameter(dbCommand, "ReviewDetailsID", DbType.Int32, reviewDetailsID);
                DataSet ds = db.ExecuteDataSet(dbCommand);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dRow = ds.Tables[0].Rows[0];
                    EnquiryReviewListID = Common.CheckIntNull(Convert.ToInt32(dRow["EnquiryReviewListID"]));
                    EnquiryReviewCheckListID = Common.CheckIntNull(Convert.ToInt32(dRow["EnquiryReviewCheckListID"]));
                    ReviewDetailsID = Common.CheckIntNull(Convert.ToInt32(dRow["ReviewDetailsID"]));
                    IsYes = Convert.ToBoolean(dRow["IsYes"]);
                    IsNo = Convert.ToBoolean(dRow["IsNo"]);
                    IsNA = Convert.ToBoolean(dRow["IsNA"]);
                    Remarks = Common.CheckNull(Convert.ToString(dRow["Remarks"]));
                }
            }
            catch (System.Exception exception1)
            {
                ErrorLog.LogErrorMessageToDB("", "EnquiryReviewListDL.cs", "GetEnquiryReviewListByEnquiryReviewListID", exception1.Message.ToString(), _myConnection);
            }

        }

        public System.Data.DataSet GetReviewDetailList()
        {
            System.Data.DataSet dataSet;
            dataSet = new System.Data.DataSet();
            try
            {
                Database database = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
                dataSet = database.ExecuteDataSet(database.GetStoredProcCommand("spGetReviewDetailList"));
            }
            catch (System.Exception exception1)
            {
                ErrorLog.LogErrorMessageToDB("", "EnquiryReviewListDL.cs", "GetEnquiryReviewList", exception1.Message.ToString(), _myConnection);
                throw;
            }
            return dataSet;
        }

        public System.Data.DataSet GetEnquiryReviewList()
        {
            System.Data.DataSet dataSet;
            dataSet = new System.Data.DataSet();
            try
            {
                Database database = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
                dataSet = database.ExecuteDataSet(database.GetStoredProcCommand("spGetEnquiryReviewList"));
            }
            catch (System.Exception exception1)
            {
                ErrorLog.LogErrorMessageToDB("", "EnquiryReviewListDL.cs", "GetEnquiryReviewList", exception1.Message.ToString(), _myConnection);
                throw;
            }
            return dataSet;
        }

    }
}
