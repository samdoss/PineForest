using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ACE.PurchaseOrder.CommonLayer;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ACE.PurchaseOrder.DataLayer
{
    public class PODocumentUploadDL
    {
        #region Private variable

        private ACEConnection _myConnection;
        private ScreenMode _screenMode;
        private int _addEditOption;
        private int _workOrderDocumentID;
        private int _contactID;
        private int _workOrderID;
        private string _pONo;
        private string _fileName;
        private string _fileExtension;
        private string _filePathandFileName;
        private string _fileDescription;
        private bool _isActive;

        #endregion

        #region Public variable

        public string FileName
        {
            get
            {
                return _fileName;
            }
            set
            {
                _fileName = value;
            }
        }
        public string FileExtension
        {
            get
            {
                return _fileExtension;
            }
            set
            {
                _fileExtension = value;
            }
        }
        public string FilePathandFileName
        {
            get
            {
                return _filePathandFileName;
            }
            set
            {
                _filePathandFileName = value;
            }
        }

        public string PONo
        {
            get { return _pONo; }
            set { _pONo = value; }
        }
        public string FileDescription
        {
            get
            {
                return _fileDescription;
            }
            set
            {
                _fileDescription = value;
            }
        }
        public bool IsActive
        {
            get
            {
                return _isActive;
            }
            set
            {
                _isActive = value;
            }
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
        public int AddEditOption
        {
            get
            {
                return _addEditOption;
            }
            set
            {
                _addEditOption = value;
            }
        }

        public int WorkOrderDocumentId
        {
            get { return _workOrderDocumentID; }
            set { _workOrderDocumentID = value; }
        }

        public int ContactId
        {
            get { return _contactID; }
            set { _contactID = value; }
        }

        public int WorkOrderId
        {
            get { return _workOrderID; }
            set { _workOrderID = value; }
        }

        #endregion

        public PODocumentUploadDL() : base()
        {
            _myConnection = new ACEConnection();
            _addEditOption = 0;
        }
       
        public TransactionResult Commit()
        {
            TransactionResult transactionResult;
            Database database;
            DbConnection dbConnection;
            DbTransaction dbTransaction;
            Exception exception;
            bool bl;
            transactionResult = null;
            database = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
            dbConnection = database.CreateConnection();
            try
            {
                dbConnection.Open();
                dbTransaction = dbConnection.BeginTransaction();
                try
                {
                    switch (_screenMode)
                    {
                        case ScreenMode.Add:
                            transactionResult = AddEditWorkOrderDocument(database, dbTransaction);
                            bl = transactionResult.Status != TransactionStatus.Failure;
                            if (!bl)
                            {
                                dbTransaction.Rollback();
                                return transactionResult;
                            }
                            break;

                        case ScreenMode.Edit:
                            dbTransaction.Commit();
                            return transactionResult;

                        case ScreenMode.Delete:
                            transactionResult = DeletePatientFiles(database, dbTransaction);
                            bl = transactionResult.Status != TransactionStatus.Failure;
                            if (!bl)
                            {
                                dbTransaction.Rollback();
                                return transactionResult;
                            }
                            break;

                    }
                }
                catch (Exception exception1)
                {
                    exception = exception1;
                    dbTransaction.Rollback();
                    bl = _screenMode != ScreenMode.Add;
                    if (!bl)
                    {
                        ErrorLog.LogErrorMessageToDB("", "PODocumentUploadDL.cs", "Commit For Add", exception.Message.ToString(), _myConnection);
                        return new TransactionResult(TransactionStatus.Failure, "Failure Adding");
                    }
                    bl = _screenMode != ScreenMode.Edit;
                    if (!bl)
                    {
                        ErrorLog.LogErrorMessageToDB("", "PODocumentUploadDL.cs", "Commit For Edit", exception.Message.ToString(), _myConnection);
                        return new TransactionResult(TransactionStatus.Failure, "Failure Editing");
                    }
                    bl = _screenMode != ScreenMode.Delete;
                    if (!bl)
                    {
                        ErrorLog.LogErrorMessageToDB("", "PODocumentUploadDL.cs", "Commit For Delete", exception.Message.ToString(), _myConnection);
                        return new TransactionResult(TransactionStatus.Failure, "Failure Deleting");
                    }
                }
            }
            finally
            {
                bl = dbConnection == null;
                if (!bl)
                {
                    dbConnection.Dispose();
                }
            }
            return null;
        }
        private TransactionResult AddEditWorkOrderDocument(Database db, DbTransaction transaction)
        {
            TransactionResult transactionResult;
            bool bl;
            int i = 0;

            DbCommand dbCommand = db.GetStoredProcCommand("spAddEditWorkOrderDocument");
            db.AddInParameter(dbCommand, "@WorkOrderDocumentID", DbType.Int32, _workOrderDocumentID);
            db.AddInParameter(dbCommand, "@ContactID", DbType.Int32, _contactID);
            db.AddInParameter(dbCommand, "@WorkOrderID", DbType.Int32, _workOrderDocumentID);
            db.AddInParameter(dbCommand, "@PONo", DbType.String, _pONo);
            db.AddInParameter(dbCommand, "@FileName", DbType.String, _fileName);
            db.AddInParameter(dbCommand, "@Fileextension", DbType.String, _fileExtension);
            db.AddInParameter(dbCommand, "@FilePathandFileName", DbType.String, _filePathandFileName);
            db.AddInParameter(dbCommand, "@FileDescription", DbType.String, _fileDescription);
            db.AddInParameter(dbCommand, "@IsActive", DbType.Boolean, _isActive);
            db.AddInParameter(dbCommand, "@AddEditOption", DbType.Int16, _addEditOption);
            db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value", DataRowVersion.Default, i);
            db.ExecuteNonQuery(dbCommand, transaction);
            i = (int)db.GetParameterValue(dbCommand, "Return Value");
            _workOrderDocumentID = (int)i;
            bl = i != -1;
            if (!bl)
            {
                bl = _addEditOption != 1;
                if (!bl)
                {
                    return new TransactionResult(TransactionStatus.Failure, "Failure Updated");
                }
                transactionResult = new TransactionResult(TransactionStatus.Failure, "Failure Adding");
            }
            else
            {
                bl = _addEditOption != 1;
                transactionResult = !bl ? new TransactionResult(TransactionStatus.Success, "Successfully Updated") : new TransactionResult(TransactionStatus.Success, "Successfully Added");
            }
            return transactionResult;
        }


        private TransactionResult DeletePatientFiles(Database db, DbTransaction transaction)
        {
            TransactionResult transactionResult;
            int i = 0;
            DbCommand dbCommand = db.GetStoredProcCommand("spDeleteWorkOrderDocument");
            db.AddInParameter(dbCommand, "@WorkOrderDocumentID", DbType.Int32, _workOrderDocumentID);
            db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value", DataRowVersion.Default, i);
            db.ExecuteNonQuery(dbCommand, transaction);
            i = (int)db.GetParameterValue(dbCommand, "Return Value");
            transactionResult = i == -1 ? new TransactionResult(TransactionStatus.Failure, "Failure Deleted") : new TransactionResult(TransactionStatus.Success, "Successfully Deleted");
            return transactionResult;
        }


        public DataSet GetWorkOrderDocumentListByContactID(int ContactID)
        {
            DataSet dataSet;
            try
            {
                Database database = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
                DbCommand dbCommand = database.GetStoredProcCommand("spGetWorkOrderDocumentListByContactID");
                database.AddInParameter(dbCommand, "@ContactID", DbType.Int32, ContactID);
                dataSet = database.ExecuteDataSet(dbCommand);
            }
            catch (Exception exception1)
            {
                ErrorLog.LogErrorMessageToDB("", "PODocumentUploadDL.cs", "GetWorkOrderDocumentListByContactID", exception1.Message.ToString(), _myConnection);
                throw;
            }
            return dataSet;
        }


        public void GetWorkOrderDocumentByWorkOrderDocumentID(int WorkOrderDocumentID)
        {
            SqlDataReader sqlDataReader;
            bool bl;
            Database database = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
            DbCommand dbCommand = database.GetStoredProcCommand("spGetWorkOrderDocumentByWorkOrderDocumentID");
            database.AddInParameter(dbCommand, "@WorkOrderDocumentID", DbType.Int32, WorkOrderDocumentID);
            sqlDataReader = database.ExecuteReader(dbCommand) as SqlDataReader;
            try
            {
                bl = !sqlDataReader.HasRows;
                if (!bl)
                {
                    while (sqlDataReader.Read())
                    {
                        _fileName = Convert.ToString(sqlDataReader["FileName"].ToString());
                        _fileExtension = Convert.ToString(sqlDataReader["Fileextension"].ToString());
                        _filePathandFileName = Convert.ToString(sqlDataReader["FilePathandFileName"].ToString());
                    }
                }
            }
            finally
            {
                bl = sqlDataReader == null;
                if (!bl)
                {
                    sqlDataReader.Dispose();
                }
            }
        }
       
    }
}