DECLARE @counter INT = 0;

WHILE @counter < 1762
BEGIN
   INSERT INTO TypicalBranch.dbo.[Order] (EmployeeID, OrderDate)
   VALUES (CAST(RAND() * 9 + 2 AS INT), DATEADD(day, CAST(RAND() * DATEDIFF(day, '2019-01-01', '2023-12-31') AS INT), '2019-01-01'));
   SET @counter = @counter + 1;
END