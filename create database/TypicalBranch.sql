CREATE DATABASE "TypicalBranch"
GO

set quoted_identifier on
GO

SET DATEFORMAT mdy
GO
USE "TypicalBranch"
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

CREATE TABLE "Order" (
	"OrderID" INT IDENTITY (1, 1) NOT NULL ,
	"EmployeeID" INT NOT NULL ,
	"OrderDate" DATETIME NOT NULL ,
	CONSTRAINT "PK_Order" PRIMARY KEY  CLUSTERED 
	(
		"OrderID"
	),
)

CREATE TABLE "Order Details" (
	"OrderID" INT NOT NULL ,
	"ProductID" INT NOT NULL ,
	CONSTRAINT "PK_Order Details" PRIMARY KEY  CLUSTERED 
	(
		"OrderID",
		"ProductID"
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

CREATE TABLE "Categories" (
	"CategoryID" INT IDENTITY (1, 1) NOT NULL ,
	"Name" NVARCHAR (20) NOT NULL ,
	"Description" NVARCHAR (300) NULL ,
	CONSTRAINT "PK_Categories" PRIMARY KEY  CLUSTERED 
	(
		"CategoryID"
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
CONSTRAINT "FK_Order Details_To_Order" FOREIGN KEY("OrderID") REFERENCES "Order"("OrderID")
		ON DELETE CASCADE
		ON UPDATE CASCADE;

ALTER TABLE "Order"
ADD 
CONSTRAINT "FK_Order_To_Employees" FOREIGN KEY("EmployeeID") REFERENCES "Employees"("EmployeeID")
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