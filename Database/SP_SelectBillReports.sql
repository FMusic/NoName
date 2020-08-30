USE NoNameCoffeeBar;
GO

CREATE PROCEDURE SP_SelectBillReports
AS
BEGIN
	SELECT * FROM BillReport;
END
