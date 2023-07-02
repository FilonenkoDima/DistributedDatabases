CREATE DATABASE "MainOffice"
GO

set quoted_identifier on
GO

SET DATEFORMAT mdy
GO
USE "MainOffice"
GO

CREATE TABLE "Employees" (
	"EmployeeID" INT IDENTITY (1, 1) NOT NULL ,
	"LastName" NVARCHAR (20) NOT NULL ,
	"FirstName" NVARCHAR (10) NOT NULL ,
	"Title" NVARCHAR (30) NULL ,
	"BirthDate" DATETIME NULL ,
	"Address" NVARCHAR (200) NULL ,
	"PostalCode" NVARCHAR (10) NULL ,
	"Phone" NVARCHAR (24) NULL ,
	"Notes" NVARCHAR NULL ,
	CONSTRAINT "PK_Employees" PRIMARY KEY  CLUSTERED 
	(
		"EmployeeID"
	),
	CONSTRAINT "CK_Birthdate" CHECK (BirthDate < getdate())
)

CREATE TABLE "Branches" (
	"BranchID" INT IDENTITY (1, 1) NOT NULL ,
	"EmployeeID" INT NULL ,
	"Address" NVARCHAR (200) NOT NULL ,
	CONSTRAINT "PK_Branches" PRIMARY KEY  CLUSTERED 
	(
		"BranchID"
	)
)

CREATE TABLE "Employment contracts" (
	"EmploymentContractID" INT IDENTITY (1, 1) NOT NULL ,
	"EmployeeID" INT NOT NULL ,
	"Position" NVARCHAR (10) NOT NULL ,
	"HireDate" DATETIME NULL ,
	CONSTRAINT "PK_Employment contracts" PRIMARY KEY  CLUSTERED 
	(
		"EmploymentContractID"
	),
)

CREATE TABLE "Salary documentation details" (
	"EmploymentContractID" INT NOT NULL ,
	"PaymentDate" DATETIME NULL ,
	"Salary" MONEY NOT NULL ,
	CONSTRAINT "PK_Salary documentation details" PRIMARY KEY  CLUSTERED 
	(
		"EmploymentContractID"
	),
)


ALTER TABLE "Branches"
ADD 
CONSTRAINT "FK_Branches_To_Employees" FOREIGN KEY("EmployeeID") REFERENCES "Employees"("EmployeeID")
		ON DELETE CASCADE
		ON UPDATE CASCADE;

ALTER TABLE "Employment contracts"
ADD 
CONSTRAINT "FK_Employment contracts_To_Employees" FOREIGN KEY("EmployeeID") REFERENCES "Employees"("EmployeeID")
		ON DELETE CASCADE
		ON UPDATE CASCADE;

ALTER TABLE "Salary documentation details"
ADD 
CONSTRAINT "FK_Salary documentation details_To_Employment contracts" FOREIGN KEY("EmploymentContractID") REFERENCES "Employment contracts"("EmploymentContractID")
		ON DELETE CASCADE
		ON UPDATE CASCADE;




-------------------------------------------------------



CREATE TABLE "Categories" (
	"CategoryID" INT IDENTITY (1, 1) NOT NULL ,
	"Name" NVARCHAR (20) NOT NULL ,
	"Description" NVARCHAR (300) NULL ,
	CONSTRAINT "PK_Categories" PRIMARY KEY  CLUSTERED 
	(
		"CategoryID"
	),
)

CREATE TABLE "Products" (
	"ProductID" INT IDENTITY (1, 1) NOT NULL ,
	"ProductName" NVARCHAR (20) NOT NULL ,
	"CategoryID" INT NULL ,
	"Quantity" SMALLINT NOT NULL,
	"UnitPrice" MONEY NOT NULL,
	CONSTRAINT "PK_Products" PRIMARY KEY  CLUSTERED 
	(
		"ProductID"
	),
)

CREATE TABLE "Order Details" (
	"ContractWithSupplierID" INT NOT NULL ,
	"ProductID" INT NOT NULL ,
	CONSTRAINT "PK_Order Details" PRIMARY KEY  CLUSTERED 
	(
		"ContractWithSupplierID",
		"ProductID"
	),
)

CREATE TABLE "Contracts with suppliers" (
	"ContractWithSupplierID" INT IDENTITY (1, 1) NOT NULL ,
	"SupplierID" INT NOT NULL ,
	"ShipperID" INT NOT NULL ,
	CONSTRAINT "PK_Contracts with suppliers" PRIMARY KEY  CLUSTERED 
	(
		"ContractWithSupplierID"
	),
)

