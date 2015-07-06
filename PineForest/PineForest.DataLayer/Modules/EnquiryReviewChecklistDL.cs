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
    public class EnquiryReviewChecklistDL
    {
        private int _addEditOption;
        private int _enquiryReviewCheckListID;

        public int EnquiryReviewCheckListID
        {
            get { return _enquiryReviewCheckListID; }
            set { _enquiryReviewCheckListID = value; }
        }
        private int _contactID;

        public int ContactID
        {
            get { return _contactID; }
            set { _contactID = value; }
        }
        private Nullable<DateTime> _quotationDate;

        public Nullable<DateTime> QuotationDate
        {
            get { return _quotationDate; }
            set { _quotationDate = value; }
        }
        private string _partDescription;

        public string PartDescription
        {
            get { return _partDescription; }
            set { _partDescription = value; }
        }
        private string _enquiryNO;

        public string EnquiryNO
        {
            get { return _enquiryNO; }
            set { _enquiryNO = value; }
        }
        private Nullable<DateTime> _enquiryDate;

        public Nullable<DateTime> EnquiryDate
        {
            get { return _enquiryDate; }
            set { _enquiryDate = value; }
        }
        private string _custEnqRef;

        public string CustEnqRef
        {
            get { return _custEnqRef; }
            set { _custEnqRef = value; }
        }
        private string _drawingNo_Issue;

        public string DrawingNo_Issue
        {
            get { return _drawingNo_Issue; }
            set { _drawingNo_Issue = value; }
        }
        private string _scopeofSupply;

        public string ScopeofSupply
        {
            get { return _scopeofSupply; }
            set { _scopeofSupply = value; }
        }
        private string _specialTermsConditions;

        public string SpecialTermsConditions
        {
            get { return _specialTermsConditions; }
            set { _specialTermsConditions = value; }
        }
        private bool _enquiryReviewStatus;

        public bool EnquiryReviewStatus
        {
            get { return _enquiryReviewStatus; }
            set { _enquiryReviewStatus = value; }
        }
        private bool _isStatusAccepted;

        public bool IsStatusAccepted
        {
            get { return _isStatusAccepted; }
            set { _isStatusAccepted = value; }
        }
        private string _quoteRef;

        public string QuoteRef
        {
            get { return _quoteRef; }
            set { _quoteRef = value; }
        }
        private bool _isNotAccepted;

        public bool IsNotAccepted
        {
            get { return _isNotAccepted; }
            set { _isNotAccepted = value; }
        }
        private bool _isClarifications;

        public bool IsClarifications
        {
            get { return _isClarifications; }
            set { _isClarifications = value; }
        }
        private string _comments;

        public string Comments
        {
            get { return _comments; }
            set { _comments = value; }
        }
        private int _reviewedBy;

        public int ReviewedBy
        {
            get { return _reviewedBy; }
            set { _reviewedBy = value; }
        }
        private Nullable<DateTime> _reviewedDate;

        public Nullable<DateTime> ReviewedDate
        {
            get { return _reviewedDate; }
            set { _reviewedDate = value; }
        }
        private string _quoatationSendBy;

        public string QuoatationSendBy
        {
            get { return _quoatationSendBy; }
            set { _quoatationSendBy = value; }
        }
        private Nullable<DateTime> _auditDate;

        public Nullable<DateTime> AuditDate
        {
            get { return _auditDate; }
            set { _auditDate = value; }
        }
        private int _auditID;

        private PineConnection _myConnection;
        private ScreenMode _screenMode;

        public EnquiryReviewChecklistDL()
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

        private TransactionResult AddEditEnquiryReviewChecklist(Database db, System.Data.Common.DbTransaction transaction)
        {
            //TransactionResult transactionResult;
            bool bl;
            int i = 0;
            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand("spAddEditEnquiryReviewCheckList");
            db.AddInParameter(dbCommand, "EnquiryReviewCheckListID", System.Data.DbType.Int32, _enquiryReviewCheckListID);
            db.AddInParameter(dbCommand, "ContactID", System.Data.DbType.Int32, _contactID);
            db.AddInParameter(dbCommand, "QuotationDate", System.Data.DbType.DateTime, _quotationDate);
            db.AddInParameter(dbCommand, "PartDescription", System.Data.DbType.String, _partDescription);
            db.AddInParameter(dbCommand, "EnquiryNO", System.Data.DbType.String, _enquiryNO);
            db.AddInParameter(dbCommand, "EnquiryDate", System.Data.DbType.DateTime, _enquiryDate);
            db.AddInParameter(dbCommand, "CustEnqRef", System.Data.DbType.String, _custEnqRef);
            db.AddInParameter(dbCommand, "DrawingNo_Issue", System.Data.DbType.String, _drawingNo_Issue);
            db.AddInParameter(dbCommand, "ScopeofSupply", System.Data.DbType.String, _scopeofSupply);
            db.AddInParameter(dbCommand, "SpecialTermsConditions", System.Data.DbType.String, _specialTermsConditions);
            db.AddInParameter(dbCommand, "EnquiryReviewStatus", System.Data.DbType.Boolean, _enquiryReviewStatus);
            db.AddInParameter(dbCommand, "IsStatusAccepted", System.Data.DbType.Boolean, _isStatusAccepted);
            db.AddInParameter(dbCommand, "QuoteRef", System.Data.DbType.String, _quoteRef);
            db.AddInParameter(dbCommand, "IsNotAccepted", System.Data.DbType.Boolean, _isNotAccepted);
            db.AddInParameter(dbCommand, "IsClarifications", System.Data.DbType.Boolean, _isClarifications);
            db.AddInParameter(dbCommand, "Comments", System.Data.DbType.String, _comments);
            db.AddInParameter(dbCommand, "ReviewedBy", System.Data.DbType.Int32, _reviewedBy);
            db.AddInParameter(dbCommand, "ReviewedDate", System.Data.DbType.DateTime, _reviewedDate);
            db.AddInParameter(dbCommand, "QuoatationSendBy", System.Data.DbType.String, _quoatationSendBy);
            db.AddInParameter(dbCommand, "AuditDate", System.Data.DbType.DateTime, _auditDate);

            db.AddInParameter(dbCommand, "AuditID", System.Data.DbType.Int32, _auditID);
            db.AddInParameter(dbCommand, "AddEditOption", System.Data.DbType.Int16, _addEditOption);
            db.AddParameter(dbCommand, "Return Value", System.Data.DbType.Int32, System.Data.ParameterDirection.ReturnValue, "Return Value", System.Data.DataRowVersion.Default, i);
            db.ExecuteNonQuery(dbCommand, transaction);
            _enquiryReviewCheckListID = (int)db.GetParameterValue(dbCommand, "Return Value");
            if (_enquiryReviewCheckListID == -1)
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
                            result = AddEditEnquiryReviewChecklist(db, transaction);
                            if (result.Status == TransactionStatus.Failure)
                            {
                                transaction.Rollback();
                                return result;
                            }

                            break;
                        case ScreenMode.Edit:
                            break;
                        case ScreenMode.Delete:
                            result = DeleteEnquiryReviewChecklist(db, transaction);
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


        private TransactionResult DeleteEnquiryReviewChecklist(Database db, System.Data.Common.DbTransaction transaction)
        {
            TransactionResult transactionResult;
            int i = 0;
            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand("spDeleteEnquiryReviewCheckList");
            db.AddInParameter(dbCommand, "EnquiryReviewCheckListID", System.Data.DbType.Int32, _enquiryReviewCheckListID);
            db.AddParameter(dbCommand, "Return Value", System.Data.DbType.Int32, System.Data.ParameterDirection.ReturnValue, "Return Value", System.Data.DataRowVersion.Default, i);
            db.ExecuteNonQuery(dbCommand, transaction);
            i = (int)db.GetParameterValue(dbCommand, "Return Value");
            transactionResult = i == -1 ? new TransactionResult(TransactionStatus.Failure, "Failure Deleted") : new TransactionResult(TransactionStatus.Success, "Successfully Deleted");
            return transactionResult;
        }

        public void GetEnquiryReviewCheckListByEnquiryReviewCheckListID(int enquiryReviewCheckListID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
                string sqlCommand = "spGetEnquiryReviewCheckListByEnquiryReviewCheckListID";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "EnquiryReviewCheckListID", DbType.Int32, enquiryReviewCheckListID);
                DataSet ds = db.ExecuteDataSet(dbCommand);

                // Load Employee Info
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dRow = ds.Tables[0].Rows[0];

                    EnquiryReviewCheckListID = Common.CheckIntNull(Convert.ToInt32(dRow["EnquiryReviewCheckListID"]));
                    ContactID = Common.CheckIntNull(Convert.ToInt32(dRow["ContactID"]));
                    QuotationDate = Convert.ToDateTime(dRow["QuotationDate"]);
                    PartDescription = Common.CheckNull(Convert.ToString(dRow["PartDescription"]));
                    EnquiryNO = Common.CheckNull(Convert.ToString(dRow["EnquiryNO"]));
                    EnquiryDate = Convert.ToDateTime(dRow["EnquiryDate"]);
                    CustEnqRef = Common.CheckNull(Convert.ToString(dRow["CustEnqRef"]));
                    DrawingNo_Issue = Common.CheckNull(Convert.ToString(dRow["DrawingNo_Issue"]));
                    ScopeofSupply = Common.CheckNull(Convert.ToString(dRow["ScopeofSupply"]));
                    SpecialTermsConditions = Common.CheckNull(Convert.ToString(dRow["SpecialTermsConditions"]));
                    EnquiryReviewStatus = Convert.ToBoolean(dRow["EnquiryReviewStatus"]);
                    IsStatusAccepted = Convert.ToBoolean(dRow["IsStatusAccepted"]);
                    QuoteRef = Common.CheckNull(Convert.ToString(dRow["QuoteRef"]));
                    IsNotAccepted = Convert.ToBoolean(dRow["IsNotAccepted"]);
                    IsClarifications = Convert.ToBoolean(dRow["IsClarifications"]);
                    Comments = Common.CheckNull(Convert.ToString(dRow["Comments"]));
                    ReviewedBy = Common.CheckIntNull(Convert.ToInt32(dRow["ReviewedBy"]));
                    ReviewedDate = Convert.ToDateTime(dRow["ReviewedDate"]);
                    QuoatationSendBy = Common.CheckNull(Convert.ToString(dRow["QuoatationSendBy"]));
                    AuditDate = Convert.ToDateTime(dRow["AuditDate"]);
                    AuditID = Common.CheckIntNull(Convert.ToInt32(dRow["AuditID"]));

                }
            }
            catch (System.Exception exception1)
            {
                ErrorLog.LogErrorMessageToDB("", "EnquiryReviewChecklistDL.cs", "GetEnquiryReviewCheckListByEnquiryReviewCheckListID", exception1.Message.ToString(), _myConnection);
            }
           
        }

        public System.Data.DataSet GetEnquiryReviewCheckList()
        {
            System.Data.DataSet dataSet;
            dataSet = new System.Data.DataSet();
            try
            {
                Database database = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
                dataSet = database.ExecuteDataSet(database.GetStoredProcCommand("spGetEnquiryReviewCheckList"));
            }
            catch (System.Exception exception1)
            {
                ErrorLog.LogErrorMessageToDB("", "EnquiryReviewChecklistDL.cs", "GetEnquiryReviewCheckList", exception1.Message.ToString(), _myConnection);
                throw;
            }
            return dataSet;
        }





    }
}
