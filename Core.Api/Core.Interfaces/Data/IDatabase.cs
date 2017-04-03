using System.Data;

namespace Core.Interfaces.Data
{
    public interface IDatabase
    {
        
        void ConnectDatabase();
        void DisconnectDatabase();       
        int ExecuteQueryNotReturnedData(string query);
        object ExecuteScalar(string query);
        DataTable ExecuteQueryReturnDataTable(string query);
    }
}
