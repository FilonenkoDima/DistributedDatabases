DECLARE @counter INT = 0;

WHILE @counter < 3099
BEGIN
   INSERT INTO [Order Details] (OrderID, ProductID)
   VALUES (CAST(RAND() * 1762 + 1 AS INT), CAST(RAND() * 77 + 5 AS INT));
   SET @counter = @counter + 1;
END