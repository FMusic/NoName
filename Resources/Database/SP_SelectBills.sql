USE NoNameCoffeeBar;
GO

CREATE PROCEDURE SP_SelectBills
AS
BEGIN
	SELECT * FROM Bill;
END
