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
    public class OrderAcceptanceChecklistDL
    {
        #region Private Variables

        private PineConnection _myConnection;
        private ScreenMode _screenMode;

        private int _addEditOption;

        private int _orderAcceptanceCheckListID;
        private int _contactID;
        private Nullable<DateTime> _quotationDate;
        private string _partDescription;
        private string _poNO;
        private Nullable<DateTime> _poDate;
        private string _poAmendRef;
        private string _quotationRef;
        private string _drawingNo_Issue;
        private string _natureOfReview;
        private bool _checkForOption1;
        private bool _checkForOption2;
        private bool _checkForOption3;
        private bool _checkForOption4;
        private string _reviewStatus;
        private int _approvedByID;
        private Nullable<DateTime> _approvedDate;
        private Nullable<DateTime> _modifiedAuditDate;
        private string _comments;
        private int _reviewedByID;
        private Nullable<DateTime> _reviewedDate;
        private Nullable<DateTime> _auditDate;
        private int _auditID;

        #endregion

        #region Public Variables

        public int OrderAcceptanceCheckListID
        {
            get { return _orderAcceptanceCheckListID; }
            set { _orderAcceptanceCheckListID = value; }
        }

        public int ContactID
        {
            get { return _contactID; }
            set { _contactID = value; }
        }

        public Nullable<DateTime> QuotationDate
        {
            get { return _quotationDate; }
            set { _quotationDate = value; }
        }

        public string PartDescription
        {
            get { return _partDescription; }
            set { _partDescription = value; }
        }

        public string PONO
        {
            get { return _poNO; }
            set { _poNO = value; }
        }

        public Nullable<DateTime> PODate
        {
            get { return _poDate; }
            set { _poDate = value; }
        }

        public string POAmendRef
        {
            get { return _poAmendRef; }
            set { _poAmendRef = value; }
        }

        public string QuotationRef
        {
            get { return _quotationRef; }
            set { _quotationRef = value; }
        }

        public string DrawingNo_Issue
        {
            get { return _drawingNo_Issue; }
            set { _drawingNo_Issue = value; }
        }

        public string NatureOfReview
        {
            get { return _natureOfReview; }
            set { _natureOfReview = value; }
        }

        public bool CheckForOption1
        {
            get { return _checkForOption1; }
            set { _checkForOption1 = value; }
        }

        public bool CheckForOption2
        {
            get { return _checkForOption2; }
            set { _checkForOption2 = value; }
        }

        public bool CheckForOption3
        {
            get { return _checkForOption3; }
            set { _checkForOption3 = value; }
        }

        public bool CheckForOption4
        {
            get { return _checkForOption4; }
            set { _checkForOption4 = value; }
        }

        public string ReviewStatus
        {
            get { return _reviewStatus; }
            set { _reviewStatus = value; }
        }

        public int ApprovedByID
        {
            get { return _approvedByID; }
            set { _approvedByID = value; }
        }

        public Nullable<DateTime> ApprovedDate
        {
            get { return _approvedDate; }
            set { _approvedDate = value; }
        }

        public Nullable<DateTime> ModifiedAuditDate
        {
            get { return _modifiedAuditDate; }
            set { _modifiedAuditDate = value; }
        }

        public string Comments
        {
            get { return _comments; }
            set { _comments = value; }
        }

        public int ReviewedByID
        {
            get { return _reviewedByID; }
            set { _reviewedByID = value; }
        }

        public Nullable<DateTime> ReviewedDate
        {
            get { return _reviewedDate; }
            set { _reviewedDate = value; }
        }              

        public Nullable<DateTime> AuditDate
        {
            get { return _auditDate; }
            set { _auditDate = value; }
        }


        public OrderAcceptanceChecklistDL()
        {
            _myConnection = new PineConnection();
            AddEditOption = 0;
        }

        public int AddEditOption
        {
            get { return _addEditOption; }
            set { _addEditOption = value; }
        }

        public int AuditID
        {
            get { return _auditID; }
            set { _auditID = value; }
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

        #endregion

        private TransactionResult AddEditOrderAcceptanceCheckList(Database db, System.Data.Common.DbTransaction transaction)
        {
            //TransactionResult transactionResult;
            bool bl;
            int i = 0;
            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand("spAddEditOrderAcceptanceCheckList");
            db.AddInParameter(dbCommand, "OrderAcceptanceCheckListID", System.Data.DbType.Int32, _orderAcceptanceCheckListID);
            db.AddInParameter(dbCommand, "ContactID", System.Data.DbType.Int32, _contactID);
            db.AddInParameter(dbCommand, "QuotationDate", System.Data.DbType.DateTime, _quotationDate);
            db.AddInParameter(dbCommand, "PartDescription", System.Data.DbType.String, _partDescription);
            db.AddInParameter(dbCommand, "PONO", System.Data.DbType.String, _poNO);
            db.AddInParameter(dbCommand, "PODate", System.Data.DbType.DateTime, _poDate);
            db.AddInParameter(dbCommand, "POAmendRef", System.Data.DbType.String, _poAmendRef);

            db.AddInParameter(dbCommand, "QuotationRef", System.Data.DbType.String, _quotationRef);
            db.AddInParameter(dbCommand, "DrawingNo_Issue", System.Data.DbType.String, _drawingNo_Issue);

            db.AddInParameter(dbCommand, "NatureOfReview", System.Data.DbType.String, _natureOfReview);

            db.AddInParameter(dbCommand, "CheckForOption1", System.Data.DbType.Boolean, _checkForOption1);
            db.AddInParameter(dbCommand, "CheckForOption2", System.Data.DbType.Boolean, _checkForOption2);
            db.AddInParameter(dbCommand, "CheckForOption3", System.Data.DbType.Boolean, _checkForOption3);
            db.AddInParameter(dbCommand, "CheckForOption4", System.Data.DbType.Boolean, _checkForOption4);
            db.AddInParameter(dbCommand, "Comments", System.Data.DbType.String, _comments);

            db.AddInParameter(dbCommand, "ReviewStatus", System.Data.DbType.String, _reviewStatus);

            db.AddInParameter(dbCommand, "ReviewedByID", System.Data.DbType.Int32, _reviewedByID);
            db.AddInParameter(dbCommand, "ReviewedDate", System.Data.DbType.DateTime, _reviewedDate);

            db.AddInParameter(dbCommand, "ApprovedByID", System.Data.DbType.Int32, _approvedByID);
            db.AddInParameter(dbCommand, "ApprovedDate", System.Data.DbType.DateTime, _approvedDate);

            db.AddInParameter(dbCommand, "AuditID", System.Data.DbType.Int32, _auditID);
            db.AddInParameter(dbCommand, "AuditDate", System.Data.DbType.DateTime, _auditDate);
           
            db.AddInParameter(dbCommand, "AddEditOption", System.Data.DbType.Int16, _addEditOption);
            db.AddParameter(dbCommand, "Return Value", System.Data.DbType.Int32, System.Data.ParameterDirection.ReturnValue, "Return Value", System.Data.DataRowVersion.Default, i);
            db.ExecuteNonQuery(dbCommand, transaction);
            _orderAcceptanceCheckListID = (int)db.GetParameterValue(dbCommand, "Return Value");
            if (_orderAcceptanceCheckListID == -1)
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
                            result = AddEditOrderAcceptanceCheckList(db, transaction);
                            if (result.Status == TransactionStatus.Failure)
                            {
                                transaction.Rollback();
                                return result;
                            }

                            break;
                        case ScreenMode.Edit:
                            break;
                        case ScreenMode.Delete:
                            result = DeleteOrderAcceptanceCheckList(db, transaction);
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


        private TransactionResult DeleteOrderAcceptanceCheckList(Database db, System.Data.Common.DbTransaction transaction)
        {
            TransactionResult transactionResult;
            int i = 0;
            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand("spDeleteOrderAcceptanceCheckList");
            db.AddInParameter(dbCommand, "OrderAcceptanceCheckListID", System.Data.DbType.Int32, _orderAcceptanceCheckListID);
            db.AddParameter(dbCommand, "Return Value", System.Data.DbType.Int32, System.Data.ParameterDirection.ReturnValue, "Return Value", System.Data.DataRowVersion.Default, i);
            db.ExecuteNonQuery(dbCommand, transaction);
            i = (int)db.GetParameterValue(dbCommand, "Return Value");
            transactionResult = i == -1 ? new TransactionResult(TransactionStatus.Failure, "Failure Deleted") : new TransactionResult(TransactionStatus.Success, "Successfully Deleted");
            return transactionResult;
        }

        public void GetOrderAcceptanceCheckListByOrderAcceptanceCheckListID(int OrderAcceptanceCheckListID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
                string sqlCommand = "spGetOrderAcceptanceCheckListByOrderAcceptanceCheckListID";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "OrderAcceptanceCheckListID", DbType.Int32, OrderAcceptanceCheckListID);
                DataSet ds = db.ExecuteDataSet(dbCommand);

                // Load Employee Info
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dRow = ds.Tables[0].Rows[0];

                    OrderAcceptanceCheckListID = Common.CheckIntNull(Convert.ToInt32(dRow["OrderAcceptanceCheckListID"]));
                    ContactID = Common.CheckIntNull(Convert.ToInt32(dRow["ContactID"]));
                    QuotationDate = Convert.ToDateTime(dRow["QuotationDate"]);
                    PartDescription = Common.CheckNull(Convert.ToString(dRow["PartDescription"]));
                    PONO = Common.CheckNull(Convert.ToString(dRow["PONO"]));
                    PODate = Convert.ToDateTime(dRow["PODate"]);
                    POAmendRef = Common.CheckNull(Convert.ToString(dRow["POAmendRef"]));
                    QuotationRef = Common.CheckNull(Convert.ToString(dRow["QuotationRef"]));
                    DrawingNo_Issue = Common.CheckNull(Convert.ToString(dRow["DrawingNo_Issue"]));

                    NatureOfReview = Common.CheckNull(Convert.ToString(dRow["NatureOfReview"]));
                    CheckForOption1 = Convert.ToBoolean(dRow["CheckForOption1"]);
                    CheckForOption2 = Convert.ToBoolean(dRow["CheckForOption2"]);
                    CheckForOption3 = Convert.ToBoolean(dRow["CheckForOption3"]);
                    CheckForOption4 = Convert.ToBoolean(dRow["CheckForOption4"]);
                    Comments = Common.CheckNull(Convert.ToString(dRow["Comments"]));

                    ReviewStatus = Common.CheckNull(Convert.ToString(dRow["ReviewStatus"]));
                    ReviewedByID = Common.CheckIntNull(Convert.ToInt32(dRow["ReviewedByID"]));
                    ReviewedDate = Convert.ToDateTime(dRow["ReviewedDate"]);

                    ApprovedByID = Common.CheckIntNull(Convert.ToInt32(dRow["ApprovedByID"]));
                    ApprovedDate = Convert.ToDateTime(dRow["ApprovedDate"]);

                    AuditID = Common.CheckIntNull(Convert.ToInt32(dRow["AuditID"]));
                    AuditDate = Convert.ToDateTime(dRow["AuditDate"]);
                }
            }
            catch (System.Exception exception1)
            {
                ErrorLog.LogErrorMessageToDB("", "OrderAcceptanceCheckListDL.cs", "GetOrderAcceptanceCheckListByOrderAcceptanceCheckListID", exception1.Message.ToString(), _myConnection);
            }

        }

        public System.Data.DataSet GetOrderAcceptanceCheckList()
        {
            System.Data.DataSet dataSet;
            dataSet = new System.Data.DataSet();
            try
            {
                Database database = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
                dataSet = database.ExecuteDataSet(database.GetStoredProcCommand("spGetOrderAcceptanceCheckList"));
            }
            catch (System.Exception exception1)
            {
                ErrorLog.LogErrorMessageToDB("", "OrderAcceptanceCheckListDL.cs", "GetOrderAcceptanceCheckList", exception1.Message.ToString(), _myConnection);
                throw;
            }
            return dataSet;
        }

    }
}
