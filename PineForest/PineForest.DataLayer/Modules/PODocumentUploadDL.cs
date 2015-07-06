using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using PineForest.CommonLayer;
using System.Data;
using System.Data.SqlClient;

namespace PineForest.DataLayer
{
    public class PODocumentUploadDL
    {

        #region private variable

        private PineConnection _myConnection;
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
        private int _auditID;

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

        public PODocumentUploadDL()
        {
            _myConnection = new PineConnection();
            AddEditOption = 0;
        }

        private TransactionResult AddEditWorkOrderDocument(Database db, System.Data.Common.DbTransaction transaction)
        {
            //TransactionResult transactionResult;
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
            _workOrderDocumentID = (int)db.GetParameterValue(dbCommand, "Return Value");
            if (_workOrderDocumentID == -1)
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
                            result = AddEditWorkOrderDocument(db, transaction);
                            if (result.Status == TransactionStatus.Failure)
                            {
                                transaction.Rollback();
                                return result;
                            }

                            break;
                        case ScreenMode.Edit:
                            break;
                        case ScreenMode.Delete:
                            result = DeleteWorkOrderDocument(db, transaction);
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


        private TransactionResult DeleteWorkOrderDocument(Database db, System.Data.Common.DbTransaction transaction)
        {
            TransactionResult transactionResult;
            int i = 0;
            DbCommand dbCommand = db.GetStoredProcCommand("spDeleteWorkOrderDocument");
            db.AddInParameter(dbCommand, "@WorkOrderDocumentID", DbType.Int32, _workOrderDocumentID);
            db.AddParameter(dbCommand, "Return Value", System.Data.DbType.Int32, System.Data.ParameterDirection.ReturnValue, "Return Value", System.Data.DataRowVersion.Default, i);
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
