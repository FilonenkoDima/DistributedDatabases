insert into MainOffice.dbo.[Contracts with suppliers] (SupplierID, ShipperID)
Select FLOOR(RAND() * 29) + 1, ShipVia from Northwind.dbo.[Orders]