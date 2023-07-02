insert into TypicalBranch.dbo.Products (ProductName, CategoryID, Quantity, UnitPrice)
Select ProductName, CategoryID, Quantity, UnitPrice from MainOffice.dbo.Products

