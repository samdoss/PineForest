using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using PineForest.CommonLayer;

namespace PineForest.DataLayer
{
    public class StockDL
    {
        private int _addEditOption;
        private string _materialDescription;
        private int _materialID;
        private int _stockID;        
        private int _availableCount;
        private int _auditID;

        private PineConnection _myConnection;
        private ScreenMode _screenMode;

        public StockDL()
            : base()
        {
            _myConnection = new PineConnection();
            AddEditOption = 0;
        }

        public StockDL(string MaterialDescription)
            : base()
        {
            _myConnection = new PineConnection();
            AddEditOption = 0;
            _materialDescription = MaterialDescription;
        }

        public int AddEditOption
        {
            get { return _addEditOption; }
            set { _addEditOption = value; }
        }

        public string MaterialDescription
        {
            get { return _materialDescription; }
            set { _materialDescription = value; }
        }

        public int MaterialID
        {
            get { return _materialID; }
            set { _materialID = value; }
        }
        public int StockID
        {
            get { return _stockID; }
            set { _stockID = value; }
        }
        public int AuditID
        {
            get { return _auditID; }
            set { _auditID = value; }
        }
        public int AvailableCount
        {
            get { return _availableCount; }
            set { _availableCount = value; }
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

        private TransactionResult AddEditStock(Database db, System.Data.Common.DbTransaction transaction)
        {
            //TransactionResult transactionResult;
            bool bl;
            int i = 0;
            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand("spAddEditStock");
            db.AddInParameter(dbCommand, "StockID", System.Data.DbType.Int32, _stockID);
            db.AddInParameter(dbCommand, "MaterialID", System.Data.DbType.Int32, _materialID);
            db.AddInParameter(dbCommand, "AvailableCount", System.Data.DbType.Int32, _availableCount);
            db.AddInParameter(dbCommand, "AuditID", System.Data.DbType.Int32, _auditID);
            db.AddInParameter(dbCommand, "AddEditOption", System.Data.DbType.Int16, _addEditOption);
            db.AddParameter(dbCommand, "Return Value", System.Data.DbType.Int32, System.Data.ParameterDirection.ReturnValue, "Return Value", System.Data.DataRowVersion.Default, i);
            db.ExecuteNonQuery(dbCommand, transaction);
            StockID = (int)db.GetParameterValue(dbCommand, "Return Value");
            if (StockID == -1)
            {
                if (_addEditOption == 1)
                    return new TransactionResult(TransactionStatus.Failure, "Failure Updating");
                else
                    return new TransactionResult(TransactionStatus.Failure, "Failure Adding");
            }
            //else if (MaterialID == -99)
            //{
            //    if (_addEditOption == 1)
            //    {
            //        return new TransactionResult(TransactionStatus.Success, "Record already exists");
            //    }
            //    else
            //    {
            //        return new TransactionResult(TransactionStatus.Success, "Record already exists");
            //    }
            //}
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
                            result = AddEditStock(db, transaction);
                            if (result.Status == TransactionStatus.Failure)
                            {
                                transaction.Rollback();
                                return result;
                            }

                            break;
                        case ScreenMode.Edit:
                            break;
                        case ScreenMode.Delete:
                            result = DeleteStock(db, transaction);
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


        private TransactionResult DeleteStock(Database db, System.Data.Common.DbTransaction transaction)
        {
            TransactionResult transactionResult;
            int i = 0;
            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand("spDeleteStock");
            db.AddInParameter(dbCommand, "StockID", System.Data.DbType.Int32, _stockID);
            db.AddParameter(dbCommand, "Return Value", System.Data.DbType.Int32, System.Data.ParameterDirection.ReturnValue, "Return Value", System.Data.DataRowVersion.Default, i);
            db.ExecuteNonQuery(dbCommand, transaction);
            i = (int)db.GetParameterValue(dbCommand, "Return Value");
            transactionResult = i == -1 ? new TransactionResult(TransactionStatus.Failure, "Failure Deleted") : new TransactionResult(TransactionStatus.Success, "Successfully Deleted");
            return transactionResult;
        }

        public int GetStockID(string MaterialDescription)
        {
            int i;
            System.Data.SqlClient.SqlDataReader sqlDataReader;
            bool bl;
            i = 0;
            try
            {
                Database database = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
                System.Data.Common.DbCommand dbCommand = database.GetStoredProcCommand("spGetStockByMaterialID");
                database.AddInParameter(dbCommand, "MaterialID", System.Data.DbType.Int32, _materialID);
                sqlDataReader = database.ExecuteReader(dbCommand) as System.Data.SqlClient.SqlDataReader;
                try
                {
                    bl = !sqlDataReader.HasRows;
                    if (!bl)
                    {
                        while (sqlDataReader.Read())
                        {
                            i = Common.CheckIntNull(sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("AvailableCount")));
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
            catch (System.Exception exception1)
            {
                ErrorLog.LogErrorMessageToDB("", "StockDL.cs", "GetStockID", exception1.Message.ToString(), _myConnection);
            }
            return i;
        }

        public System.Data.DataSet GetStockList()
        {
            System.Data.DataSet dataSet;
            dataSet = new System.Data.DataSet();
            try
            {
                Database database = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
                dataSet = database.ExecuteDataSet(database.GetStoredProcCommand("spGetStockList"));
            }
            catch (System.Exception exception1)
            {
                ErrorLog.LogErrorMessageToDB("", "StockDL.cs", "GetStockList", exception1.Message.ToString(), _myConnection);
                throw;
            }
            return dataSet;
        }





    }
}
