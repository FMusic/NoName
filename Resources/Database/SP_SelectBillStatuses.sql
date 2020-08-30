USE NoNameCoffeeBar;
GO

CREATE PROCEDURE SP_SelectBillStatuses
AS
BEGIN
	SELECT * FROM BillStatus;
END
