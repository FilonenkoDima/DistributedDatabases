USE MainOffice;
GO

SET STATISTICS TIME ON;  
GO

SELECT part1.OrderID, part1.[Total price], part1.[Employee name], part2.Position, part2.HireDate, part2.BranchID
FROM
(SELECT emp.EmployeeID, emp.FirstName + ' ' + emp.LastName AS [Employee name], SUM(prod.Quantity * prod.UnitPrice) as [Total price], ordd.OrderID
FROM [DESKTOP-B4L9B2O].[TypicalBranch].[dbo].[Order Details] as ordd 
	INNER JOIN [DESKTOP-B4L9B2O].[TypicalBranch].[dbo].[Order] as ord ON ordd.OrderID = ord.OrderID
	INNER JOIN [DESKTOP-B4L9B2O].[TypicalBranch].[dbo].[Employees] as emp ON ord.EmployeeID = emp.EmployeeID
	INNER JOIN [DESKTOP-B4L9B2O].[TypicalBranch].[dbo].[Products] as prod ON ordd.ProductID = prod.ProductID
WHERE emp.LastName LIKE 'D%' AND prod.Quantity * prod.UnitPrice BETWEEN 500 AND 1000
GROUP BY ordd.OrderID, emp.EmployeeID, emp.FirstName + ' ' + emp.LastName) AS part1
INNER JOIN
(SELECT emc.Position, emc.HireDate, bra.BranchID, bra.EmployeeID
FROM Branches as bra INNER JOIN
([Employment contracts] as emc INNER JOIN Employees as emp ON emc.EmployeeID = emp.EmployeeID) ON bra.EmployeeID = emp.EmployeeID)
AS part2 ON part1.EmployeeID = part2.EmployeeID