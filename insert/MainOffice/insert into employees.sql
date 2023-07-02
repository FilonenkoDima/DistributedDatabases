insert into MainOffice.dbo.Employees(LastName, FirstName, BirthDate, Address, PostalCode, Phone, Notes)
Select LastName, FirstName, BirthDate, Country + ', ' + Region + ', ' + City + ', ' + Address, PostalCode, HomePhone, Notes from Northwind.dbo.Employees