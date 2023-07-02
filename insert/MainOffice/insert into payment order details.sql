DECLARE @counter INT = 0;

WHILE @counter < 200
BEGIN
   INSERT INTO [Payment Order Details](ContractWithSupplierID, PaymentOrderID)
   VALUES (CAST(RAND() * 830 + 1 AS INT), CAST(RAND() * 120 + 1 AS INT));
   SET @counter = @counter + 1;
END