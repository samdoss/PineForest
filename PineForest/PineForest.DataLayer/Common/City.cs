using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Microsoft.Practices;
using PineForest.CommonLayer;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace PineForest.DataLayer
{
    public class City
    {
        private int _cityID;
        private string _cityName;
        private int _stateID;
        private ScreenMode _screenMode;
        private PineConnection _myConnection;
        private int _addEditOption;

        public string CityName
        {
            get
            {
                return this._cityName;
            }
            set
            {
                this._cityName = value;
            }
        }

        public int CityID
        {
            get
            {
                return this._cityID;
            }
            set
            {
                this._cityID = value;
            }
        }

        public int AddEditOption
        {
            get { return _addEditOption; }
            set { _addEditOption = value; }
        }

        public int StateID
        {
            get { return _stateID; }
            set { _stateID = value; }
        }

        public ScreenMode ScreenMode
        {
            get { return _screenMode; }
            set { _screenMode = value; }
        }


        public City() : base()
        {
            this._myConnection = new PineConnection();
            this.AddEditOption = 0;
        }

        public City(int CityID, bool getAllProperties)
            : base()
        {
            this._myConnection = new PineConnection();
            this.AddEditOption = 0;
            this._cityID = CityID;
            if (getAllProperties)
            {
                GetCity();
            }
        }

        private TransactionResult DeleteCity(Database db, System.Data.Common.DbTransaction transaction)
        {
            TransactionResult transactionResult;
            int i = 0;
            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand("spDeleteCity");
            db.AddInParameter(dbCommand, "CityID", System.Data.DbType.Int32, this._cityID);
            db.AddParameter(dbCommand, "Return Value", System.Data.DbType.Int32, System.Data.ParameterDirection.ReturnValue, "Return Value", System.Data.DataRowVersion.Default, i);
            db.ExecuteNonQuery(dbCommand, transaction);
            i = (int)db.GetParameterValue(dbCommand, "Return Value");
            transactionResult = i == -1 ? new TransactionResult(TransactionStatus.Failure, "Failure Deleting City") : new TransactionResult(TransactionStatus.Success, "City Successfully Deleted");
            return transactionResult;
        }

        private TransactionResult AddEditCity(Database db, System.Data.Common.DbTransaction transaction)
        {
            int i;
            TransactionResult transactionResult;
            bool bl;
            i = 0;
            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand("spAddEditCity");
            db.AddInParameter(dbCommand, "StateID", System.Data.DbType.Int32, this.StateID);
            db.AddInParameter(dbCommand, "CityID", System.Data.DbType.Int32, this._cityID);
            db.AddInParameter(dbCommand, "City", System.Data.DbType.String, this._cityName);
            db.AddInParameter(dbCommand, "AddEditOption", System.Data.DbType.Int16, this.AddEditOption);
            db.AddParameter(dbCommand, "Return Value", System.Data.DbType.Int32, System.Data.ParameterDirection.ReturnValue, "Return Value", System.Data.DataRowVersion.Default, i);
            db.ExecuteNonQuery(dbCommand, transaction);
            this._cityID = (int)db.GetParameterValue(dbCommand, "Return Value");
            bl = i != 0;
            if (!bl)
            {
                transactionResult = new TransactionResult(TransactionStatus.Failure, "City Already Exists in the State");
            }
            else
            {
                bl = i != -1;
                if (!bl)
                {
                    bl = this.AddEditOption != 1;
                    if (!bl)
                    {
                        return new TransactionResult(TransactionStatus.Failure, "Failure Updated");
                    }
                    transactionResult = new TransactionResult(TransactionStatus.Failure, "Failure Adding");
                }
                else
                {
                    bl = this.AddEditOption != 1;
                    transactionResult = !bl ? new TransactionResult(TransactionStatus.Success, "Successfully Updated") : new TransactionResult(TransactionStatus.Success, "Successfully Added");
                }
            }
            return transactionResult;
        }

        public TransactionResult Commit()
        {
            TransactionResult transactionResult;
            Database database;
            System.Data.Common.DbConnection dbConnection;
            System.Data.Common.DbTransaction dbTransaction;
            System.Exception exception;
            TransactionResult transactionResult1;
            bool bl;
            transactionResult = null;
            database = DatabaseFactory.CreateDatabase(this._myConnection.DatabaseName);
            dbConnection = database.CreateConnection();
            try
            {
                dbConnection.Open();
                dbTransaction = dbConnection.BeginTransaction();
                try
                {
                    switch (this.ScreenMode)
                    {
                        case ScreenMode.Add:
                            transactionResult = AddEditCity(database, dbTransaction);
                            bl = transactionResult.Status != TransactionStatus.Failure;
                            if (!bl)
                            {
                                dbTransaction.Rollback();
                                return transactionResult;
                            }
                            break;

                        case ScreenMode.View:
                            transactionResult = new TransactionResult(TransactionStatus.Success);
                            break;

                        case ScreenMode.Delete:
                            transactionResult = DeleteCity(database, dbTransaction);
                            bl = transactionResult.Status != TransactionStatus.Failure;
                            if (!bl)
                            {
                                dbTransaction.Rollback();
                                return transactionResult;
                            }
                            break;

                    }
                    dbTransaction.Commit();
                    transactionResult1 = transactionResult;
                }
                catch (System.Exception exception1)
                {
                    exception = exception1;
                    dbTransaction.Rollback();
                    bl = this.ScreenMode != ScreenMode.Add;
                    if (!bl)
                    {
                        ErrorLog.LogErrorMessageToDB("", "City.cs", "Commit For Add", exception.Message.ToString(), this._myConnection);
                        return new TransactionResult(TransactionStatus.Failure, "Failure Adding City Description");
                    }
                    bl = this.ScreenMode != ScreenMode.Edit;
                    if (!bl)
                    {
                        ErrorLog.LogErrorMessageToDB("", "City.cs", "Commit For Edit", exception.Message.ToString(), this._myConnection);
                        return new TransactionResult(TransactionStatus.Failure, "Failure Updating City Description");
                    }
                    bl = this.ScreenMode != ScreenMode.Delete;
                    if (!bl)
                    {
                        ErrorLog.LogErrorMessageToDB("", "City.cs", "Commit For Delete", exception.Message.ToString(), this._myConnection);
                        return new TransactionResult(TransactionStatus.Failure, "Failure Deleting City Description");
                    }
                }
                transactionResult1 = transactionResult;
            }
            finally
            {
                bl = dbConnection == null;
                if (!bl)
                {
                    dbConnection.Dispose();
                }
            }
            return transactionResult1;
        }

        private void GetCity()
        {
            System.Data.SqlClient.SqlDataReader sqlDataReader;
            bool bl;
            try
            {
                Database database = DatabaseFactory.CreateDatabase(this._myConnection.DatabaseName);
                System.Data.Common.DbCommand dbCommand = database.GetStoredProcCommand("spGetCity");
                database.AddInParameter(dbCommand, "CityID", System.Data.DbType.Int32, this._cityID);
                sqlDataReader = database.ExecuteReader(dbCommand) as System.Data.SqlClient.SqlDataReader;
                try
                {
                    bl = !sqlDataReader.HasRows;
                    if (!bl)
                    {
                        while (sqlDataReader.Read())
                        {
                            StateID = Common.CheckIntNull(sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("StateID")));
                            _cityName = Common.CheckNull(sqlDataReader.GetString(sqlDataReader.GetOrdinal("City")));
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
                ErrorLog.LogErrorMessageToDB("", "City.cs", "GetCity", exception1.Message.ToString(), this._myConnection);
                throw;
            }
        }

        public System.Data.DataSet GetCityListByStateID(int StateID)
        {
            System.Data.DataSet dataSet;
            dataSet = new System.Data.DataSet();
            try
            {
                Database database = DatabaseFactory.CreateDatabase(this._myConnection.DatabaseName);
                System.Data.Common.DbCommand dbCommand = database.GetStoredProcCommand("spGetCityListByStateID");
                database.AddInParameter(dbCommand, "StateID", System.Data.DbType.Int32, StateID);
                dataSet = database.ExecuteDataSet(dbCommand);
            }
            catch (System.Exception exception1)
            {
                ErrorLog.LogErrorMessageToDB("", "City.cs", "GetCityListByStateID", exception1.Message.ToString(), this._myConnection);
            }
            return dataSet;
        }

        public int GetCityID(int countryID, int stateID, string cityName)
        {
            int i;
            System.Data.SqlClient.SqlDataReader sqlDataReader;
            bool bl;
            i = 0;
            try
            {
                Database database = DatabaseFactory.CreateDatabase(this._myConnection.DatabaseName);
                System.Data.Common.DbCommand dbCommand = database.GetStoredProcCommand("spGetCityID");
                database.AddInParameter(dbCommand, "CountryID", System.Data.DbType.Int32, countryID);
                database.AddInParameter(dbCommand, "StateID", System.Data.DbType.Int32, stateID);
                database.AddInParameter(dbCommand, "City", System.Data.DbType.String, cityName);
                sqlDataReader = database.ExecuteReader(dbCommand) as System.Data.SqlClient.SqlDataReader;
                try
                {
                    bl = !sqlDataReader.HasRows;
                    if (!bl)
                    {
                        while (sqlDataReader.Read())
                        {
                            i = Common.CheckIntNull(sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("CityID")));
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
                ErrorLog.LogErrorMessageToDB("", "City.cs", "GetCityID", exception1.Message.ToString(), this._myConnection);
            }
            return i;
        }

    }
}
