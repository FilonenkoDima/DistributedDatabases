using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace ComSrv
{
    [ComVisible(true)]
    [Guid("F53DD0D3-448C-43CD-B3C3-C115E6EFBAC5")]
    public interface IDataLayer
    {
        DataTable GetTable(string ConStr, string Table);
        List<string> GetTables(string ConStr);
        void InsertData(string connectionString, string tableName, string parameters, string data);
        void DeleteDataById(string connectionString, string tableName, string idColumnName, int id);
        DataTable FindDataByValue(string connectionString, string tableName, string columnName, string columnValue);
        DataTable FindDataById(string connectionString, string tableName, string idColumnName, int idValue);
        void EditDataById(string connectionString, string tableName, string idColumnName, int idValue, string parameters, string data);
        DataTable FindData(string connectionString, string tableName, string filterExpression);
    }


    [ComVisible(true)]
    [Guid("B3B98CC4-776E-4C1F-AFEE-30703C1090F3")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class DBComSrv : IDataLayer
    {
        public DBComSrv()
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
            OleDbConnection cn = new OleDbConnection(ConStr);
            cn.Open();
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM " + Table, cn);
            OleDbDataReader r = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(r);
            cn.Close();
            return dt;
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
            OleDbCommand command = new OleDbCommand($"SELECT * FROM {tableName} WHERE {idColumnName} = {idValue} ", connection);
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
        public DataTable OrderIdWhereEmployeeNameStartWithDandSumBetween500and1000Vertical()
        {
            string connectionString = @"Provider=SQLOLEDB;Data
Source=DESKTOP-B4L9B2O\SQLEXPRESS;Integrated Security=SSPI;Initial
Catalog=MainOffice";
            OleDbConnection cn = new OleDbConnection(connectionString);
            cn.Open();
            string sql = @"SELECT part1.OrderID, part1.[Total price], part1.[Employee name], part2.Position, part2.HireDate, part2.BranchID
FROM
(SELECT emp.EmployeeID, emp.FirstName + ' ' + emp.LastName AS [Employee name], SUM(prod.Quantity * prod.UnitPrice) as [Total price], ordd.OrderID
FROM [DESKTOP-B4L9B2O].[TypicalBranch].[dbo].[Products] as prod INNER JOIN ([DESKTOP-B4L9B2O].[TypicalBranch].[dbo].[Order Details] as ordd INNER JOIN ([DESKTOP-B4L9B2O].[TypicalBranch].[dbo].[Order] as ord INNER JOIN [DESKTOP-B4L9B2O].[TypicalBranch].[dbo].[Employees] as emp
	ON ord.EmployeeID = emp.EmployeeID) ON ordd.OrderID = ord.OrderID) ON prod.ProductID = ordd.ProductID
WHERE emp.LastName LIKE 'D%'
GROUP BY ordd.OrderID, emp.EmployeeID, emp.FirstName + ' ' + emp.LastName
	HAVING SUM(prod.Quantity * prod.UnitPrice) BETWEEN 500 AND 1000
	) AS part1
INNER JOIN
(SELECT emc.Position, emc.HireDate, bra.BranchID, bra.EmployeeID
FROM Branches as bra INNER JOIN
([Employment contracts] as emc INNER JOIN Employees as emp ON emc.EmployeeID = emp.EmployeeID) ON bra.EmployeeID = emp.EmployeeID)
AS part2 ON part1.EmployeeID = part2.EmployeeID
";
            OleDbCommand cmd = new OleDbCommand(sql, cn);
            OleDbDataReader r = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(r);
            cn.Close();
            return dt;
        }
        public DataTable ProductNameWithQuantityBiggerThan50Horizontal()
        {
            string connectionString = @"Provider=SQLOLEDB;Data
Source=DESKTOP-B4L9B2O\SQLEXPRESS;Integrated Security=SSPI;Initial
Catalog=MainOffice";
            OleDbConnection cn = new OleDbConnection(connectionString);
            cn.Open();
            string sql = @"SELECT prod.[Category name] as [Product name], prod.[Category name], prod.[Total price], prod.Quantity
FROM ([Order Details] AS od INNER JOIN (
	SELECT cws.ContractWithSupplierID as CwsID, ship.CompanyName as [Shipper name], sup.CompanyName as [Supplier name]
	FROM ([Contracts with suppliers] as cws INNER JOIN Shippers as ship ON cws.ShipperID = ship.ShipperID)
	INNER JOIN Suppliers as sup ON cws.SupplierID = sup.SupplierID
	WHERE ship.CompanyName LIKE 'Speed%' AND sup.CompanyName LIKE 'P%'
) as contract ON od.ContractWithSupplierID = contract.CwsID) 
		INNER JOIN (
		SELECT pr.ProductID as prID, pr.ProductName as [Product name], cat.Name as [Category name], pr.Quantity * pr.UnitPrice as [Total price], pr.Quantity
		FROM Products as pr INNER JOIN Categories as cat ON pr.CategoryID = cat.CategoryID
		WHERE pr.Quantity * pr.UnitPrice > 1000 AND cat.Name LIKE 'C%'
		) as prod ON od.ProductID = prod.prID

		UNION ALL

SELECT prod.ProductName AS [Product name], cat.Name AS [Category name], prod.Quantity * prod.UnitPrice as [Total price], prod.Quantity
FROM [DESKTOP-B4L9B2O].[TypicalBranch].[dbo].[Products] as prod 
	INNER JOIN [DESKTOP-B4L9B2O].[TypicalBranch].[dbo].[Categories] AS cat ON prod.CategoryID = cat.CategoryID
WHERE prod.Quantity > 50

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
