insert into MainOffice.dbo.Products (ProductName, CategoryID, Quantity, UnitPrice)
Select ProductName, CategoryID, UnitsInStock, UnitPrice from Northwind.dbo.Products