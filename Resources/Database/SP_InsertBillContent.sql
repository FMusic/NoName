USE NoNameCoffeeBar;
GO

CREATE PROCEDURE SP_InsertBillContent
@ProductPrice FLOAT,
@ProductQuantity INT,
@ProductId INT,
@BillId INT
AS
BEGIN
	INSERT INTO BillContent VALUES (@ProductPrice, @ProductQuantity, @ProductId, @BillId);
END
