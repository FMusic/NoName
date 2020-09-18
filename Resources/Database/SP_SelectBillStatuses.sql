USE NoNameCoffeeBar;
GO

CREATE PROCEDURE SP_SelectBillStatuses
@BillId INT = -1
AS
BEGIN
	IF (@BillId = -1)
	BEGIN
		SELECT * FROM BillStatus;
	END
	ELSE
	BEGIN
		SELECT * FROM BillStatus WHERE BillId = @BillId;
	END
END