CREATE TABLE "Suppliers" (
	"SupplierID" INT IDENTITY (1, 1) NOT NULL ,
	"CompanyName" NVARCHAR (40) NOT NULL ,
	"ContactName" NVARCHAR (40) NULL ,
	"ContactTitle" NVARCHAR (40) NULL ,
	"Address" NVARCHAR (200) NULL,
	"Phone" NVARCHAR (20) NOT NULL,
	"PostalCode" NVARCHAR (10) NULL,
	CONSTRAINT "PK_Suppliers" PRIMARY KEY  CLUSTERED 
	(
		"SupplierID"
	),
)

CREATE TABLE "Shippers" (
	"ShipperID" INT IDENTITY (1, 1) NOT NULL ,
	"CompanyName" NVARCHAR (40) NOT NULL ,
	"Phone" NVARCHAR (20) NOT NULL,
	CONSTRAINT "PK_Shippers" PRIMARY KEY  CLUSTERED 
	(
		"ShipperID"
	),
)

CREATE TABLE "Payment Order Details" (
	"ContractWithSupplierID" INT NOT NULL ,
	"PaymentOrderID" INT NOT NULL ,
	CONSTRAINT "PK_Payment Order Details" PRIMARY KEY  CLUSTERED 
	(
		"ContractWithSupplierID",
		"PaymentOrderID"
	),
)

CREATE TABLE "Payment order" (
	"PaymentOrderID" INT IDENTITY (1, 1) NOT NULL ,
	"Title" NVARCHAR (40) NOT NULL ,
	"Description" NVARCHAR (1200) NULL ,
	"CompanyName" NVARCHAR (40) NULL ,
	"Payment amount" MONEY NULL,
	"Date" DATETIME NOT NULL,
	CONSTRAINT "PK_Payment order" PRIMARY KEY  CLUSTERED 
	(
		"PaymentOrderID"
	),
)


ALTER TABLE "Products"
ADD 
CONSTRAINT "FK_Products_To_Categories" FOREIGN KEY("CategoryID") REFERENCES "Categories"("CategoryID")
		ON DELETE CASCADE
		ON UPDATE CASCADE;

ALTER TABLE "Order Details"
ADD 
CONSTRAINT "FK_Order Details_To_Products" FOREIGN KEY("ProductID") REFERENCES "Products"("ProductID")
		ON DELETE CASCADE
		ON UPDATE CASCADE;

ALTER TABLE "Order Details"
ADD 
CONSTRAINT "FK_Order Details_To_Contracts with suppliers" FOREIGN KEY("ContractWithSupplierID") REFERENCES "Contracts with suppliers"("ContractWithSupplierID")
		ON DELETE CASCADE
		ON UPDATE CASCADE;

ALTER TABLE "Contracts with suppliers"
ADD 
CONSTRAINT "FK_Contracts with suppliers_To_Suppliers" FOREIGN KEY("SupplierID") REFERENCES "Suppliers"("SupplierID")
		ON DELETE CASCADE
		ON UPDATE CASCADE;

ALTER TABLE "Contracts with suppliers"
ADD 
CONSTRAINT "FK_Contracts with suppliers_To_Shippers" FOREIGN KEY("ShipperID") REFERENCES "Shippers"("ShipperID")
		ON DELETE CASCADE
		ON UPDATE CASCADE;

ALTER TABLE "Payment Order Details"
ADD 
CONSTRAINT "FK_Payment Order Details_To_Contracts with suppliers" FOREIGN KEY("ContractWithSupplierID") REFERENCES "Contracts with suppliers"("ContractWithSupplierID")
		ON DELETE CASCADE
		ON UPDATE CASCADE;

ALTER TABLE "Payment Order Details"
ADD 
CONSTRAINT "FK_Payment Order Details_To_Payment order" FOREIGN KEY("PaymentOrderID") REFERENCES "Payment order"("PaymentOrderID")
		ON DELETE CASCADE
		ON UPDATE CASCADE;



		----------------------------------------------


CREATE TABLE "Financial reports" (
	"FinancialReportID" INT IDENTITY (1, 1) NOT NULL ,
	"Title" NVARCHAR (40) NOT NULL ,
	"Date" DATETIME NOT NULL,
	"Description" NVARCHAR (1200) NULL ,
	"Total income" MONEY NULL ,
	"Total expenses" MONEY NULL,
	"Profit" MONEY NULL,
	CONSTRAINT "PK_Financial reports" PRIMARY KEY  CLUSTERED 
	(
		"FinancialReportID"
	),
)