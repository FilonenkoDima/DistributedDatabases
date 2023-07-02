using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System;
using WCFInterfaces;

namespace WCFClasses
{
    public class DATAClass : IDataLayer
    {
        public DATAClass() 
        { 

        }

        public void InsertData(string connectionString, string tableName, string parameters, string data)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string cmd = $"INSERT INTO {tableName} ({parameters}) VALUES ('{data}')";
                Console.WriteLine(cmd);
                OleDbCommand command = new OleDbCommand(cmd, connection);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteDataById(string connectionString, string tableName, string idColumnName, int id)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand($"DELETE FROM {tableName} WHERE {idColumnName} = {id}", connection);
                command.ExecuteNonQuery();
            }
        }

        public List<string> GetTables(string ConStr)
        {
            List<string> ls = new List<string>();
            ls.Clear();
            OleDbConnection cn = new OleDbConnection(ConStr);
            cn.Open();
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM sys.tables", cn);
            OleDbDataReader r = cmd.ExecuteReader();
            while (r.Read())
                ls.Add(r.GetString(0));

            cn.Close();
            return ls;
        }

        public DataTable GetTable(string ConStr, string Table)
        {
            DataTable result = null;
            OleDbDataAdapter oleDbDataAdapte;
            using (OleDbConnection oleDbConnection = new OleDbConnection(ConStr))
            {
                using (OleDbCommand oleDbCommand = oleDbConnection.CreateCommand())
                {
                    oleDbCommand.CommandText = "SELECT * FROM " + Table;
                    oleDbDataAdapte = new OleDbDataAdapter(oleDbCommand.CommandText, oleDbConnection);
                    result = new DataTable();
                    oleDbDataAdapte.Fill(result);
                }
            }

            return result;
        }

        public DataTable FindDataByValue(string connectionString, string tableName, string columnName, string columnValue)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            OleDbCommand command = new OleDbCommand($"SELECT * FROM {tableName} WHERE {columnName} ={columnValue}", connection);
            DataTable dt = new DataTable();
            OleDbDataReader r = command.ExecuteReader();
            dt.Load(r);
            connection.Close();
            return dt;
        }

        public DataTable FindDataById(string connectionString, string tableName, string idColumnName, int idValue)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            OleDbCommand command = new OleDbCommand($"SELECT * FROM {tableName} WHERE {idColumnName} ={idValue} ", connection);
            DataTable dt = new DataTable();
            OleDbDataReader r = command.ExecuteReader();
            dt.Load(r);
            connection.Close();
            return dt;
        }

        public void EditDataById(string connectionString, string tableName, string idColumnName, int idValue, string parameters, string data)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand($"UPDATE {tableName} SET {parameters} = {data} WHERE {idColumnName} = {idValue}", connection);
                command.ExecuteNonQuery();
            }
        }

        public DataTable FindData(string connectionString, string tableName, string filterExpression)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            OleDbCommand command = new OleDbCommand($"SELECT * FROM {tableName} WHERE {filterExpression}", connection);
            DataTable dt = new DataTable();
            OleDbDataReader r = command.ExecuteReader();
            dt.Load(r);
            connection.Close();
            return dt;
        }
        public DataTable VerticalQuery()
        {
            string connectionString = @"Provider=SQLOLEDB;Data Source=DESKTOP-B4L9B2O\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=MainOffice1";
            OleDbConnection cn = new OleDbConnection(connectionString);
            cn.Open();
            string sql = @"select two.ProductName, two.CategoryName, two.TotalQuantity
from (SELECT stor.ProductID, stor.ProductName, stor.CategoryName, stor.TotalQuantity, new.[Shipper name], new.[Supplier name]
	  FROM (OrderDetails  od 
	  INNER JOIN (
		SELECT pod.SupplierContractID, ship.CompanyName as [Shipper name], sup.CompanyName as [Supplier name]
		FROM PaymentOrderDetails pod
		INNER JOIN Shipper ship ON pod.ShipperID = ship.ShipperID
		INNER JOIN Supplier sup ON pod.SupplierID = sup.SupplierID
		WHERE ship.CompanyName LIKE 'S%' AND sup.CompanyName LIKE 'F%'
	  ) as new ON od.SupplierContractID = new.SupplierContractID)
			INNER JOIN (
			SELECT st.ProductID, st.ProductName, c.CategoryName, st.TotalQuantity
			FROM Storage st 
			INNER JOIN Category c ON st.CategoryID = c.CategoryID
			WHERE st.TotalQuantity > 20 AND c.CategoryName LIKE 'D%'
			) as stor ON od.ProductID = stor.ProductID) one

full JOIN 
(SELECT st.ProductID, st.ProductName, c.CategoryName, st.TotalQuantity
FROM [DESKTOP-B4L9B2O].[TypicalBranch1].[dbo].[Storage] st 
JOIN [DESKTOP-B4L9B2O].[TypicalBranch1].[dbo].[Category] c ON st.CategoryID = c.CategoryID
WHERE st.TotalQuantity > 20) two on one.ProductID = two.ProductID
";
            OleDbCommand cmd = new OleDbCommand(sql, cn);
            OleDbDataReader r = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(r);
            cn.Close();
            return dt;
        }
        public DataTable HorizontalQuery()
        {
            string connectionString = @"Provider=SQLOLEDB;Data Source=DESKTOP-B4L9B2O\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=MainOffice1";
            OleDbConnection cn = new OleDbConnection(connectionString);
            cn.Open();
            string sql = @"SELECT stor.ProductName, stor.CategoryName, stor.TotalQuantity
FROM (OrderDetails  od 
INNER JOIN (
	SELECT pod.SupplierContractID, ship.CompanyName as [Shipper name], sup.CompanyName as [Supplier name]
	FROM PaymentOrderDetails pod
	INNER JOIN Shipper ship ON pod.ShipperID = ship.ShipperID
	INNER JOIN Supplier sup ON pod.SupplierID = sup.SupplierID
	WHERE ship.CompanyName LIKE 'S%' AND sup.CompanyName LIKE 'F%'
) as new ON od.SupplierContractID = new.SupplierContractID)
		INNER JOIN (
		SELECT st.ProductID, st.ProductName, c.CategoryName, st.TotalQuantity
		FROM Storage st 
		INNER JOIN Category c ON st.CategoryID = c.CategoryID
		WHERE st.TotalQuantity > 20 AND c.CategoryName LIKE 'D%'
		) as stor ON od.ProductID = stor.ProductID

		UNION ALL

SELECT st.ProductName COLLATE Ukrainian_CI_AS, c.CategoryName COLLATE Ukrainian_CI_AS, st.TotalQuantity
FROM [DESKTOP-B4L9B2O].[TypicalBranch1].[dbo].[Storage] AS st 
JOIN [DESKTOP-B4L9B2O].[TypicalBranch1].[dbo].[Category] AS c ON st.CategoryID = c.CategoryID
WHERE st.TotalQuantity > 20

";
            OleDbCommand cmd = new OleDbCommand(sql, cn);
            OleDbDataReader r = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(r);
            cn.Close();
            return dt;
        }
    }
}