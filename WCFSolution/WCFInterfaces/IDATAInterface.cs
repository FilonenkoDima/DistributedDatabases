using System.Collections.Generic;
using System.Data;
using System.ServiceModel;

namespace WCFInterfaces
{
    [ServiceContract]
    public interface IDataLayer
    {
        [OperationContract]
        DataTable GetTable(string ConStr, string Table);
        [OperationContract]
        List<string> GetTables(string ConStr);
        [OperationContract]
        void InsertData(string connectionString, string tableName, string parameters, string data);
        [OperationContract]
        void DeleteDataById(string connectionString, string tableName, string idColumnName, int id);
        [OperationContract]
        DataTable FindDataByValue(string connectionString, string tableName, string columnName, string columnValue);
        [OperationContract]
        DataTable FindDataById(string connectionString, string tableName, string idColumnName, int idValue);
        [OperationContract]
        void EditDataById(string connectionString, string tableName, string idColumnName, int idValue, string parameters, string data);
        [OperationContract]
        DataTable FindData(string connectionString, string tableName, string filterExpression);
        [OperationContract]
        DataTable HorizontalQuery();
        [OperationContract]
        DataTable VerticalQuery();
    }
}
