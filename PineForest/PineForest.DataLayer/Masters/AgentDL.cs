using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using PineForest.CommonLayer;

namespace PineForest.DataLayer
{
    public class AgentDL
    {
        private int _addEditOption;
        private string _AgentDescription;
        private int _AgentID;
        private PineConnection _myConnection;
        private ScreenMode _screenMode;


        public AgentDL()
            : base()
        {
            this._myConnection = new PineConnection();
            this.AddEditOption = 0;
        }

        public AgentDL(string AgentDescription)
            : base()
        {
            this._myConnection = new PineConnection();
            this.AddEditOption = 0;
            this.AgentDescription = AgentDescription;
        }

        public int AddEditOption
        {
            get { return _addEditOption; }
            set { _addEditOption = value; }
        }

        public string AgentDescription
        {
            get { return _AgentDescription; }
            set { _AgentDescription = value; }
        }

        public int AgentID
        {
            get { return _AgentID; }
            set { _AgentID = value; }
        }

        public ScreenMode ScreenMode
        {
            get
            {
                return this._screenMode;
            }
            set
            {
                this._screenMode = value;
            }
        }

        private TransactionResult AddEditAgent(Database db, System.Data.Common.DbTransaction transaction)
        {
            TransactionResult transactionResult;
            bool bl;
            int i = 0;
            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand("spAddEditAgent");
            db.AddInParameter(dbCommand, "AgentID", System.Data.DbType.Int32, this.AgentID);
            db.AddInParameter(dbCommand, "Agent", System.Data.DbType.String, this.AgentDescription);
            db.AddInParameter(dbCommand, "AddEditOption", System.Data.DbType.Int16, this.AddEditOption);
            db.AddParameter(dbCommand, "Return Value", System.Data.DbType.Int32, System.Data.ParameterDirection.ReturnValue, "Return Value", System.Data.DataRowVersion.Default, i);
            db.ExecuteNonQuery(dbCommand, transaction);
            this.AgentID = (int)db.GetParameterValue(dbCommand, "Return Value");
            if (AgentID == -1)
            {
                if (_addEditOption == 1)
                    return new TransactionResult(TransactionStatus.Failure, "Failure Updating");
                else
                    return new TransactionResult(TransactionStatus.Failure, "Failure Adding");
            }
            else if (AgentID == -99)
            {
                if (_addEditOption == 1)
                {
                    return new TransactionResult(TransactionStatus.Success, "Record already exists");
                }
                else
                {
                    return new TransactionResult(TransactionStatus.Success, "Record already exists");
                }
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
                            result = AddEditAgent(db, transaction);
                            if (result.Status == TransactionStatus.Failure)
                            {
                                transaction.Rollback();
                                return result;
                            }

                            break;
                        case ScreenMode.Edit:
                            break;
                        case ScreenMode.Delete:
                            result = DeleteAgent(db, transaction);
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


        private TransactionResult DeleteAgent(Database db, System.Data.Common.DbTransaction transaction)
        {
            TransactionResult transactionResult;
            int i = 0;
            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand("spDeleteAgent");
            db.AddInParameter(dbCommand, "AgentID", System.Data.DbType.Int32, this._AgentID);
            db.AddParameter(dbCommand, "Return Value", System.Data.DbType.Int32, System.Data.ParameterDirection.ReturnValue, "Return Value", System.Data.DataRowVersion.Default, i);
            db.ExecuteNonQuery(dbCommand, transaction);
            i = (int)db.GetParameterValue(dbCommand, "Return Value");
            transactionResult = i == -1 ? new TransactionResult(TransactionStatus.Failure, "Failure Deleted") : new TransactionResult(TransactionStatus.Success, "Successfully Deleted");
            return transactionResult;
        }

        public int GetAgentID(string AgentDescription)
        {
            int i;
            System.Data.SqlClient.SqlDataReader sqlDataReader;
            bool bl;
            i = 0;
            try
            {
                Database database = DatabaseFactory.CreateDatabase(this._myConnection.DatabaseName);
                System.Data.Common.DbCommand dbCommand = database.GetStoredProcCommand("spGetAgentID");
                database.AddInParameter(dbCommand, "Agent", System.Data.DbType.String, AgentDescription);
                sqlDataReader = database.ExecuteReader(dbCommand) as System.Data.SqlClient.SqlDataReader;
                try
                {
                    bl = !sqlDataReader.HasRows;
                    if (!bl)
                    {
                        while (sqlDataReader.Read())
                        {
                            i = Common.CheckIntNull(sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("AgentID")));
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
                ErrorLog.LogErrorMessageToDB("", "Agent.cs", "GetAgentID", exception1.Message.ToString(), this._myConnection);
            }
            return i;
        }

        public System.Data.DataSet GetAgentList()
        {
            System.Data.DataSet dataSet;
            dataSet = new System.Data.DataSet();
            try
            {
                Database database = DatabaseFactory.CreateDatabase(this._myConnection.DatabaseName);
                dataSet = database.ExecuteDataSet(database.GetStoredProcCommand("spGetAgentList"));
            }
            catch (System.Exception exception1)
            {
                ErrorLog.LogErrorMessageToDB("", "Agent.cs", "GetAgentList", exception1.Message.ToString(), this._myConnection);
                throw;
            }
            return dataSet;
        }





    }
}
