USE NoNameCoffeeBar;
GO

CREATE PROCEDURE SP_InsertBill
@Year INT,
@Month INT,
@Day INT
AS
BEGIN
	DECLARE @LastNumber AS INT;
	DECLARE @BillNumberPrefix AS VARCHAR(11);
	DECLARE @BillNumberFull AS VARCHAR(15);
	
	SET @BillNumberPrefix = CONCAT(@Year, '-', FORMAT(@Month, 'D2'), '-', FORMAT(@Day, 'D2'));
	
	SET @LastNumber = (SELECT ISNULL(
		(
			SELECT TOP 1 CAST(SUBSTRING(Number, 12, 4) AS INT) FROM Bill
			WHERE Number LIKE CONCAT(@BillNumberPrefix, '-%')
			ORDER BY Number DESC
		), 0));
		
	SET @BillNumberFull = CONCAT(@BillNumberPrefix, '-', FORMAT(@LastNumber + 1, 'D4'));
	INSERT INTO Bill VALUES (@BillNumberFull);
	SELECT SCOPE_IDENTITY() AS Id;
END
