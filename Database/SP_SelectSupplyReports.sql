USE NoNameCoffeeBar;
GO

CREATE PROCEDURE SP_SelectSupplyReports
AS
BEGIN
	SELECT * FROM SupplyReport;
END
