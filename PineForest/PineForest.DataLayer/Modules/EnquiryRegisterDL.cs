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
    public class EnquiryRegisterDL
    {

        #region private variable
        
        private int _addEditOption;
        private int _enquiryReviewCheckListID;       
        private int _contactID;
        private string _customerName;
        private Nullable<DateTime> _quotationDate;
        private string _partDescription;
        private string _enquiryNO;
        private Nullable<DateTime> _enquiryDate;
        private string _custEnqRef;
        private string _drawingNo_Issue;
        private string _scopeofSupply;
        private string _specialTermsConditions;
        private bool _enquiryReviewStatus;
        private bool _isStatusAccepted;
        private string _quoteRef;
        private bool _isNotAccepted;
        private bool _isClarifications;
        private string _comments;
        private int _reviewedBy;
        private Nullable<DateTime> _reviewedDate;
        private string _quoatationSendBy;

        private int _enquiryRegisterID;
        private string _legalReqmts;
        private string _regretLetter;
        private string _q1Reqmts;
        private string _aPI6AReqmts;
        private string _pODetails;
        private string _status;
        private Nullable<DateTime> _auditDate;
        private int _auditID;

        #endregion

        #region Public variable
        public string RegretLetter
        {
            get { return _regretLetter; }
            set { _regretLetter = value; }
        }
        
        public string LegalReqmts
        {
            get { return _legalReqmts; }
            set { _legalReqmts = value; }
        }
        
        public string Q1Reqmts
        {
            get { return _q1Reqmts; }
            set { _q1Reqmts = value; }
        }
        
        public string API6AReqmts
        {
            get { return _aPI6AReqmts; }
            set { _aPI6AReqmts = value; }
        }
        
        public string PODetails
        {
            get { return _pODetails; }
            set { _pODetails = value; }
        }
        
        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }
	
        public int EnquiryRegisterID
        {
            get { return _enquiryRegisterID; }
            set { _enquiryRegisterID = value; }
        }
        
        public int EnquiryReviewCheckListID
        {
            get { return _enquiryReviewCheckListID; }
            set { _enquiryReviewCheckListID = value; }
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
        
        public string EnquiryNO
        {
            get { return _enquiryNO; }
            set { _enquiryNO = value; }
        }
        
        public Nullable<DateTime> EnquiryDate
        {
            get { return _enquiryDate; }
            set { _enquiryDate = value; }
        }
        
        public string CustEnqRef
        {
            get { return _custEnqRef; }
            set { _custEnqRef = value; }
        }
       
        public string DrawingNo_Issue
        {
            get { return _drawingNo_Issue; }
            set { _drawingNo_Issue = value; }
        }
       
        public string ScopeofSupply
        {
            get { return _scopeofSupply; }
            set { _scopeofSupply = value; }
        }
        
        public string SpecialTermsConditions
        {
            get { return _specialTermsConditions; }
            set { _specialTermsConditions = value; }
        }
       
        public bool EnquiryReviewStatus
        {
            get { return _enquiryReviewStatus; }
            set { _enquiryReviewStatus = value; }
        }
       
        public bool IsStatusAccepted
        {
            get { return _isStatusAccepted; }
            set { _isStatusAccepted = value; }
        }
       
        public string QuoteRef
        {
            get { return _quoteRef; }
            set { _quoteRef = value; }
        }
       
        public bool IsNotAccepted
        {
            get { return _isNotAccepted; }
            set { _isNotAccepted = value; }
        }
       
        public bool IsClarifications
        {
            get { return _isClarifications; }
            set { _isClarifications = value; }
        }
        
        public string Comments
        {
            get { return _comments; }
            set { _comments = value; }
        }
        
        public int ReviewedBy
        {
            get { return _reviewedBy; }
            set { _reviewedBy = value; }
        }
        
        public Nullable<DateTime> ReviewedDate
        {
            get { return _reviewedDate; }
            set { _reviewedDate = value; }
        }
        public string QuoatationSendBy
        {
            get { return _quoatationSendBy; }
            set { _quoatationSendBy = value; }
        }
        public Nullable<DateTime> AuditDate
        {
            get { return _auditDate; }
            set { _auditDate = value; }
        }
       
        private PineConnection _myConnection;
        private ScreenMode _screenMode;

        public EnquiryRegisterDL()
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

        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }

        #endregion

        private TransactionResult AddEditEnquiryRegister(Database db, System.Data.Common.DbTransaction transaction)
        {
            //TransactionResult transactionResult;
            bool bl;
            int i = 0;
            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand("spAddEditEnquiryRegister");
            db.AddInParameter(dbCommand, "EnquiryRegisterID", System.Data.DbType.Int32, _enquiryRegisterID);
            db.AddInParameter(dbCommand, "EnquiryReviewCheckListID", System.Data.DbType.Int32, _enquiryReviewCheckListID);

            db.AddInParameter(dbCommand, "RegretLetter", System.Data.DbType.String, _regretLetter);
            db.AddInParameter(dbCommand, "LegalReqmts", System.Data.DbType.String, _legalReqmts);
            db.AddInParameter(dbCommand, "Q1Reqmts", System.Data.DbType.String, _q1Reqmts);
            db.AddInParameter(dbCommand, "API6AReqmts", System.Data.DbType.String, _aPI6AReqmts);
            db.AddInParameter(dbCommand, "PODetails", System.Data.DbType.String, _pODetails);
            db.AddInParameter(dbCommand, "Status", System.Data.DbType.String, _status);        

            db.AddInParameter(dbCommand, "AuditDate", System.Data.DbType.DateTime, _auditDate);

            db.AddInParameter(dbCommand, "AuditID", System.Data.DbType.Int32, _auditID);
            db.AddInParameter(dbCommand, "AddEditOption", System.Data.DbType.Int16, _addEditOption);
            db.AddParameter(dbCommand, "Return Value", System.Data.DbType.Int32, System.Data.ParameterDirection.ReturnValue, "Return Value", System.Data.DataRowVersion.Default, i);
            db.ExecuteNonQuery(dbCommand, transaction);
            _enquiryRegisterID = (int)db.GetParameterValue(dbCommand, "Return Value");
            if (_enquiryRegisterID == -1)
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
                            result = AddEditEnquiryRegister(db, transaction);
                            if (result.Status == TransactionStatus.Failure)
                            {
                                transaction.Rollback();
                                return result;
                            }

                            break;
                        case ScreenMode.Edit:
                            break;
                        case ScreenMode.Delete:
                            result = DeleteEnquiryRegister(db, transaction);
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


        private TransactionResult DeleteEnquiryRegister(Database db, System.Data.Common.DbTransaction transaction)
        {
            TransactionResult transactionResult;
            int i = 0;
            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand("spDeleteEnquiryRegister");
            db.AddInParameter(dbCommand, "EnquiryRegisterID", System.Data.DbType.Int32, _enquiryRegisterID);
            db.AddParameter(dbCommand, "Return Value", System.Data.DbType.Int32, System.Data.ParameterDirection.ReturnValue, "Return Value", System.Data.DataRowVersion.Default, i);
            db.ExecuteNonQuery(dbCommand, transaction);
            i = (int)db.GetParameterValue(dbCommand, "Return Value");
            transactionResult = i == -1 ? new TransactionResult(TransactionStatus.Failure, "Failure Deleted") : new TransactionResult(TransactionStatus.Success, "Successfully Deleted");
            return transactionResult;
        }

        public void GetEnquiryRegisterByEnquiryRegisterID(int enquiryRegisterListID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
                string sqlCommand = "spGetEnquiryRegisterByEnquiryRegisterID";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "EnquiryRegisterID", DbType.Int32, enquiryRegisterListID);
                DataSet ds = db.ExecuteDataSet(dbCommand);

                // Load Employee Info
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dRow = ds.Tables[0].Rows[0];

                    EnquiryReviewCheckListID = Common.CheckIntNull(Convert.ToInt32(dRow["EnquiryReviewCheckListID"]));
                    ContactID = Common.CheckIntNull(Convert.ToInt32(dRow["ContactID"]));
                    CustomerName = Common.CheckNull(Convert.ToString(dRow["CustomerName"]));
                    

                    QuotationDate = Convert.ToDateTime(dRow["QuotationDate"]);
                    PartDescription = Common.CheckNull(Convert.ToString(dRow["PartDescription"]));
                    EnquiryNO = Common.CheckNull(Convert.ToString(dRow["EnquiryNO"]));
                    EnquiryDate = Convert.ToDateTime(dRow["EnquiryDate"]);
                    CustEnqRef = Common.CheckNull(Convert.ToString(dRow["CustEnqRef"]));
                    DrawingNo_Issue = Common.CheckNull(Convert.ToString(dRow["DrawingNo_Issue"]));
                    ScopeofSupply = Common.CheckNull(Convert.ToString(dRow["ScopeofSupply"]));
                    EnquiryReviewStatus = Convert.ToBoolean(dRow["EnquiryReviewStatus"]);
                    QuoteRef = Common.CheckNull(Convert.ToString(dRow["QuoteRef"]));

                    EnquiryRegisterID = Common.CheckIntNull(Convert.ToInt32(dRow["EnquiryRegisterID"]));
                    RegretLetter = Common.CheckNull(Convert.ToString(dRow["RegretLetter"]));
                    LegalReqmts = Common.CheckNull(Convert.ToString(dRow["LegalReqmts"]));
                    Q1Reqmts = Common.CheckNull(Convert.ToString(dRow["Q1Reqmts"]));
                    API6AReqmts = Common.CheckNull(Convert.ToString(dRow["API6AReqmts"]));
                    PODetails = Common.CheckNull(Convert.ToString(dRow["PODetails"]));
                    Status = Common.CheckNull(Convert.ToString(dRow["Status"]));

                    AuditDate = Convert.ToDateTime(dRow["AuditDate"]);
                    AuditID = Common.CheckIntNull(Convert.ToInt32(dRow["AuditID"]));

                }
            }
            catch (System.Exception exception1)
            {
                ErrorLog.LogErrorMessageToDB("", "EnquiryRegisterDL.cs", "GetEnquiryRegisterByEnquiryRegisterID", exception1.Message.ToString(), _myConnection);
            }
           
        }

        public System.Data.DataSet GetEnquiryRegisterList()
        {
            System.Data.DataSet dataSet;
            dataSet = new System.Data.DataSet();
            try
            {
                Database database = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
                dataSet = database.ExecuteDataSet(database.GetStoredProcCommand("spGetEnquiryRegisterList"));
            }
            catch (System.Exception exception1)
            {
                ErrorLog.LogErrorMessageToDB("", "EnquiryRegisterDL.cs", "GetEnquiryRegisterList", exception1.Message.ToString(), _myConnection);
                throw;
            }
            return dataSet;
        }

    }
}
