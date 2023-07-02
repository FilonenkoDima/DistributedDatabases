DECLARE @counter INT = 0;

WHILE @counter < 3000
BEGIN
   INSERT INTO [Order Details](ContractWithSupplierID, ProductID)
   VALUES (CAST(RAND() * 830 + 1 AS INT), CAST(RAND() * 77 + 1 AS INT));
   SET @counter = @counter + 1;
END