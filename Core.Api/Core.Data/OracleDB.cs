using Core.Interfaces.Data;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;

namespace Core.Data
{
    public class OracleDB : IDatabase
    {
        private OracleConnection oracleConnection;
        private OracleCommand oracleCommand;

        public void ConnectDatabase()
        {
            try
            {
                if (oracleConnection == null || oracleConnection.State != ConnectionState.Open)
                {

                    string connectionString = @"";

                    oracleConnection = new OracleConnection(connectionString);
                    oracleConnection.Open();
                    oracleCommand = new OracleCommand();
                    oracleCommand.Connection = oracleConnection;
                }
            }
            catch (Exception err)
            {
                throw new Exception("Error stablishing a database connection" + err);
            }

        }
        public void DisconnectDatabase()
        {
            if (oracleConnection != null && oracleConnection.State.Equals(ConnectionState.Open))
            {
                oracleConnection.Close();
            }
        }
        public int ExecuteQueryNotReturnedData(string query)
        {
            int returnValue = 0;

            try
            {
                fillOracleCommand(query);
                returnValue = oracleCommand.ExecuteNonQuery();

            }
            catch (Exception err)
            {
                throw new Exception("Error to Execute a query, " + err);
            }
            finally
            {
                DisconnectDatabase();
            }
            return returnValue;
        }
        public DataTable ExecuteQueryReturnDataTable(string query)
        {
            DataTable dataTable = new DataTable();

            try
            {
                OracleDataReader oracleDataReader;
                fillOracleCommand(query);

                oracleDataReader = oracleCommand.ExecuteReader();

                dataTable.Load(oracleDataReader);
            }
            catch (Exception err)
            {
                throw new Exception("Error to Execute a query datatable, " + err);
            }
            finally
            {
                DisconnectDatabase();
            }
            return dataTable;
        }
        private void fillOracleCommand(string query)
        {
            ConnectDatabase();

            oracleCommand.CommandType = CommandType.Text;
            oracleCommand.CommandText = query;
            
        }
        public object ExecuteScalar(string query)
        {
            object objectReturn;

            try
            {
                ConnectDatabase();
                fillOracleCommand(query);
                objectReturn = oracleCommand.ExecuteScalar();
            }
            catch (Exception err)
            {
                throw new Exception("Error to Execute scale, " + err);
            }
            finally
            {
                DisconnectDatabase();
            }
            return objectReturn;
        }
    }
}
