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
    public class OrderAcceptanceParticularsListDL
    {
        #region Private Variable

        private PineConnection _myConnection;
        private ScreenMode _screenMode;

        private int _addEditOption;

        private int _orderAcceptanceParticularsListID;
        private int _orderAcceptanceCheckListID;
        private int _particularsID;
        private bool _statusYes;
        private bool _statusNo;
        private string _remarks;

        #endregion

        #region Public Variable
        public int OrderAcceptanceParticularsListID
        {
            get { return _orderAcceptanceParticularsListID; }
            set { _orderAcceptanceParticularsListID = value; }
        }

        
        public int OrderAcceptanceCheckListID
        {
            get { return _orderAcceptanceCheckListID; }
            set { _orderAcceptanceCheckListID = value; }
        }

        public int ParticularsID
        {
            get { return _particularsID; }
            set { _particularsID = value; }
        }
        
        public bool StatusYes
        {
            get { return _statusYes; }
            set { _statusYes = value; }
        }

        public bool StatusNo
        {
            get { return _statusNo; }
            set { _statusNo = value; }
        }   

        public string Remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }
       
        public OrderAcceptanceParticularsListDL()
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
        
        #endregion

        private TransactionResult AddEditOrderAcceptanceParticularsList(Database db, DbTransaction transaction)
        {
            int i = 0;
            DbCommand dbCommand = db.GetStoredProcCommand("spAddEditOrderAcceptanceParticularsList");
            db.AddInParameter(dbCommand, "OrderAcceptanceParticularsListID", System.Data.DbType.Int32, _orderAcceptanceParticularsListID);
            db.AddInParameter(dbCommand, "OrderAcceptanceCheckListID", System.Data.DbType.Int32, _orderAcceptanceCheckListID);
            db.AddInParameter(dbCommand, "ParticularsID", System.Data.DbType.Int32, _particularsID);
            db.AddInParameter(dbCommand, "StatusYes", System.Data.DbType.Boolean, _statusYes);  
            db.AddInParameter(dbCommand, "StatusNo", System.Data.DbType.Boolean, _statusNo);       
            db.AddInParameter(dbCommand, "Remarks", System.Data.DbType.String, _remarks);

            db.AddInParameter(dbCommand, "AddEditOption", System.Data.DbType.Int16, _addEditOption);
            db.AddParameter(dbCommand, "Return Value", System.Data.DbType.Int32, System.Data.ParameterDirection.ReturnValue, "Return Value", System.Data.DataRowVersion.Default, i);
            db.ExecuteNonQuery(dbCommand, transaction);
            _orderAcceptanceParticularsListID = (int)db.GetParameterValue(dbCommand, "Return Value");
            if (_orderAcceptanceParticularsListID == -1)
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
                            result = AddEditOrderAcceptanceParticularsList(db, transaction);
                            if (result.Status == TransactionStatus.Failure)
                            {
                                transaction.Rollback();
                                return result;
                            }

                            break;
                        case ScreenMode.Edit:
                            break;
                        case ScreenMode.Delete:
                            result = DeleteOrderAcceptanceParticularsList(db, transaction);
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


        private TransactionResult DeleteOrderAcceptanceParticularsList(Database db, DbTransaction transaction)
        {
            TransactionResult transactionResult;
            int i = 0;
            DbCommand dbCommand = db.GetStoredProcCommand("spDeleteOrderAcceptanceParticularsList");
            db.AddInParameter(dbCommand, "OrderAcceptanceParticularsListID", System.Data.DbType.Int32, _orderAcceptanceParticularsListID);
            db.AddParameter(dbCommand, "Return Value", System.Data.DbType.Int32, System.Data.ParameterDirection.ReturnValue, "Return Value", System.Data.DataRowVersion.Default, i);
            db.ExecuteNonQuery(dbCommand, transaction);
            i = (int)db.GetParameterValue(dbCommand, "Return Value");
            transactionResult = i == -1 ? new TransactionResult(TransactionStatus.Failure, "Failure Deleted") : new TransactionResult(TransactionStatus.Success, "Successfully Deleted");
            return transactionResult;
        }

        public void GetOrderAcceptanceParticularsListByOrderAcceptanceParticularsListID(int OrderAcceptanceParticularsListID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
                string sqlCommand = "spGetOrderAcceptanceParticularsListByOrderAcceptanceParticularsListID";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "OrderAcceptanceParticularsListID", DbType.Int32, OrderAcceptanceParticularsListID);
                DataSet ds = db.ExecuteDataSet(dbCommand);
                               
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dRow = ds.Tables[0].Rows[0];                    
                    OrderAcceptanceParticularsListID = Common.CheckIntNull(Convert.ToInt32(dRow["OrderAcceptanceParticularsListID"]));
                    OrderAcceptanceCheckListID = Common.CheckIntNull(Convert.ToInt32(dRow["OrderAcceptanceCheckListID"]));
                    ParticularsID = Common.CheckIntNull(Convert.ToInt32(dRow["ParticularsID"]));
                    StatusYes = Convert.ToBoolean(dRow["StatusYes"]);
                    StatusNo = Convert.ToBoolean(dRow["StatusNo"]);
                    Remarks = Common.CheckNull(Convert.ToString(dRow["Remarks"]));
                }
            }
            catch (System.Exception exception1)
            {
                ErrorLog.LogErrorMessageToDB("", "OrderAcceptanceParticularsListDL.cs", "GetOrderAcceptanceParticularsListByOrderAcceptanceParticularsListID", exception1.Message.ToString(), _myConnection);
            }

        }

        public void GetOrderAcceptanceParticularsListByParticularsID(int OrderAcceptanceCheckListID, int ParticularsID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
                string sqlCommand = "spGetOrderAcceptanceParticularsListByParticularsID";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "OrderAcceptanceCheckListID", DbType.Int32, OrderAcceptanceCheckListID);
                db.AddInParameter(dbCommand, "ParticularsID", DbType.Int32, ParticularsID);
                DataSet ds = db.ExecuteDataSet(dbCommand);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dRow = ds.Tables[0].Rows[0];
                    OrderAcceptanceParticularsListID = Common.CheckIntNull(Convert.ToInt32(dRow["OrderAcceptanceParticularsListID"]));
                    OrderAcceptanceCheckListID = Common.CheckIntNull(Convert.ToInt32(dRow["OrderAcceptanceCheckListID"]));
                    ParticularsID = Common.CheckIntNull(Convert.ToInt32(dRow["ParticularsID"]));
                    StatusYes = Convert.ToBoolean(dRow["StatusYes"]);
                    StatusNo = Convert.ToBoolean(dRow["StatusNo"]);
                    Remarks = Common.CheckNull(Convert.ToString(dRow["Remarks"]));
                }
            }
            catch (System.Exception exception1)
            {
                ErrorLog.LogErrorMessageToDB("", "OrderAcceptanceParticularsListDL.cs", "GetOrderAcceptanceParticularsListByOrderAcceptanceParticularsListID", exception1.Message.ToString(), _myConnection);
            }

        }

        public System.Data.DataSet GetParticularsList()
        {
            System.Data.DataSet dataSet;
            dataSet = new System.Data.DataSet();
            try
            {
                Database database = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
                dataSet = database.ExecuteDataSet(database.GetStoredProcCommand("spGetParticularsList"));
            }
            catch (System.Exception exception1)
            {
                ErrorLog.LogErrorMessageToDB("", "OrderAcceptanceParticularsListDL.cs", "GetParticularsList", exception1.Message.ToString(), _myConnection);
                throw;
            }
            return dataSet;
        }

        public System.Data.DataSet GetOrderAcceptanceParticularsList()
        {
            System.Data.DataSet dataSet;
            dataSet = new System.Data.DataSet();
            try
            {
                Database database = DatabaseFactory.CreateDatabase(_myConnection.DatabaseName);
                dataSet = database.ExecuteDataSet(database.GetStoredProcCommand("spGetOrderAcceptanceParticularsList"));
            }
            catch (System.Exception exception1)
            {
                ErrorLog.LogErrorMessageToDB("", "OrderAcceptanceParticularsListDL.cs", "GetOrderAcceptanceParticularsList", exception1.Message.ToString(), _myConnection);
                throw;
            }
            return dataSet;
        }
    }
}
