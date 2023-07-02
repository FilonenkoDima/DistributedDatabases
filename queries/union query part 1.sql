SET STATISTICS TIME ON;  
GO

SELECT prod.[Category name] as [Product name], prod.[Category name], prod.[Total price], prod.Quantity, contract.[Shipper name], contract.[Supplier name]
FROM ([Order Details] AS od INNER JOIN (

SELECT cws.ContractWithSupplierID as CwsID, ship.CompanyName as [Shipper name], sup.CompanyName as [Supplier name]
FROM ([Contracts with suppliers] as cws INNER JOIN Shippers as ship ON cws.ShipperID = ship.ShipperID)
INNER JOIN Suppliers as sup ON cws.SupplierID = sup.SupplierID
WHERE ship.CompanyName LIKE 'Speed%' AND sup.CompanyName LIKE 'P%'
) as contract ON od.ContractWithSupplierID = contract.CwsID
) 
INNER JOIN (

SELECT pr.ProductID as prID, pr.ProductName as [Product name], cat.Name as [Category name], pr.Quantity * pr.UnitPrice as [Total price], pr.Quantity
FROM Products as pr INNER JOIN Categories as cat ON pr.CategoryID = cat.CategoryID
WHERE pr.Quantity * pr.UnitPrice > 1000 AND cat.Name LIKE 'C%'
) as prod ON od.ProductID = prod.prID